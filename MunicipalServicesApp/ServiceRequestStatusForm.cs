using System;
using System.Linq;
using System.Windows.Forms;
using MunicipalServicesApp.Data;
using MunicipalServicesApp.Models;

namespace MunicipalServicesApp
{
    /// <summary>
    /// Lets a resident see every issue they've reported, its current status,
    /// and the full history of status changes and feedback messages left by
    /// municipal staff — the "get feedback on my reported issues" screen.
    /// </summary>
    public partial class ServiceRequestStatusForm : Form
    {
        public ServiceRequestStatusForm()
        {
            InitializeComponent();
            SetupGrid();
            LoadRequests();
        }

        private void SetupGrid()
        {
            grid.Columns.Add("Id", "Ref #");
            grid.Columns.Add("Category", "Category");
            grid.Columns.Add("Location", "Location");
            grid.Columns.Add("Status", "Status");
            grid.Columns.Add("Date", "Reported");
        }

        private void LoadRequests()
        {
            grid.Rows.Clear();
            var requests = IssueRepository.ForResident(UserSession.CurrentUser.Username);

            lblEmpty.Visible = requests.Count == 0;
            grid.Visible = requests.Count > 0;

            foreach (var r in requests)
            {
                grid.Rows.Add(r.Id, r.Category, r.Location, r.Status.ToDisplayString(), r.DateReported.ToString("dd MMM yyyy, HH:mm"));
            }

            rtbTimeline.Clear();
            lblTimelineTitle.Text = "Status history and feedback \u2014 select a request above";

            if (requests.Count > 0)
            {
                grid.Rows[0].Selected = true;
                ShowTimeline(requests[0].Id);
            }
        }

        private void grid_SelectionChanged(object sender, EventArgs e)
        {
            if (grid.SelectedRows.Count == 0) return;
            var id = Convert.ToInt32(grid.SelectedRows[0].Cells["Id"].Value);
            ShowTimeline(id);
        }

        private void ShowTimeline(int requestId)
        {
            var request = IssueRepository.GetById(requestId);
            if (request == null) return;

            lblTimelineTitle.Text = $"Status history and feedback \u2014 Ref #{request.Id} ({request.Category})";

            rtbTimeline.Clear();
            rtbTimeline.SelectionFont = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            rtbTimeline.AppendText($"Current status: {request.Status.ToDisplayString()}\n\n");
            rtbTimeline.SelectionFont = new System.Drawing.Font("Segoe UI", 9.5F);

            foreach (var entry in request.History.OrderByDescending(h => h.Timestamp))
            {
                rtbTimeline.SelectionFont = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
                rtbTimeline.AppendText($"{entry.Timestamp:dd MMM yyyy, HH:mm} \u2014 {entry.Status.ToDisplayString()}\n");
                rtbTimeline.SelectionFont = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Italic);
                rtbTimeline.AppendText($"by {entry.UpdatedBy}\n");
                rtbTimeline.SelectionFont = new System.Drawing.Font("Segoe UI", 9.5F);
                if (!string.IsNullOrWhiteSpace(entry.Message))
                {
                    rtbTimeline.AppendText($"{entry.Message}\n");
                }
                rtbTimeline.AppendText("\n");
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadRequests();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
