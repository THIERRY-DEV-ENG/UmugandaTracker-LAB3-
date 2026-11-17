using System;
using System.Windows.Forms;
using UmugandaTracker.Models;
using UmugandaTracker.Views;

namespace UmugandaTracker.Views
{
    public partial class MainForm : Form
    {
        private User _currentUser;

        public MainForm(User user)
        {
            InitializeComponent();
            _currentUser = user;
            this.Text = "Umuganda Tracker - " + user.FullName;
        }

        private void btnZones_Click(object sender, EventArgs e)
        {
            ZoneForm zoneForm = new ZoneForm();
            zoneForm.ShowDialog();
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            UserForm userForm = new UserForm();
            userForm.ShowDialog();
        }

        private void btnEvents_Click(object sender, EventArgs e)
        {
            EventForm eventForm = new EventForm();
            eventForm.ShowDialog();
        }

        private void btnCheckIn_Click(object sender, EventArgs e)
        {
            CheckInForm checkInForm = new CheckInForm();
            checkInForm.ShowDialog();
        }
    }
}