using System;
using System.Windows.Forms;
using UmugandaTracker.Controllers;
using UmugandaTracker.Models;

namespace UmugandaTracker.Views
{
    public partial class EventForm : Form
    {
        private readonly EventController _eventCtrl = new EventController();
        private readonly ZoneController _zoneCtrl = new ZoneController();
        private int _selectedEventID = 0;

        public EventForm()
        {
            InitializeComponent();
            LoadZones();
            LoadData();
        }

        private void LoadZones()
        {
            try
            {
                cmbZone.DataSource = _zoneCtrl.GetAll();
                cmbZone.DisplayMember = "ZoneName";
                cmbZone.ValueMember = "ZoneID";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading zones: " + ex.Message);
            }
        }

        private void LoadData()
        {
            try
            {
                dgvEvents.DataSource = null;
                dgvEvents.DataSource = _eventCtrl.GetAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading events: " + ex.Message);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEventName.Text) || cmbZone.SelectedValue == null)
            {
                MessageBox.Show("Please fill all fields and select a zone.");
                return;
            }

            try
            {
                UmugandaEvent newEvent = new UmugandaEvent
                {
                    EventName = txtEventName.Text.Trim(),
                    EventDate = dtpEventDate.Value.Date,
                    ZoneID = Convert.ToInt32(cmbZone.SelectedValue)
                };

                _eventCtrl.Add(newEvent);
                MessageBox.Show("Event added successfully.");
                ClearForm();
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving event: " + ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (_selectedEventID == 0)
            {
                MessageBox.Show("Please select an event from the list to update.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtEventName.Text) || cmbZone.SelectedValue == null)
            {
                MessageBox.Show("Please fill all fields and select a zone.");
                return;
            }

            try
            {
                UmugandaEvent ev = new UmugandaEvent
                {
                    EventID = _selectedEventID,
                    EventName = txtEventName.Text.Trim(),
                    EventDate = dtpEventDate.Value.Date,
                    ZoneID = Convert.ToInt32(cmbZone.SelectedValue)
                };

                _eventCtrl.Update(ev);
                MessageBox.Show("Event updated successfully.");
                ClearForm();
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating event: " + ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_selectedEventID == 0)
            {
                MessageBox.Show("Please select an event from the list to delete.");
                return;
            }

            DialogResult confirm = MessageBox.Show("Are you sure you want to delete this event?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm == DialogResult.Yes)
            {
                try
                {
                    _eventCtrl.Delete(_selectedEventID);
                    MessageBox.Show("Event deleted successfully.");
                    ClearForm();
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting event: " + ex.Message);
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim();
            if (string.IsNullOrWhiteSpace(keyword))
            {
                LoadData();
                return;
            }

            try
            {
                dgvEvents.DataSource = null;
                dgvEvents.DataSource = _eventCtrl.Search(keyword);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error searching events: " + ex.Message);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            ClearForm();
            LoadZones();
            LoadData();
        }

        private void dgvEvents_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvEvents.Rows[e.RowIndex].DataBoundItem != null)
            {
                var row = (UmugandaEvent)dgvEvents.Rows[e.RowIndex].DataBoundItem;
                _selectedEventID = row.EventID;
                txtEventName.Text = row.EventName;
                dtpEventDate.Value = row.EventDate;
                cmbZone.SelectedValue = row.ZoneID;
            }
        }

        private void ClearForm()
        {
            _selectedEventID = 0;
            txtEventName.Clear();
            dtpEventDate.Value = DateTime.Today;
            if (cmbZone.Items.Count > 0)
            {
                cmbZone.SelectedIndex = 0;
            }
        }
    }
}
