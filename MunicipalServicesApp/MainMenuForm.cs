using System;
using System.Windows.Forms;

namespace MunicipalServicesApp
{
    public partial class MainMenuForm : Form
    {
        private static readonly string[] Tips =
        {
            "Tip: the more specific your location, the faster your issue can be found.",
            "Did you know? You can attach a photo to help crews see the problem before they arrive.",
            "Tip: choosing the right category helps route your report to the correct department.",
            "Every report you submit helps the Madibeng Municipality prioritise where to act next.",
            "Tip: check back on \"Track My Service Requests\" to see any feedback from the municipality."
        };

        private int _tipIndex = 0;

        public MainMenuForm()
        {
            InitializeComponent();
            AttachHoverEffects();
            this.Load += (s, e) =>
            {
                UpdateGreeting();
                lblTip.Text = Tips[0];
            };
            tipTimer.Start();
        }

        private void UpdateGreeting()
        {
            // Use UserSession helper properties (CurrentUser may be null)
            string name = UserSession.FriendlyName;
            string role = UserSession.Role;

            // Shows their name and role so you know it's working
            lblGreeting.Text = $"Welcome back, {name}! ({role}) \uD83D\uDC4B";
        }

        private void tipTimer_Tick(object sender, EventArgs e)
        {
            _tipIndex = (_tipIndex + 1) % Tips.Length;
            lblTip.Text = Tips[_tipIndex];
        }

        private void AttachHoverEffects()
        {
            AddHover(btnReportIssues, System.Drawing.Color.FromArgb(0, 120, 215), System.Drawing.Color.FromArgb(0, 99, 177));
            AddHover(btnServiceStatus, System.Drawing.Color.FromArgb(0, 153, 76), System.Drawing.Color.FromArgb(0, 128, 64));
            AddHover(btnLocalEvents, System.Drawing.Color.FromArgb(128, 0, 128), System.Drawing.Color.FromArgb(100, 0, 100));
        }

        private void AddHover(Button button, System.Drawing.Color normal, System.Drawing.Color hover)
        {
            button.MouseEnter += (s, e) => button.BackColor = hover;
            button.MouseLeave += (s, e) => button.BackColor = normal;
        }

        private void btnReportIssues_Click(object sender, EventArgs e)
        {
            using (var reportForm = new ReportIssuesForm())
            {
                this.Hide();
                reportForm.ShowDialog();
                this.Show();
            }
        }

        private void btnLocalEvents_Click(object sender, EventArgs e)
        {
            using (var eventsForm = new LocalEventsForm())
            {
                this.Hide();
                eventsForm.ShowDialog();
                this.Show();
                UpdateGreeting();
            }
        }

        private void btnServiceStatus_Click(object sender, EventArgs e)
        {
            using (var statusForm = new ServiceRequestStatusForm())
            {
                this.Hide();
                statusForm.ShowDialog();
                this.Show();
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MainMenuForm_Load(object sender, EventArgs e) { }
    }
}