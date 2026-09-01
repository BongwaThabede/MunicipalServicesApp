namespace MunicipalServicesApp
{
    partial class ServiceRequestStatusForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.DataGridView grid;
        private System.Windows.Forms.Label lblTimelineTitle;
        private System.Windows.Forms.RichTextBox rtbTimeline;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Label lblEmpty;

        private void InitializeComponent()
        {
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.grid = new System.Windows.Forms.DataGridView();
            this.lblTimelineTitle = new System.Windows.Forms.Label();
            this.rtbTimeline = new System.Windows.Forms.RichTextBox();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.lblEmpty = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.pnlHeader.SuspendLayout();
            this.SuspendLayout();

            // pnlHeader
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(0, 90, 156);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Height = 60;
            this.pnlHeader.Controls.Add(this.lblTitle);

            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(24, 16);
            this.lblTitle.Text = "My Service Requests";

            // grid
            this.grid.Location = new System.Drawing.Point(20, 76);
            this.grid.Size = new System.Drawing.Size(640, 200);
            this.grid.AllowUserToAddRows = false;
            this.grid.AllowUserToDeleteRows = false;
            this.grid.ReadOnly = true;
            this.grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid.MultiSelect = false;
            this.grid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grid.RowHeadersVisible = false;
            this.grid.BackgroundColor = System.Drawing.Color.White;
            this.grid.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.grid.SelectionChanged += new System.EventHandler(this.grid_SelectionChanged);

            // lblEmpty
            this.lblEmpty.AutoSize = false;
            this.lblEmpty.Size = new System.Drawing.Size(640, 40);
            this.lblEmpty.Location = new System.Drawing.Point(20, 90);
            this.lblEmpty.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblEmpty.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Italic);
            this.lblEmpty.ForeColor = System.Drawing.Color.Gray;
            this.lblEmpty.Text = "You haven't reported any issues yet \u2014 go to \"Report Issues\" to submit your first one.";
            this.lblEmpty.Visible = false;

            // lblTimelineTitle
            this.lblTimelineTitle.AutoSize = true;
            this.lblTimelineTitle.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblTimelineTitle.Location = new System.Drawing.Point(20, 288);
            this.lblTimelineTitle.Text = "Status history and feedback \u2014 select a request above";

            // rtbTimeline
            this.rtbTimeline.Location = new System.Drawing.Point(20, 310);
            this.rtbTimeline.Size = new System.Drawing.Size(640, 140);
            this.rtbTimeline.ReadOnly = true;
            this.rtbTimeline.BackColor = System.Drawing.Color.WhiteSmoke;
            this.rtbTimeline.Font = new System.Drawing.Font("Segoe UI", 9.5F);

            // btnRefresh
            this.btnRefresh.Location = new System.Drawing.Point(20, 460);
            this.btnRefresh.Size = new System.Drawing.Size(130, 34);
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);

            // btnBack
            this.btnBack.Location = new System.Drawing.Point(530, 460);
            this.btnBack.Size = new System.Drawing.Size(130, 34);
            this.btnBack.Text = "Back to Main Menu";
            this.btnBack.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);

            // ServiceRequestStatusForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(680, 512);
            this.MinimumSize = new System.Drawing.Size(696, 551);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.rtbTimeline);
            this.Controls.Add(this.lblTimelineTitle);
            this.Controls.Add(this.lblEmpty);
            this.Controls.Add(this.grid);
            this.Controls.Add(this.pnlHeader);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Track My Service Requests";
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.ResumeLayout(false);
        }
    }
}
