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
                cmbZone.DisplayMember = "ZoneName"; // Show the name in the dropdown
                cmbZone.ValueMember = "ZoneID";    // Use the ID behind the scenes
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
                MessageBox.Show("Fill all fields and select a zone.");
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
                LoadData();

                txtEventName.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving event: " + ex.Message);
            }
        }
    }
}