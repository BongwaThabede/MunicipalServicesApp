using System;
using System.Windows.Forms;
using MunicipalServicesApp.Data;

namespace MunicipalServicesApp
{
    /// <summary>
    /// Resident self-registration. New accounts are always created with
    /// the Resident role — municipal staff accounts are provisioned
    /// separately (see UserRepository's seeded demo account).
    /// </summary>
    public partial class RegisterForm : Form
    {
        public string RegisteredUsername { get; private set; } = string.Empty;

        public RegisterForm()
        {
            InitializeComponent();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            lblError.Text = string.Empty;

            var fullName = txtFullName.Text.Trim();
            var username = txtUsername.Text.Trim();
            var password = txtPassword.Text;
            var confirm = txtConfirm.Text;

            if (password != confirm)
            {
                lblError.Text = "Passwords do not match. Please try again.";
                return;
            }

            var account = UserRepository.Register(username, fullName, password, out string error);
            if (account == null)
            {
                lblError.Text = error;
                return;
            }

            RegisteredUsername = account.Username;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
