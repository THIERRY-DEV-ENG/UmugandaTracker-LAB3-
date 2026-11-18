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
        private int _selectedAttendanceID = 0;

        public CheckInForm() : this(null)
        {
        }

        public CheckInForm(User currentUser)
        {
            InitializeComponent();
            _currentUser = currentUser;

            cmbStatus.SelectedIndex = 0;
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
                cmbEvent.DataSource = _eventCtrl.GetAll();
                cmbEvent.DisplayMember = "EventName";
                cmbEvent.ValueMember = "EventID";

                cmbUser.DataSource = _userCtrl.GetAll();
                cmbUser.DisplayMember = "FullName";
                cmbUser.ValueMember = "UserID";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading dropdown data: " + ex.Message);
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cmbEvent.SelectedValue == null || cmbUser.SelectedValue == null || cmbStatus.SelectedItem == null)
            {
                MessageBox.Show("Please select an Event, a Citizen, and a Status.");
                return;
            }

            try
            {
                AttendanceRecord record = new AttendanceRecord
                {
                    AttendanceID = _selectedAttendanceID,
                    EventID = Convert.ToInt32(cmbEvent.SelectedValue),
                    UserID = Convert.ToInt32(cmbUser.SelectedValue),
                    Status = cmbStatus.SelectedItem.ToString()
                };

                if (_selectedAttendanceID == 0)
                {
                    _attCtrl.Add(record);
                    MessageBox.Show("Attendance recorded successfully!");
                }
                else
                {
                    _attCtrl.Update(record);
                    MessageBox.Show("Attendance status updated successfully!");
                }

                ClearForm();
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving attendance: " + ex.Message);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ClearForm();
            LoadDropdowns();
            ApplyMemberRestriction();
            LoadData();
        }

        private void dgvAttendance_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvAttendance.Rows[e.RowIndex].Cells["AttendanceID"].Value != null)
            {
                var row = dgvAttendance.Rows[e.RowIndex];
                _selectedAttendanceID = Convert.ToInt32(row.Cells["AttendanceID"].Value);

                string status = row.Cells["Status"].Value?.ToString();
                if (!string.IsNullOrEmpty(status) && cmbStatus.Items.Contains(status))
                {
                    cmbStatus.SelectedItem = status;
                }
            }
        }

        private void ClearForm()
        {
            _selectedAttendanceID = 0;
            if (cmbStatus.Items.Count > 0)
            {
                cmbStatus.SelectedIndex = 0;
            }
            if (_currentUser == null || _currentUser.Role != "Member")
            {
                if (cmbUser.Items.Count > 0)
                {
                    cmbUser.SelectedIndex = 0;
                }
            }
        }
    }
}
