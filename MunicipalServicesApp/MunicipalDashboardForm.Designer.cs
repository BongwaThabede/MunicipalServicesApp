namespace MunicipalServicesApp
{
    partial class MunicipalDashboardForm
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
        private System.Windows.Forms.Label lblDetails;
        private System.Windows.Forms.RichTextBox rtbDetails;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Label lblFeedback;
        private System.Windows.Forms.TextBox txtFeedback;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Label lblEmpty;

        private void InitializeComponent()
        {
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.grid = new System.Windows.Forms.DataGridView();
            this.lblDetails = new System.Windows.Forms.Label();
            this.rtbDetails = new System.Windows.Forms.RichTextBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.lblFeedback = new System.Windows.Forms.Label();
            this.txtFeedback = new System.Windows.Forms.TextBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
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
            this.lblTitle.Text = "Municipal Dashboard \u2014 All Service Requests";

            // grid
            this.grid.Location = new System.Drawing.Point(20, 76);
            this.grid.Size = new System.Drawing.Size(760, 220);
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
            this.lblEmpty.Size = new System.Drawing.Size(760, 40);
            this.lblEmpty.Location = new System.Drawing.Point(20, 90);
            this.lblEmpty.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblEmpty.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Italic);
            this.lblEmpty.ForeColor = System.Drawing.Color.Gray;
            this.lblEmpty.Text = "No service requests have been submitted yet.";
            this.lblEmpty.Visible = false;

            // lblDetails
            this.lblDetails.AutoSize = true;
            this.lblDetails.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblDetails.Location = new System.Drawing.Point(20, 308);
            this.lblDetails.Text = "Details and history \u2014 select a request above";

            // rtbDetails
            this.rtbDetails.Location = new System.Drawing.Point(20, 330);
            this.rtbDetails.Size = new System.Drawing.Size(760, 130);
            this.rtbDetails.ReadOnly = true;
            this.rtbDetails.BackColor = System.Drawing.Color.WhiteSmoke;
            this.rtbDetails.Font = new System.Drawing.Font("Segoe UI", 9.5F);

            // lblStatus
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblStatus.Location = new System.Drawing.Point(20, 472);
            this.lblStatus.Text = "New status:";

            // cmbStatus
            this.cmbStatus.Location = new System.Drawing.Point(110, 468);
            this.cmbStatus.Size = new System.Drawing.Size(160, 25);
            this.cmbStatus.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            // lblFeedback
            this.lblFeedback.AutoSize = true;
            this.lblFeedback.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblFeedback.Location = new System.Drawing.Point(290, 472);
            this.lblFeedback.Text = "Feedback message:";

            // txtFeedback
            this.txtFeedback.Location = new System.Drawing.Point(410, 468);
            this.txtFeedback.Size = new System.Drawing.Size(370, 25);
            this.txtFeedback.Font = new System.Drawing.Font("Segoe UI", 9.5F);

            // btnUpdate
            this.btnUpdate.Location = new System.Drawing.Point(20, 505);
            this.btnUpdate.Size = new System.Drawing.Size(180, 36);
            this.btnUpdate.Text = "Update Status";
            this.btnUpdate.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnUpdate.BackColor = System.Drawing.Color.FromArgb(0, 120, 215);
            this.btnUpdate.ForeColor = System.Drawing.Color.White;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.FlatAppearance.BorderSize = 0;
            this.btnUpdate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);

            // btnLogout
            this.btnLogout.Location = new System.Drawing.Point(660, 505);
            this.btnLogout.Size = new System.Drawing.Size(120, 36);
            this.btnLogout.Text = "Log Out";
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);

            // MunicipalDashboardForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 560);
            this.MinimumSize = new System.Drawing.Size(816, 599);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.txtFeedback);
            this.Controls.Add(this.lblFeedback);
            this.Controls.Add(this.cmbStatus);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.rtbDetails);
            this.Controls.Add(this.lblDetails);
            this.Controls.Add(this.lblEmpty);
            this.Controls.Add(this.grid);
            this.Controls.Add(this.pnlHeader);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Municipal Dashboard";
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
