using System;
using System.Windows.Forms;
using UmugandaTracker.Controllers;
using UmugandaTracker.Models;

namespace UmugandaTracker.Views
{
    public partial class RegisterForm : Form
    {
        private readonly UserController _userCtrl = new UserController();

        public RegisterForm()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string fullName = txtFullName.Text.Trim();
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;
            string confirmPassword = txtConfirmPassword.Text;

            if (string.IsNullOrWhiteSpace(fullName) || string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please fill in all required fields.");
                return;
            }

            if (password != confirmPassword)
            {
                MessageBox.Show("Passwords do not match. Please re-enter.");
                return;
            }

            if (_userCtrl.UsernameExists(username))
            {
                MessageBox.Show("This username is already taken. Please choose a different one.");
                return;
            }

            try
            {
                User newCitizen = new User
                {
                    FullName = fullName,
                    Username = username,
                    Password = password,
                    Role = "Member"
                };

                _userCtrl.Add(newCitizen);

                MessageBox.Show("Registration successful! You can now log in with your credentials.");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error creating account: " + ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
