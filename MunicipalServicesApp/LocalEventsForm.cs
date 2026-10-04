using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace MunicipalServicesApp
{
    public partial class LocalEventsForm : Form
    {
        private EventManager eventManager;
        private RecommendationEngine recommender;

        public LocalEventsForm()
        {
            InitializeComponent();
            eventManager = new EventManager();
            recommender = new RecommendationEngine();

            LoadDummyData();
            PopulateCategories();
            DisplayAllEvents();
            UpdateRecentlyViewedUI();

            dgvEvents.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvEvents.ReadOnly = true;
            dgvEvents.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // ---------------------------------------------------------
            // SECURITY CHECK: Restrict Add/Edit/Delete to Staff Only
            // ---------------------------------------------------------
            bool isStaff = UserSession.CurrentUser != null && UserSession.CurrentUser.Role == Models.UserRole.Municipal;

            // Show/Hide buttons based on role
            btnEditEvent.Visible = isStaff;
            btnDeleteEvent.Visible = isStaff;
        }

        private void LoadDummyData()
        {
            var events = new List<MunicipalEvent>
            {
                new MunicipalEvent { EventID = 1, Title = "URGENT: Water Main Break", Category = "Alert", EventDate = DateTime.Now.AddDays(0), Location = "Brits Main St", Description = "Avoid Main St. Repair crews dispatched.", Priority = 1 },
                new MunicipalEvent { EventID = 2, Title = "Town Hall Meeting", Category = "Community", EventDate = DateTime.Now.AddDays(2), Location = "Civic Center", Description = "Discuss Madibeng municipal budget.", Priority = 2 },
                new MunicipalEvent { EventID = 3, Title = "Community Cleanup", Category = "Environment", EventDate = DateTime.Now.AddDays(5), Location = "Hartbeespoort Dam Park", Description = "Volunteer event.", Priority = 3 },
                new MunicipalEvent { EventID = 4, Title = "Local Music Festival", Category = "Entertainment", EventDate = DateTime.Now.AddDays(10), Location = "Brits Main Square", Description = "Live bands and food stalls.", Priority = 3 },
                new MunicipalEvent { EventID = 5, Title = "Soccer Tournament", Category = "Sports", EventDate = DateTime.Now.AddDays(7), Location = "Sports Complex", Description = "Local teams competing.", Priority = 2 }
            };
            foreach (var evt in events) eventManager.AddEvent(evt);
        }

        private void PopulateCategories()
        {
            cmbCategory.Items.Clear();
            cmbCategory.Items.Add("All");
            foreach (var cat in eventManager.UniqueCategories) cmbCategory.Items.Add(cat);
            cmbCategory.SelectedIndex = 0;
        }

        private void DisplayAllEvents()
        {
            dgvEvents.DataSource = null;
            var allEvents = new List<MunicipalEvent>();
            foreach (var kvp in eventManager.EventsByDate) allEvents.AddRange(kvp.Value);
            dgvEvents.DataSource = allEvents;
            ApplyColorCoding();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.ToLower();
            string selectedCategory = cmbCategory.SelectedItem?.ToString();
            DateTime selectedDate = dtpSearchDate.Value.Date;

            if (!string.IsNullOrEmpty(selectedCategory) && selectedCategory != "All")
                recommender.RecordSearch(selectedCategory);

            var filtered = eventManager.EventsByDate.Values.SelectMany(x => x).AsEnumerable();

            if (selectedCategory != "All") filtered = filtered.Where(evt => evt.Category == selectedCategory);
            if (!string.IsNullOrEmpty(searchText))
                filtered = filtered.Where(evt => evt.Title.ToLower().Contains(searchText) || evt.Location.ToLower().Contains(searchText));

            // Date Filter (Rubric Requirement)
            filtered = filtered.Where(evt => evt.EventDate.Date == selectedDate);

            dgvEvents.DataSource = filtered.ToList();
            ApplyColorCoding();
            UpdateRecommendationsUI();
        }

        private void UpdateRecommendationsUI()
        {
            lstRecommendations.Items.Clear();
            lstRecommendations.Items.Add("--- Recommended For You ---");
            var recs = recommender.GetRecommendations(eventManager);
            if (recs.Count == 0) lstRecommendations.Items.Add("Search a category to get recommendations!");
            else foreach (var evt in recs) lstRecommendations.Items.Add($"[{evt.Category}] {evt.Title}");
        }

        private void UpdateRecentlyViewedUI()
        {
            lstRecentlyViewed.Items.Clear();
            lstRecentlyViewed.Items.Add("--- Recently Viewed (Stack) ---");
            foreach (var evt in eventManager.RecentlyViewed) lstRecentlyViewed.Items.Add(evt.Title);
        }

        private void ApplyColorCoding()
        {
            foreach (DataGridViewRow row in dgvEvents.Rows)
            {
                if (row.DataBoundItem is MunicipalEvent evt)
                {
                    if (evt.Priority == 1) { row.DefaultCellStyle.BackColor = Color.LightCoral; row.DefaultCellStyle.Font = new Font(dgvEvents.Font, FontStyle.Bold); }
                    else if (evt.Priority == 2) { row.DefaultCellStyle.BackColor = Color.LightYellow; }
                }
            }

        }

        private void dgvEvents_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var selectedEvent = dgvEvents.Rows[e.RowIndex].DataBoundItem as MunicipalEvent;
                if (selectedEvent != null) { eventManager.RecordView(selectedEvent); UpdateRecentlyViewedUI(); }
            }
        }

        private void dgvEvents_SelectionChanged(object sender, EventArgs e)
        {
            // Only enable Edit/Delete if a row is selected AND the buttons are visible (Staff)
            bool hasSelection = dgvEvents.CurrentRow != null;
            if (btnEditEvent.Visible) btnEditEvent.Enabled = hasSelection;
            if (btnDeleteEvent.Visible) btnDeleteEvent.Enabled = hasSelection;
        }

        // --- STAFF ONLY BUTTONS ---



        // Designer references this Load event; provide an empty handler to satisfy the designer.
        private void LocalEventsForm_Load(object sender, EventArgs e)
        {
            // Intentionally left blank - initialization is handled in the constructor.
        }

        private void btnEditEvent_Click(object sender, EventArgs e)
        {
            if (dgvEvents.CurrentRow?.DataBoundItem is MunicipalEvent selectedEvent)
            {
                using (var editForm = new EditEventForm(selectedEvent))
                {
                    editForm.Text = "Edit Event (Staff Only)";
                    if (editForm.ShowDialog() == DialogResult.OK)
                    {
                        eventManager.UpdateEvent(editForm.UpdatedEvent);
                        DisplayAllEvents();
                        PopulateCategories();
                        MessageBox.Show("Event updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void btnDeleteEvent_Click(object sender, EventArgs e)
        {
            if (dgvEvents.CurrentRow?.DataBoundItem is MunicipalEvent selectedEvent)
            {
                var result = MessageBox.Show($"Are you sure you want to delete '{selectedEvent.Title}'?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    eventManager.DeleteEvent(selectedEvent.EventID);
                    DisplayAllEvents(); PopulateCategories();
                    MessageBox.Show("Event deleted.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}