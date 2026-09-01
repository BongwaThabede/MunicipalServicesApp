using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using MunicipalServicesApp.Data;

namespace MunicipalServicesApp
{
    /// <summary>
    /// "Report Issues" screen. Implements the user engagement strategy chosen
    /// in Task 1 (real-time status tracking and progress feedback): a ProgressBar
    /// and Label track how much of the report has been completed, a green
    /// checkmark appears next to each field as it's completed, and the
    /// ProgressBar itself changes colour (amber while in progress, green once
    /// ready) so the resident always has a clear, at-a-glance sense of where
    /// they stand.
    /// </summary>
    public partial class ReportIssuesForm : Form
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);

        private const int PBM_SETSTATE = 0x0410;
        private const int PBST_NORMAL = 0x0001; // green
        private const int PBST_PAUSED = 0x0003; // amber/yellow

        private const string LocationPlaceholder = "e.g. 12 Main Street, Sandton";
        private const string DescriptionPlaceholder = "Describe the issue in as much detail as possible...";

        private readonly List<string> _attachedFiles = new List<string>();
        private const int TotalRequiredFields = 3;

        public ReportIssuesForm()
        {
            InitializeComponent();
            SetupPlaceholders();
            AttachHoverEffects();
            UpdateEngagementFeedback();
        }

        private void SetupPlaceholders()
        {
            txtLocation.Text = LocationPlaceholder;
            txtLocation.ForeColor = System.Drawing.Color.Gray;

            rtbDescription.Text = DescriptionPlaceholder;
            rtbDescription.ForeColor = System.Drawing.Color.Gray;
        }

        private void AttachHoverEffects()
        {
            AddHover(btnSubmit, System.Drawing.Color.FromArgb(0, 153, 76), System.Drawing.Color.FromArgb(0, 128, 64));
            AddHover(btnAttach, System.Drawing.Color.WhiteSmoke, System.Drawing.Color.Gainsboro);
            AddHover(btnBack, System.Drawing.SystemColors.Control, System.Drawing.Color.Gainsboro);
        }

        private void AddHover(Button button, System.Drawing.Color normal, System.Drawing.Color hover)
        {
            button.MouseEnter += (s, e) => button.BackColor = hover;
            button.MouseLeave += (s, e) => button.BackColor = normal;
        }

        // --- Placeholder handling -------------------------------------------------

        private void txtLocation_Enter(object sender, EventArgs e)
        {
            if (txtLocation.Text == LocationPlaceholder && txtLocation.ForeColor == System.Drawing.Color.Gray)
            {
                txtLocation.Text = string.Empty;
                txtLocation.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void txtLocation_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtLocation.Text))
            {
                txtLocation.Text = LocationPlaceholder;
                txtLocation.ForeColor = System.Drawing.Color.Gray;
            }
        }

        private void rtbDescription_Enter(object sender, EventArgs e)
        {
            if (rtbDescription.Text == DescriptionPlaceholder && rtbDescription.ForeColor == System.Drawing.Color.Gray)
            {
                rtbDescription.Text = string.Empty;
                rtbDescription.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void rtbDescription_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(rtbDescription.Text))
            {
                rtbDescription.Text = DescriptionPlaceholder;
                rtbDescription.ForeColor = System.Drawing.Color.Gray;
            }
        }

        private string GetLocationValue() =>
            (txtLocation.Text == LocationPlaceholder && txtLocation.ForeColor == System.Drawing.Color.Gray)
                ? string.Empty : txtLocation.Text.Trim();

        private string GetDescriptionValue() =>
            (rtbDescription.Text == DescriptionPlaceholder && rtbDescription.ForeColor == System.Drawing.Color.Gray)
                ? string.Empty : rtbDescription.Text.Trim();

        // --- Field change / engagement feature -------------------------------------

        private void OnFieldChanged(object sender, EventArgs e)
        {
            UpdateEngagementFeedback();
        }

        private void btnAttach_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                foreach (var file in openFileDialog.FileNames)
                {
                    if (!_attachedFiles.Contains(file))
                    {
                        _attachedFiles.Add(file);
                        lstAttachments.Items.Add(System.IO.Path.GetFileName(file));
                    }
                }

                lblAttachments.Text = _attachedFiles.Count == 0
                    ? "No files attached"
                    : $"{_attachedFiles.Count} file(s) attached";

                UpdateEngagementFeedback();
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            var location = GetLocationValue();
            var category = cmbCategory.SelectedItem as string;
            var description = GetDescriptionValue();

            var missing = new List<string>();
            if (string.IsNullOrWhiteSpace(location)) missing.Add("Location");
            if (string.IsNullOrWhiteSpace(category)) missing.Add("Category");
            if (string.IsNullOrWhiteSpace(description)) missing.Add("Description");

            if (missing.Any())
            {
                MessageBox.Show(
                    $"Just a couple more things before we can send this off:\n\u2022 {string.Join("\n\u2022 ", missing)}",
                    "Almost there",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            var request = IssueRepository.Add(UserSession.CurrentUser.Username, location, category, description, new List<string>(_attachedFiles));

            MessageBox.Show(
                $"Thanks, {UserSession.FriendlyName}! Your report is in. \uD83C\uDF89\n\n" +
                $"Reference number: #{request.Id}\n" +
                $"Category: {request.Category}\n" +
                $"Location: {request.Location}\n\n" +
                "You'll be able to track its status once the Service Request Status " +
                "feature is switched on \u2014 we appreciate you taking the time to report this.",
                "Report Submitted",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            ResetForm();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Core of the engagement feature: works out how many of the required
        /// fields are complete, updates the ProgressBar (value + colour state)
        /// accordingly, toggles the green checkmarks, updates the live character
        /// count, and shows an encouraging message that matches the current stage.
        /// </summary>
        private void UpdateEngagementFeedback()
        {
            bool hasLocation = !string.IsNullOrWhiteSpace(GetLocationValue());
            bool hasCategory = cmbCategory.SelectedItem != null;
            bool hasDescription = !string.IsNullOrWhiteSpace(GetDescriptionValue());

            lblLocationCheck.Visible = hasLocation;
            lblCategoryCheck.Visible = hasCategory;
            lblDescriptionCheck.Visible = hasDescription;

            int descriptionLength = GetDescriptionValue().Length;
            lblCharCount.Text = $"{descriptionLength} character{(descriptionLength == 1 ? "" : "s")}";

            int completed = new[] { hasLocation, hasCategory, hasDescription }.Count(x => x);
            int percentage = (int)((completed / (double)TotalRequiredFields) * 100);
            progressBar.Value = Math.Max(progressBar.Minimum, Math.Min(progressBar.Maximum, percentage));

            // Colour the progress bar: amber while the report is incomplete,
            // green once every required field is filled in. Falls back
            // gracefully (no colour change) on systems where the message
            // isn't honoured, since Value/Text feedback still works either way.
            try
            {
                int state = completed == TotalRequiredFields ? PBST_NORMAL : PBST_PAUSED;
                SendMessage(progressBar.Handle, PBM_SETSTATE, (IntPtr)state, IntPtr.Zero);
            }
            catch (Exception)
            {
                // Non-Windows or restricted environment — ignore, purely cosmetic.
            }

            string message;
            if (completed == 0)
            {
                message = $"Hi {UserSession.FriendlyName}! Let's get your issue reported \u2014 start with the location.";
            }
            else if (completed < TotalRequiredFields)
            {
                message = $"Nice work \u2014 {completed} of {TotalRequiredFields} required fields done. Keep going!";
            }
            else if (_attachedFiles.Count == 0)
            {
                message = "All set! Everything required is filled in \u2014 add a photo if you have one, or submit now.";
            }
            else
            {
                message = "Looking great \u2014 click Submit to send this to the municipality. Thank you for helping your community!";
            }

            lblEngagement.Text = message;
        }

        private void ResetForm()
        {
            txtLocation.Text = LocationPlaceholder;
            txtLocation.ForeColor = System.Drawing.Color.Gray;
            cmbCategory.SelectedIndex = -1;
            rtbDescription.Text = DescriptionPlaceholder;
            rtbDescription.ForeColor = System.Drawing.Color.Gray;
            _attachedFiles.Clear();
            lstAttachments.Items.Clear();
            lblAttachments.Text = "No files attached";
            UpdateEngagementFeedback();
        }
    }
}
