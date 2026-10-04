using System;
using System.Drawing;
using System.Windows.Forms;

namespace MunicipalServicesApp
{
    internal class EditEventForm : Form
    {
        private MunicipalEvent originalEvent;

        private TextBox txtTitle;
        private TextBox txtCategory;
        private DateTimePicker dtpDate;
        private TextBox txtLocation;
        private TextBox txtDescription;
        private NumericUpDown nudPriority;
        private Button btnOk;
        private Button btnCancel;

        public MunicipalEvent UpdatedEvent { get; private set; }

        public EditEventForm(MunicipalEvent evt)
        {
            originalEvent = evt;
            InitializeComponents();
            LoadEventValues(evt);
        }

        private void InitializeComponents()
        {
            this.Text = "Edit Event";
            this.Size = new Size(400, 400);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterParent;
            this.MaximizeBox = false;

            var lblTitle = new Label { Text = "Title:", Left = 10, Top = 10, Width = 80 };
            txtTitle = new TextBox { Left = 100, Top = 10, Width = 260 };

            var lblCategory = new Label { Text = "Category:", Left = 10, Top = 40, Width = 80 };
            txtCategory = new TextBox { Left = 100, Top = 40, Width = 260 };

            var lblDate = new Label { Text = "Date:", Left = 10, Top = 70, Width = 80 };
            dtpDate = new DateTimePicker { Left = 100, Top = 70, Width = 260, Format = DateTimePickerFormat.Short };

            var lblLocation = new Label { Text = "Location:", Left = 10, Top = 100, Width = 80 };
            txtLocation = new TextBox { Left = 100, Top = 100, Width = 260 };

            var lblDescription = new Label { Text = "Description:", Left = 10, Top = 130, Width = 80 };
            txtDescription = new TextBox { Left = 100, Top = 130, Width = 260, Height = 100, Multiline = true, ScrollBars = ScrollBars.Vertical };

            var lblPriority = new Label { Text = "Priority (1=Urgent):", Left = 10, Top = 240, Width = 120 };
            nudPriority = new NumericUpDown { Left = 140, Top = 238, Width = 60, Minimum = 1, Maximum = 3 };

            btnOk = new Button { Text = "OK", Left = 200, Width = 80, Top = 280, DialogResult = DialogResult.OK };
            btnCancel = new Button { Text = "Cancel", Left = 290, Width = 80, Top = 280, DialogResult = DialogResult.Cancel };

            btnOk.Click += BtnOk_Click;

            this.Controls.Add(lblTitle);
            this.Controls.Add(txtTitle);
            this.Controls.Add(lblCategory);
            this.Controls.Add(txtCategory);
            this.Controls.Add(lblDate);
            this.Controls.Add(dtpDate);
            this.Controls.Add(lblLocation);
            this.Controls.Add(txtLocation);
            this.Controls.Add(lblDescription);
            this.Controls.Add(txtDescription);
            this.Controls.Add(lblPriority);
            this.Controls.Add(nudPriority);
            this.Controls.Add(btnOk);
            this.Controls.Add(btnCancel);

            this.AcceptButton = btnOk;
            this.CancelButton = btnCancel;
        }

        private void LoadEventValues(MunicipalEvent evt)
        {
            if (evt == null) return;
            txtTitle.Text = evt.Title;
            txtCategory.Text = evt.Category;
            dtpDate.Value = evt.EventDate;
            txtLocation.Text = evt.Location;
            txtDescription.Text = evt.Description;
            nudPriority.Value = Math.Max(nudPriority.Minimum, Math.Min(nudPriority.Maximum, evt.Priority));
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            UpdatedEvent = new MunicipalEvent
            {
                EventID = originalEvent.EventID,
                Title = txtTitle.Text,
                Category = txtCategory.Text,
                EventDate = dtpDate.Value.Date,
                Location = txtLocation.Text,
                Description = txtDescription.Text,
                Priority = (int)nudPriority.Value
            };

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // EditEventForm
            // 
            this.ClientSize = new System.Drawing.Size(292, 212);
            this.Name = "EditEventForm";
            this.Load += new System.EventHandler(this.EditEventForm_Load);
            this.ResumeLayout(false);

        }

        private void EditEventForm_Load(object sender, EventArgs e)
        {

        }
    }
}
