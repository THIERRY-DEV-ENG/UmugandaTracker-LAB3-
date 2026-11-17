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

        public CheckInForm()
        {
            InitializeComponent();

            // Add Statuses
            cmbStatus.Items.AddRange(new[] { "Present", "Absent" });
            cmbStatus.SelectedIndex = 0;

            // Load Events and Users into the dropdowns
            LoadDropdowns();
            LoadData();
        }

        private void LoadDropdowns()
        {
            try
            {
                cmbEvent.DataSource = _eventCtrl.GetAll();
                cmbEvent.DisplayMember = "EventName";
                cmbEvent.ValueMember = "EventID";

                cmbUser.DataSource = _userCtrl.GetAll();
                cmbUser.DisplayMember = "FullName";
                cmbUser.ValueMember = "UserID";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading dropdowns: " + ex.Message);
            }
        }

        private void LoadData()
        {
            try
            {
                dgvAttendance.DataSource = null;
                dgvAttendance.DataSource = _attCtrl.GetAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading attendance: " + ex.Message);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cmbEvent.SelectedValue == null || cmbUser.SelectedValue == null)
            {
                MessageBox.Show("Please select both an Event and a User.");
                return;
            }

            try
            {
                AttendanceRecord record = new AttendanceRecord
                {
                    EventID = Convert.ToInt32(cmbEvent.SelectedValue),
                    UserID = Convert.ToInt32(cmbUser.SelectedValue),
                    Status = cmbStatus.SelectedItem.ToString()
                };

                _attCtrl.Add(record);

                MessageBox.Show("Attendance saved successfully!");
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving attendance: " + ex.Message);
            }
        }
    }
}