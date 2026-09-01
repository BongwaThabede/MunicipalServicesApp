namespace MunicipalServicesApp
{
    partial class MainMenuForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Button btnReportIssues;
        private System.Windows.Forms.Button btnLocalEvents;
        private System.Windows.Forms.Button btnServiceStatus;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblGreeting;
        private System.Windows.Forms.Label lblTip;
        private System.Windows.Forms.Timer tipTimer;
        private System.Windows.Forms.Button btnLogout;

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.btnReportIssues = new System.Windows.Forms.Button();
            this.btnLocalEvents = new System.Windows.Forms.Button();
            this.btnServiceStatus = new System.Windows.Forms.Button();
            this.components = new System.ComponentModel.Container();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblGreeting = new System.Windows.Forms.Label();
            this.lblTip = new System.Windows.Forms.Label();
            this.tipTimer = new System.Windows.Forms.Timer(this.components);
            this.btnLogout = new System.Windows.Forms.Button();
            this.pnlHeader.SuspendLayout();
            this.SuspendLayout();

            // pnlHeader
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(0, 90, 156);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Height = 90;
            this.pnlHeader.Controls.Add(this.lblSubtitle);
            this.pnlHeader.Controls.Add(this.lblTitle);

            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(24, 14);
            this.lblTitle.Text = "Municipal Services";

            // lblSubtitle
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblSubtitle.Location = new System.Drawing.Point(26, 52);
            this.lblSubtitle.Text = "Report issues, view events and track your requests";

            // lblGreeting
            this.lblGreeting.AutoSize = true;
            this.lblGreeting.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblGreeting.ForeColor = System.Drawing.Color.FromArgb(0, 90, 156);
            this.lblGreeting.Location = new System.Drawing.Point(40, 100);
            this.lblGreeting.Text = "Welcome!";

            // lblTip
            this.lblTip.AutoSize = false;
            this.lblTip.Size = new System.Drawing.Size(320, 34);
            this.lblTip.Font = new System.Drawing.Font("Segoe UI", 8.75F, System.Drawing.FontStyle.Italic);
            this.lblTip.ForeColor = System.Drawing.Color.DimGray;
            this.lblTip.Location = new System.Drawing.Point(40, 350);

            // tipTimer
            this.tipTimer.Interval = 5000;
            this.tipTimer.Tick += new System.EventHandler(this.tipTimer_Tick);

            // btnReportIssues
            this.btnReportIssues.Location = new System.Drawing.Point(40, 150);
            this.btnReportIssues.Size = new System.Drawing.Size(320, 60);
            this.btnReportIssues.Text = "Report Issues";
            this.btnReportIssues.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnReportIssues.BackColor = System.Drawing.Color.FromArgb(0, 120, 215);
            this.btnReportIssues.ForeColor = System.Drawing.Color.White;
            this.btnReportIssues.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReportIssues.FlatAppearance.BorderSize = 0;
            this.btnReportIssues.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReportIssues.Click += new System.EventHandler(this.btnReportIssues_Click);

            // btnLocalEvents
            this.btnLocalEvents.Location = new System.Drawing.Point(40, 225);
            this.btnLocalEvents.Size = new System.Drawing.Size(320, 60);
            this.btnLocalEvents.Text = "Local Events and Announcements\n(coming soon)";
            this.btnLocalEvents.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.btnLocalEvents.Enabled = false;
            this.btnLocalEvents.FlatStyle = System.Windows.Forms.FlatStyle.Flat;

            // btnServiceStatus
            this.btnServiceStatus.Location = new System.Drawing.Point(40, 300);
            this.btnServiceStatus.Size = new System.Drawing.Size(320, 60);
            this.btnServiceStatus.Text = "Track My Service Requests";
            this.btnServiceStatus.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnServiceStatus.BackColor = System.Drawing.Color.FromArgb(0, 153, 76);
            this.btnServiceStatus.ForeColor = System.Drawing.Color.White;
            this.btnServiceStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnServiceStatus.FlatAppearance.BorderSize = 0;
            this.btnServiceStatus.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnServiceStatus.Click += new System.EventHandler(this.btnServiceStatus_Click);

            // btnLogout
            this.btnLogout.Location = new System.Drawing.Point(290, 100);
            this.btnLogout.Size = new System.Drawing.Size(70, 26);
            this.btnLogout.Text = "Log Out";
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);

            // MainMenuForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 400);
            this.MinimumSize = new System.Drawing.Size(416, 439);
            this.Controls.Add(this.lblTip);
            this.Controls.Add(this.btnServiceStatus);
            this.Controls.Add(this.btnLocalEvents);
            this.Controls.Add(this.btnReportIssues);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.lblGreeting);
            this.Controls.Add(this.pnlHeader);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Municipal Services Application";
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.ResumeLayout(false);
        }
    }
}
