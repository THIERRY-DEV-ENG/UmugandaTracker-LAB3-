using System;
using System.Windows.Forms;
using UmugandaTracker.Controllers;
using UmugandaTracker.Models;

namespace UmugandaTracker.Views
{
    public partial class UserForm : Form
    {
        private readonly UserController _ctrl = new UserController();

        public UserForm()
        {
            InitializeComponent();
            if (cmbRole.Items.Count > 0)
            {
                cmbRole.SelectedIndex = 0;
            }
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                dgvUsers.AutoGenerateColumns = true;
                dgvUsers.DataSource = null;
                dgvUsers.DataSource = _ctrl.GetAll();
                dgvUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFullName.Text) ||
                string.IsNullOrWhiteSpace(txtUsername.Text) ||
                string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Fill all fields.");
                return;
            }

            try
            {
                User newUser = new User
                {
                    FullName = txtFullName.Text.Trim(),
                    Username = txtUsername.Text.Trim(),
                    Password = txtPassword.Text.Trim(),
                    Role = cmbRole.SelectedItem != null ? cmbRole.SelectedItem.ToString() : "Member"
                };

                _ctrl.Add(newUser);

                MessageBox.Show("User added successfully.");
                LoadData();

                txtFullName.Clear();
                txtUsername.Clear();
                txtPassword.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving user: " + ex.Message);
            }
        }
    }
}
