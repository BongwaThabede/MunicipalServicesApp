using System;
using System.Windows.Forms;
using MunicipalServicesApp.Data;

namespace MunicipalServicesApp
{
    /// <summary>
    /// Entry point of the application's UI. Residents log in or register
    /// here; a seeded municipal staff account is also validated through
    /// this same screen, and routed to the municipal dashboard on success.
    /// </summary>
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            lblError.Text = string.Empty;

            var username = txtUsername.Text.Trim();
            var password = txtPassword.Text;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                lblError.Text = "Please enter both a username and a password.";
                return;
            }

            var account = UserRepository.ValidateLogin(username, password);
            if (account == null)
            {
                lblError.Text = "Incorrect username or password. Please try again.";
                txtPassword.Clear();
                txtPassword.Focus();
                return;
            }

            UserSession.CurrentUser = account;
            this.Hide();

            if (account.Role == MunicipalServicesApp.Models.UserRole.Municipal)
            {
                using (var dashboard = new MunicipalDashboardForm())
                {
                    dashboard.ShowDialog();
                }
            }
            else
            {
                using (var mainMenu = new MainMenuForm())
                {
                    mainMenu.ShowDialog();
                }
            }

            UserSession.LogOut();
            txtUsername.Clear();
            txtPassword.Clear();
            this.Show();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            using (var registerForm = new RegisterForm())
            {
                if (registerForm.ShowDialog(this) == DialogResult.OK)
                {
                    lblError.ForeColor = System.Drawing.Color.SeaGreen;
                    lblError.Text = "Account created! You can now log in below.";
                    txtUsername.Text = registerForm.RegisteredUsername;
                    txtPassword.Focus();
                }
            }
        }
    }
}
