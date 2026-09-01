using System;
using System.Linq;
using System.Windows.Forms;
using MunicipalServicesApp.Data;
using MunicipalServicesApp.Models;

namespace MunicipalServicesApp
{
    /// <summary>
    /// Municipal staff view. Lists every service request submitted by any
    /// resident, and lets staff change a request's status and attach a
    /// feedback message — which the resident then sees on their own
    /// tracking screen.
    /// </summary>
    public partial class MunicipalDashboardForm : Form
    {
        public MunicipalDashboardForm()
        {
            InitializeComponent();
            SetupGrid();
            SetupStatusOptions();
            LoadRequests();
        }

        private void SetupGrid()
        {
            grid.Columns.Add("Id", "Ref #");
            grid.Columns.Add("Resident", "Reported By");
            grid.Columns.Add("Category", "Category");
            grid.Columns.Add("Location", "Location");
            grid.Columns.Add("Status", "Status");
            grid.Columns.Add("Date", "Reported");
        }

        private void SetupStatusOptions()
        {
            cmbStatus.FormattingEnabled = true;
            cmbStatus.Format += (s, e) =>
            {
                if (e.ListItem is RequestStatus rs) e.Value = rs.ToDisplayString();
            };

            foreach (RequestStatus status in Enum.GetValues(typeof(RequestStatus)))
            {
                cmbStatus.Items.Add(status);
            }
        }

        private void LoadRequests()
        {
            grid.Rows.Clear();
            var requests = IssueRepository.All;

            lblEmpty.Visible = requests.Count == 0;
            grid.Visible = requests.Count > 0;

            foreach (var r in requests.OrderByDescending(x => x.DateReported))
            {
                grid.Rows.Add(r.Id, r.ResidentUsername, r.Category, r.Location, r.Status.ToDisplayString(), r.DateReported.ToString("dd MMM yyyy, HH:mm"));
            }

            rtbDetails.Clear();
            lblDetails.Text = "Details and history \u2014 select a request above";

            if (requests.Count > 0)
            {
                grid.Rows[0].Selected = true;
                ShowDetails(Convert.ToInt32(grid.Rows[0].Cells["Id"].Value));
            }
        }

        private void grid_SelectionChanged(object sender, EventArgs e)
        {
            if (grid.SelectedRows.Count == 0) return;
            var id = Convert.ToInt32(grid.SelectedRows[0].Cells["Id"].Value);
            ShowDetails(id);
        }

        private void ShowDetails(int requestId)
        {
            var request = IssueRepository.GetById(requestId);
            if (request == null) return;

            lblDetails.Text = $"Details and history \u2014 Ref #{request.Id}, reported by {request.ResidentUsername}";

            rtbDetails.Clear();
            rtbDetails.SelectionFont = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            rtbDetails.AppendText("Description: ");
            rtbDetails.SelectionFont = new System.Drawing.Font("Segoe UI", 9.5F);
            rtbDetails.AppendText($"{request.Description}\n");

            rtbDetails.SelectionFont = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            rtbDetails.AppendText("Attachments: ");
            rtbDetails.SelectionFont = new System.Drawing.Font("Segoe UI", 9.5F);
            rtbDetails.AppendText(request.AttachmentPaths.Count == 0
                ? "none\n\n"
                : string.Join(", ", request.AttachmentPaths.Select(System.IO.Path.GetFileName)) + "\n\n");

            rtbDetails.SelectionFont = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            rtbDetails.AppendText("History:\n");
            foreach (var entry in request.History.OrderByDescending(h => h.Timestamp))
            {
                rtbDetails.SelectionFont = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
                rtbDetails.AppendText($"{entry.Timestamp:dd MMM yyyy, HH:mm} \u2014 {entry.Status.ToDisplayString()} ");
                rtbDetails.SelectionFont = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
                rtbDetails.AppendText($"(by {entry.UpdatedBy})\n");
                rtbDetails.SelectionFont = new System.Drawing.Font("Segoe UI", 9F);
                if (!string.IsNullOrWhiteSpace(entry.Message))
                    rtbDetails.AppendText($"   {entry.Message}\n");
            }

            // Pre-select the current status in the dropdown for convenience.
            for (int i = 0; i < cmbStatus.Items.Count; i++)
            {
                if ((RequestStatus)cmbStatus.Items[i] == request.Status)
                {
                    cmbStatus.SelectedIndex = i;
                    break;
                }
            }
            txtFeedback.Clear();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (grid.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a service request first.", "No request selected",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbStatus.SelectedItem == null)
            {
                MessageBox.Show("Please choose a status to apply.", "Status required",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var id = Convert.ToInt32(grid.SelectedRows[0].Cells["Id"].Value);
            var newStatus = (RequestStatus)cmbStatus.SelectedItem;
            var message = txtFeedback.Text.Trim();

            IssueRepository.UpdateStatus(id, newStatus, message, UserSession.CurrentUser.FullName);

            MessageBox.Show(
                $"Request #{id} updated to \"{newStatus.ToDisplayString()}\".\nThe resident will see this update and your feedback next time they check.",
                "Status Updated",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            LoadRequests();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
