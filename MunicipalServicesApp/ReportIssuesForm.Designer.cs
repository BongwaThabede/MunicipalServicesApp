namespace MunicipalServicesApp
{
    partial class ReportIssuesForm
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

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.TextBox txtLocation;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.RichTextBox rtbDescription;
        private System.Windows.Forms.Button btnAttach;
        private System.Windows.Forms.ListBox lstAttachments;
        private System.Windows.Forms.Label lblAttachments;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label lblEngagement;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Label lblLocationCheck;
        private System.Windows.Forms.Label lblCategoryCheck;
        private System.Windows.Forms.Label lblDescriptionCheck;
        private System.Windows.Forms.Label lblCharCount;

        private void InitializeComponent()
        {
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblLocation = new System.Windows.Forms.Label();
            this.txtLocation = new System.Windows.Forms.TextBox();
            this.lblCategory = new System.Windows.Forms.Label();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.rtbDescription = new System.Windows.Forms.RichTextBox();
            this.btnAttach = new System.Windows.Forms.Button();
            this.lstAttachments = new System.Windows.Forms.ListBox();
            this.lblAttachments = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.lblEngagement = new System.Windows.Forms.Label();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.toolTip = new System.Windows.Forms.ToolTip();
            this.lblLocationCheck = new System.Windows.Forms.Label();
            this.lblCategoryCheck = new System.Windows.Forms.Label();
            this.lblDescriptionCheck = new System.Windows.Forms.Label();
            this.lblCharCount = new System.Windows.Forms.Label();
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
            this.lblTitle.Text = "Report an Issue";

            // lblLocation
            this.lblLocation.AutoSize = true;
            this.lblLocation.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblLocation.Location = new System.Drawing.Point(30, 80);
            this.lblLocation.Text = "Location *";

            // txtLocation
            this.txtLocation.Location = new System.Drawing.Point(30, 100);
            this.txtLocation.Size = new System.Drawing.Size(440, 25);
            this.txtLocation.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.toolTip.SetToolTip(this.txtLocation, "E.g. street address, suburb, or nearest landmark");
            this.txtLocation.TextChanged += new System.EventHandler(this.OnFieldChanged);
            this.txtLocation.Enter += new System.EventHandler(this.txtLocation_Enter);
            this.txtLocation.Leave += new System.EventHandler(this.txtLocation_Leave);

            // lblLocationCheck
            this.lblLocationCheck.AutoSize = true;
            this.lblLocationCheck.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblLocationCheck.ForeColor = System.Drawing.Color.SeaGreen;
            this.lblLocationCheck.Location = new System.Drawing.Point(478, 100);
            this.lblLocationCheck.Text = "\u2713";
            this.lblLocationCheck.Visible = false;

            // lblCategory
            this.lblCategory.AutoSize = true;
            this.lblCategory.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblCategory.Location = new System.Drawing.Point(30, 138);
            this.lblCategory.Text = "Category *";

            // cmbCategory
            this.cmbCategory.Location = new System.Drawing.Point(30, 158);
            this.cmbCategory.Size = new System.Drawing.Size(280, 25);
            this.cmbCategory.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategory.Items.AddRange(new object[] {
                "Sanitation",
                "Roads and Potholes",
                "Water and Utilities",
                "Electricity",
                "Waste Management",
                "Public Safety",
                "Parks and Recreation",
                "Other"});
            this.cmbCategory.SelectedIndexChanged += new System.EventHandler(this.OnFieldChanged);

            // lblCategoryCheck
            this.lblCategoryCheck.AutoSize = true;
            this.lblCategoryCheck.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblCategoryCheck.ForeColor = System.Drawing.Color.SeaGreen;
            this.lblCategoryCheck.Location = new System.Drawing.Point(318, 158);
            this.lblCategoryCheck.Text = "\u2713";
            this.lblCategoryCheck.Visible = false;

            // lblDescription
            this.lblDescription.AutoSize = true;
            this.lblDescription.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblDescription.Location = new System.Drawing.Point(30, 196);
            this.lblDescription.Text = "Description *";

            // rtbDescription
            this.rtbDescription.Location = new System.Drawing.Point(30, 216);
            this.rtbDescription.Size = new System.Drawing.Size(480, 90);
            this.rtbDescription.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.toolTip.SetToolTip(this.rtbDescription, "Describe the issue in as much detail as possible");
            this.rtbDescription.TextChanged += new System.EventHandler(this.OnFieldChanged);
            this.rtbDescription.Enter += new System.EventHandler(this.rtbDescription_Enter);
            this.rtbDescription.Leave += new System.EventHandler(this.rtbDescription_Leave);

            // lblDescriptionCheck
            this.lblDescriptionCheck.AutoSize = true;
            this.lblDescriptionCheck.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblDescriptionCheck.ForeColor = System.Drawing.Color.SeaGreen;
            this.lblDescriptionCheck.Location = new System.Drawing.Point(478, 196);
            this.lblDescriptionCheck.Text = "\u2713";
            this.lblDescriptionCheck.Visible = false;

            // lblCharCount
            this.lblCharCount.AutoSize = true;
            this.lblCharCount.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblCharCount.ForeColor = System.Drawing.Color.Gray;
            this.lblCharCount.Location = new System.Drawing.Point(430, 308);
            this.lblCharCount.Text = "0 characters";

            // btnAttach
            this.btnAttach.Location = new System.Drawing.Point(30, 328);
            this.btnAttach.Size = new System.Drawing.Size(180, 32);
            this.btnAttach.Text = "Attach Image / Document";
            this.btnAttach.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnAttach.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAttach.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnAttach.Click += new System.EventHandler(this.btnAttach_Click);

            // lblAttachments
            this.lblAttachments.AutoSize = true;
            this.lblAttachments.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblAttachments.ForeColor = System.Drawing.Color.DimGray;
            this.lblAttachments.Location = new System.Drawing.Point(220, 337);
            this.lblAttachments.Text = "No files attached";

            // lstAttachments
            this.lstAttachments.Location = new System.Drawing.Point(30, 366);
            this.lstAttachments.Size = new System.Drawing.Size(480, 56);
            this.lstAttachments.Font = new System.Drawing.Font("Segoe UI", 8.5F);

            // progressBar
            this.progressBar.Location = new System.Drawing.Point(30, 434);
            this.progressBar.Size = new System.Drawing.Size(480, 20);
            this.progressBar.Minimum = 0;
            this.progressBar.Maximum = 100;
            this.progressBar.Value = 0;
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;

            // lblEngagement
            this.lblEngagement.AutoSize = true;
            this.lblEngagement.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
            this.lblEngagement.ForeColor = System.Drawing.Color.FromArgb(0, 120, 60);
            this.lblEngagement.Location = new System.Drawing.Point(30, 460);
            this.lblEngagement.Size = new System.Drawing.Size(480, 20);
            this.lblEngagement.Text = "Let's get started \u2014 fill in the details below to report your issue.";

            // btnSubmit
            this.btnSubmit.Location = new System.Drawing.Point(30, 494);
            this.btnSubmit.Size = new System.Drawing.Size(150, 38);
            this.btnSubmit.Text = "Submit Report";
            this.btnSubmit.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSubmit.BackColor = System.Drawing.Color.FromArgb(0, 153, 76);
            this.btnSubmit.ForeColor = System.Drawing.Color.White;
            this.btnSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubmit.FlatAppearance.BorderSize = 0;
            this.btnSubmit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);

            // btnBack
            this.btnBack.Location = new System.Drawing.Point(360, 494);
            this.btnBack.Size = new System.Drawing.Size(150, 38);
            this.btnBack.Text = "Back to Main Menu";
            this.btnBack.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);

            // openFileDialog
            this.openFileDialog.Multiselect = true;
            this.openFileDialog.Title = "Select images or documents related to the issue";
            this.openFileDialog.Filter = "Supported files (*.jpg;*.jpeg;*.png;*.pdf;*.docx;*.txt)|*.jpg;*.jpeg;*.png;*.pdf;*.docx;*.txt|All files (*.*)|*.*";

            // ReportIssuesForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(540, 556);
            this.MinimumSize = new System.Drawing.Size(556, 595);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.lblEngagement);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.lblCharCount);
            this.Controls.Add(this.lstAttachments);
            this.Controls.Add(this.lblAttachments);
            this.Controls.Add(this.btnAttach);
            this.Controls.Add(this.lblDescriptionCheck);
            this.Controls.Add(this.rtbDescription);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lblCategoryCheck);
            this.Controls.Add(this.cmbCategory);
            this.Controls.Add(this.lblCategory);
            this.Controls.Add(this.lblLocationCheck);
            this.Controls.Add(this.txtLocation);
            this.Controls.Add(this.lblLocation);
            this.Controls.Add(this.pnlHeader);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Report Issues \u2014 Municipal Services Application";
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
