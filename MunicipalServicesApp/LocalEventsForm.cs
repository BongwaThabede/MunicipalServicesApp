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

            // User-Friendly: Setup UI aesthetics
            dgvEvents.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvEvents.ReadOnly = true;
            dgvEvents.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void LoadDummyData()
        {
            var events = new List<MunicipalEvent>
            {
                new MunicipalEvent { EventID = 1, Title = "URGENT: Water Main Break", Category = "Alert", EventDate = DateTime.Now.AddDays(0), Location = "Main St", Description = "Avoid Main St. Repair crews dispatched.", Priority = 1 },
                new MunicipalEvent { EventID = 2, Title = "Town Hall Meeting", Category = "Community", EventDate = DateTime.Now.AddDays(2), Location = "Civic Center", Description = "Discuss new municipal budget.", Priority = 2 },
                new MunicipalEvent { EventID = 3, Title = "Community Cleanup", Category = "Environment", EventDate = DateTime.Now.AddDays(5), Location = "Central Park", Description = "Volunteer event for local park.", Priority = 3 },
                new MunicipalEvent { EventID = 4, Title = "Local Music Festival", Category = "Entertainment", EventDate = DateTime.Now.AddDays(10), Location = "Main Square", Description = "Live bands and food stalls.", Priority = 3 },
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
            ApplyColorCoding(); // User-friendly feature
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.ToLower();
            string selectedCategory = cmbCategory.SelectedItem?.ToString();

            if (!string.IsNullOrEmpty(selectedCategory) && selectedCategory != "All")
                recommender.RecordSearch(selectedCategory);

            var filtered = eventManager.EventsByDate.Values.SelectMany(x => x).AsEnumerable();

            if (selectedCategory != "All") filtered = filtered.Where(evt => evt.Category == selectedCategory);
            if (!string.IsNullOrEmpty(searchText))
                filtered = filtered.Where(evt => evt.Title.ToLower().Contains(searchText) || evt.Location.ToLower().Contains(searchText));

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

        // User-Friendly: Color code urgent events red
        private void ApplyColorCoding()
        {
            foreach (DataGridViewRow row in dgvEvents.Rows)
            {
                if (row.DataBoundItem is MunicipalEvent evt)
                {
                    if (evt.Priority == 1)
                    {
                        row.DefaultCellStyle.BackColor = Color.LightCoral; // Red for Urgent
                        row.DefaultCellStyle.Font = new Font(dgvEvents.Font, FontStyle.Bold);
                    }
                    else if (evt.Priority == 2)
                    {
                        row.DefaultCellStyle.BackColor = Color.LightYellow; // Yellow for Medium
                    }
                }
            }
        }

        // Triggered when user clicks a row (Demonstrates Stack usage)
        private void dgvEvents_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var selectedEvent = dgvEvents.Rows[e.RowIndex].DataBoundItem as MunicipalEvent;
                if (selectedEvent != null)
                {
                    eventManager.RecordView(selectedEvent);
                    UpdateRecentlyViewedUI();
                }
            }
        }

        private void dgvEvents_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}