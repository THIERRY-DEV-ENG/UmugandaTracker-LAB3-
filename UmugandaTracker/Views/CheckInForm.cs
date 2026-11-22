using System;
using System.Windows.Forms;
using UmugandaTracker.Controllers;
using UmugandaTracker.Models;

namespace UmugandaTracker.Views
{
    public partial class CheckInForm : Form
    {
        private readonly AttendanceController _attCtrl = new AttendanceController();
        private readonly EventController _eventCtrl = new EventController();
        private readonly UserController _userCtrl = new UserController();
        private readonly User _currentUser;

        public CheckInForm() : this(null)
        {
        }

        public CheckInForm(User currentUser)
        {
            InitializeComponent();
            _currentUser = currentUser;

            LoadDropdowns();
            ApplyMemberRestriction();
            LoadData();
        }

        private void ApplyMemberRestriction()
        {
            if (_currentUser != null && _currentUser.Role == "Member")
            {
                cmbUser.SelectedValue = _currentUser.UserID;
                cmbUser.Enabled = false;
            }
        }

        private void LoadDropdowns()
        {
            try
            {
                var events = _eventCtrl.GetAll();
                cmbEvent.DataSource = events;
                cmbEvent.DisplayMember = "DisplayText";
                cmbEvent.ValueMember = "EventID";

                cmbUser.DataSource = _userCtrl.GetAll();
                cmbUser.DisplayMember = "FullName";
                cmbUser.ValueMember = "UserID";

                UpdateSiteDetails();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading dropdown data: " + ex.Message);
            }
        }

        private void UpdateSiteDetails()
        {
            if (cmbEvent.SelectedItem is UmugandaEvent ev)
            {
                string zone = string.IsNullOrEmpty(ev.ZoneName) ? "Unassigned" : ev.ZoneName;
                string loc = string.IsNullOrEmpty(ev.Location) ? "Not Specified" : ev.Location;
                lblSiteDetails.Text = "Date: " + ev.EventDate.ToString("dd/MM/yyyy") + "  |  Zone: " + zone + " (" + loc + ")";
            }
        }

        private void LoadData()
        {
            try
            {
                dgvAttendance.DataSource = null;
                dgvAttendance.DataSource = _attCtrl.GetReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading attendance records: " + ex.Message);
            }
        }

        private void cmbEvent_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateSiteDetails();
        }

        private void btnCheckIn_Click(object sender, EventArgs e)
        {
            if (cmbEvent.SelectedValue == null || cmbUser.SelectedValue == null)
            {
                MessageBox.Show("Please select an Event and a Citizen.");
                return;
            }

            int eventId = Convert.ToInt32(cmbEvent.SelectedValue);
            int userId = Convert.ToInt32(cmbUser.SelectedValue);

            try
            {
                var existing = _attCtrl.GetByEventAndUser(eventId, userId);

                if (existing != null)
                {
                    MessageBox.Show("You have already checked in for this Umuganda event! Status: " + existing.Status);
                    return;
                }

                string timeStr = DateTime.Now.ToString("hh:mm tt");
                AttendanceRecord record = new AttendanceRecord
                {
                    EventID = eventId,
                    UserID = userId,
                    Status = "Checked-In (" + timeStr + ")"
                };

                _attCtrl.Add(record);
                MessageBox.Show("Checked-In successfully at " + timeStr + "! Welcome to Umuganda.");
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error during Check-In: " + ex.Message);
            }
        }

        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            if (cmbEvent.SelectedValue == null || cmbUser.SelectedValue == null)
            {
                MessageBox.Show("Please select an Event and a Citizen.");
                return;
            }

            int eventId = Convert.ToInt32(cmbEvent.SelectedValue);
            int userId = Convert.ToInt32(cmbUser.SelectedValue);

            try
            {
                var existing = _attCtrl.GetByEventAndUser(eventId, userId);

                if (existing == null)
                {
                    MessageBox.Show("You cannot Check-Out! You must Check-In first when you arrive.");
                    return;
                }

                if (existing.Status.StartsWith("Checked-Out"))
                {
                    MessageBox.Show("You have already checked out and completed this Umuganda event!");
                    return;
                }

                string timeStr = DateTime.Now.ToString("hh:mm tt");
                existing.Status = "Checked-Out (" + timeStr + ")";

                _attCtrl.Update(existing);
                MessageBox.Show("Checked-Out successfully at " + timeStr + "! Thank you for serving your community.");
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error during Check-Out: " + ex.Message);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadDropdowns();
            ApplyMemberRestriction();
            LoadData();
        }
    }
}
