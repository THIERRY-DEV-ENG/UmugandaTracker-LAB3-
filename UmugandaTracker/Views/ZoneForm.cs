using System;
using System.Windows.Forms;
using UmugandaTracker.Controllers;
using UmugandaTracker.Models;

namespace UmugandaTracker.Views
{
    public partial class ZoneForm : Form
    {
        private readonly ZoneController _ctrl = new ZoneController();
        private int _selectedZoneID = 0;

        public ZoneForm()
        {
            InitializeComponent();
            dgvZones.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                dgvZones.DataSource = null;
                dgvZones.DataSource = _ctrl.GetAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading zones: " + ex.Message);
            }
        }

        private void dgvZones_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataGridViewRow row = dgvZones.Rows[e.RowIndex];
            _selectedZoneID = Convert.ToInt32(row.Cells["ZoneID"].Value);
            txtZoneName.Text = Convert.ToString(row.Cells["ZoneName"].Value);
            txtLocation.Text = Convert.ToString(row.Cells["Location"].Value);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtZoneName.Text) || string.IsNullOrWhiteSpace(txtLocation.Text))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            try
            {
                Zone newZone = new Zone
                {
                    ZoneName = txtZoneName.Text.Trim(),
                    Location = txtLocation.Text.Trim()
                };

                _ctrl.Add(newZone);
                MessageBox.Show("Zone saved successfully.");
                LoadData();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving zone: " + ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (_selectedZoneID <= 0)
            {
                MessageBox.Show("Select a zone from the table first.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtZoneName.Text) || string.IsNullOrWhiteSpace(txtLocation.Text))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            try
            {
                Zone zone = new Zone
                {
                    ZoneID = _selectedZoneID,
                    ZoneName = txtZoneName.Text.Trim(),
                    Location = txtLocation.Text.Trim()
                };

                _ctrl.Update(zone);
                MessageBox.Show("Zone updated successfully.");
                LoadData();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating zone: " + ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_selectedZoneID <= 0)
            {
                MessageBox.Show("Select a zone from the table first.");
                return;
            }

            if (MessageBox.Show("Are you sure you want to delete this zone?", "Confirm",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                return;

            try
            {
                _ctrl.Delete(_selectedZoneID);
                MessageBox.Show("Zone deleted successfully.");
                LoadData();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting zone: " + ex.Message);
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
                dgvZones.DataSource = null;
                dgvZones.DataSource = _ctrl.Search(txtSearch.Text.Trim());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error searching zones: " + ex.Message);
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
            _selectedZoneID = 0;
            txtZoneName.Clear();
            txtLocation.Clear();
            txtZoneName.Focus();
            dgvZones.ClearSelection();
        }
    }
}
