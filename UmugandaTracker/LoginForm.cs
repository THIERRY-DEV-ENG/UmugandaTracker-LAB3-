using System;
using System.Windows.Forms;
using UmugandaTracker.Controllers;
using UmugandaTracker.Models;

namespace UmugandaTracker.Views
{
    public partial class LoginForm : Form
    {
        private readonly AuthController _auth = new AuthController();

        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please enter username and password.");
                return;
            }

            User user = _auth.Login(username, password);

            if (user == null)
            {
                MessageBox.Show("Invalid username or password.");
                return;
            }

            MessageBox.Show("Login Successful! Welcome " + user.FullName);


            MainForm main = new MainForm(user);
            main.Show();
            this.Hide();
        }
    }
}