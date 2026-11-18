using System;
using System.Windows.Forms;
using UmugandaTracker.Controllers;
using UmugandaTracker.Models;

namespace UmugandaTracker.Views
{
    public partial class UserForm : Form
    {
        private readonly UserController _ctrl = new UserController();
        private int _selectedUserID = 0;

        public UserForm()
        {
            InitializeComponent();
            dgvUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
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
                dgvUsers.DataSource = null;
                dgvUsers.DataSource = _ctrl.GetAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading users: " + ex.Message);
            }
        }

        private void dgvUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataGridViewRow row = dgvUsers.Rows[e.RowIndex];
            _selectedUserID = Convert.ToInt32(row.Cells["UserID"].Value);
            txtFullName.Text = Convert.ToString(row.Cells["FullName"].Value);
            txtUsername.Text = Convert.ToString(row.Cells["Username"].Value);
            txtPassword.Text = Convert.ToString(row.Cells["Password"].Value);
            cmbRole.SelectedItem = Convert.ToString(row.Cells["Role"].Value);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFullName.Text) ||
                string.IsNullOrWhiteSpace(txtUsername.Text) ||
                string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Please fill in all fields.");
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
                MessageBox.Show("User saved successfully.");
                LoadData();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving user: " + ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (_selectedUserID <= 0)
            {
                MessageBox.Show("Select a user from the table first.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtFullName.Text) ||
                string.IsNullOrWhiteSpace(txtUsername.Text) ||
                string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            try
            {
                User user = new User
                {
                    UserID = _selectedUserID,
                    FullName = txtFullName.Text.Trim(),
                    Username = txtUsername.Text.Trim(),
                    Password = txtPassword.Text.Trim(),
                    Role = cmbRole.SelectedItem != null ? cmbRole.SelectedItem.ToString() : "Member"
                };

                _ctrl.Update(user);
                MessageBox.Show("User updated successfully.");
                LoadData();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating user: " + ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_selectedUserID <= 0)
            {
                MessageBox.Show("Select a user from the table first.");
                return;
            }

            if (MessageBox.Show("Are you sure you want to delete this user?", "Confirm",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                return;

            try
            {
                _ctrl.Delete(_selectedUserID);
                MessageBox.Show("User deleted successfully.");
                LoadData();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting user: " + ex.Message);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                LoadData();
                return;
            }

            try
            {
                dgvUsers.DataSource = null;
                dgvUsers.DataSource = _ctrl.Search(txtSearch.Text.Trim());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error searching users: " + ex.Message);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            LoadData();
            ClearFields();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void ClearFields()
        {
            _selectedUserID = 0;
            txtFullName.Clear();
            txtUsername.Clear();
            txtPassword.Clear();
            if (cmbRole.Items.Count > 0)
            {
                cmbRole.SelectedIndex = 0;
            }
            txtFullName.Focus();
            dgvUsers.ClearSelection();
        }
    }
}
