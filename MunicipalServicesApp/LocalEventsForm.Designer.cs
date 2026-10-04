namespace MunicipalServicesApp
{
    partial class LocalEventsForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private System.Windows.Forms.DataGridView dgvEvents;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ListBox lstRecommendations;
        private System.Windows.Forms.ListBox lstRecentlyViewed;

        // NEW: Date Search Controls
        private System.Windows.Forms.Label lblDateSearch;
        private System.Windows.Forms.DateTimePicker dtpSearchDate;

        // NEW: Edit/Delete Controls
        private System.Windows.Forms.Button btnEditEvent;
        private System.Windows.Forms.Button btnDeleteEvent;

        private void InitializeComponent()
        {
            this.dgvEvents = new System.Windows.Forms.DataGridView();
            this.lblSearch = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblCategory = new System.Windows.Forms.Label();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.lstRecommendations = new System.Windows.Forms.ListBox();
            this.lstRecentlyViewed = new System.Windows.Forms.ListBox();
            this.lblDateSearch = new System.Windows.Forms.Label();
            this.dtpSearchDate = new System.Windows.Forms.DateTimePicker();
            this.btnEditEvent = new System.Windows.Forms.Button();
            this.btnDeleteEvent = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEvents)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvEvents
            // 
            this.dgvEvents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEvents.Location = new System.Drawing.Point(24, 19);
            this.dgvEvents.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.dgvEvents.Name = "dgvEvents";
            this.dgvEvents.RowHeadersWidth = 51;
            this.dgvEvents.Size = new System.Drawing.Size(1520, 465);
            this.dgvEvents.TabIndex = 0;
            this.dgvEvents.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEvents_CellClick);
            this.dgvEvents.SelectionChanged += new System.EventHandler(this.dgvEvents_SelectionChanged);
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblSearch.Location = new System.Drawing.Point(24, 511);
            this.lblSearch.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(119, 41);
            this.lblSearch.TabIndex = 1;
            this.lblSearch.Text = "Search:";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(144, 507);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(396, 38);
            this.txtSearch.TabIndex = 2;
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblCategory.Location = new System.Drawing.Point(580, 511);
            this.lblCategory.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(155, 41);
            this.lblCategory.TabIndex = 3;
            this.lblCategory.Text = "Category:";
            // 
            // cmbCategory
            // 
            this.cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.Location = new System.Drawing.Point(740, 507);
            this.cmbCategory.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(296, 39);
            this.cmbCategory.TabIndex = 4;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(1280, 558);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(264, 54);
            this.btnSearch.TabIndex = 6;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // lstRecommendations
            // 
            this.lstRecommendations.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lstRecommendations.FormattingEnabled = true;
            this.lstRecommendations.ItemHeight = 41;
            this.lstRecommendations.Location = new System.Drawing.Point(24, 636);
            this.lstRecommendations.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.lstRecommendations.Name = "lstRecommendations";
            this.lstRecommendations.Size = new System.Drawing.Size(736, 168);
            this.lstRecommendations.TabIndex = 7;
            // 
            // lstRecentlyViewed
            // 
            this.lstRecentlyViewed.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lstRecentlyViewed.FormattingEnabled = true;
            this.lstRecentlyViewed.ItemHeight = 41;
            this.lstRecentlyViewed.Location = new System.Drawing.Point(800, 636);
            this.lstRecentlyViewed.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.lstRecentlyViewed.Name = "lstRecentlyViewed";
            this.lstRecentlyViewed.Size = new System.Drawing.Size(740, 168);
            this.lstRecentlyViewed.TabIndex = 8;
            // 
            // lblDateSearch
            // 
            this.lblDateSearch.AutoSize = true;
            this.lblDateSearch.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblDateSearch.Location = new System.Drawing.Point(1080, 511);
            this.lblDateSearch.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblDateSearch.Name = "lblDateSearch";
            this.lblDateSearch.Size = new System.Drawing.Size(92, 41);
            this.lblDateSearch.TabIndex = 11;
            this.lblDateSearch.Text = "Date:";
            // 
            // dtpSearchDate
            // 
            this.dtpSearchDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpSearchDate.Location = new System.Drawing.Point(1180, 507);
            this.dtpSearchDate.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.dtpSearchDate.Name = "dtpSearchDate";
            this.dtpSearchDate.Size = new System.Drawing.Size(256, 38);
            this.dtpSearchDate.TabIndex = 5;
            this.dtpSearchDate.Value = new System.DateTime(2026, 10, 4, 12, 22, 22, 357);
            // 
            // btnEditEvent
            // 
            this.btnEditEvent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(165)))), ((int)(((byte)(0)))));
            this.btnEditEvent.Enabled = false;
            this.btnEditEvent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditEvent.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnEditEvent.ForeColor = System.Drawing.Color.White;
            this.btnEditEvent.Location = new System.Drawing.Point(24, 852);
            this.btnEditEvent.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnEditEvent.Name = "btnEditEvent";
            this.btnEditEvent.Size = new System.Drawing.Size(240, 54);
            this.btnEditEvent.TabIndex = 9;
            this.btnEditEvent.Text = "Edit Event";
            this.btnEditEvent.UseVisualStyleBackColor = false;
            this.btnEditEvent.Click += new System.EventHandler(this.btnEditEvent_Click);
            // 
            // btnDeleteEvent
            // 
            this.btnDeleteEvent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnDeleteEvent.Enabled = false;
            this.btnDeleteEvent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteEvent.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnDeleteEvent.ForeColor = System.Drawing.Color.White;
            this.btnDeleteEvent.Location = new System.Drawing.Point(290, 852);
            this.btnDeleteEvent.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnDeleteEvent.Name = "btnDeleteEvent";
            this.btnDeleteEvent.Size = new System.Drawing.Size(240, 54);
            this.btnDeleteEvent.TabIndex = 10;
            this.btnDeleteEvent.Text = "Delete Event";
            this.btnDeleteEvent.UseVisualStyleBackColor = false;
            this.btnDeleteEvent.Click += new System.EventHandler(this.btnDeleteEvent_Click);
            // 
            // LocalEventsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1568, 930);
            this.Controls.Add(this.btnDeleteEvent);
            this.Controls.Add(this.btnEditEvent);
            this.Controls.Add(this.lstRecentlyViewed);
            this.Controls.Add(this.lstRecommendations);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.dtpSearchDate);
            this.Controls.Add(this.lblDateSearch);
            this.Controls.Add(this.cmbCategory);
            this.Controls.Add(this.lblCategory);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.lblSearch);
            this.Controls.Add(this.dgvEvents);
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.Name = "LocalEventsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Madibeng Municipality - Local Events";
            this.Load += new System.EventHandler(this.LocalEventsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEvents)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}