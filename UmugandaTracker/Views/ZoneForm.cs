using System;
using System.Windows.Forms;
using UmugandaTracker.Controllers;
using UmugandaTracker.Models;

namespace UmugandaTracker.Views
{
    public partial class ZoneForm : Form
    {
        private readonly ZoneController _ctrl = new ZoneController();

        public ZoneForm()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                dgvZones.AutoGenerateColumns = true;
                dgvZones.DataSource = null;
                dgvZones.DataSource = _ctrl.GetAll();
                dgvZones.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading zones: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtZoneName.Text) || string.IsNullOrWhiteSpace(txtLocation.Text))
                {
                    MessageBox.Show("Fill all fields.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Zone newZone = new Zone
                {
                    ZoneName = txtZoneName.Text.Trim(),
                    Location = txtLocation.Text.Trim()
                };

                _ctrl.Add(newZone);

                MessageBox.Show("Zone added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();

                txtZoneName.Clear();
                txtLocation.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving zone: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}