using System;
using System.Windows.Forms;
using UmugandaTracker.Models;

namespace UmugandaTracker.Views
{
    public partial class MainForm : Form
    {
        private User _currentUser;

        // This constructor takes the User object
        public MainForm(User user)
        {
            InitializeComponent();
            _currentUser = user;
            this.Text = "Umuganda Tracker - " + user.FullName;
        }
    }
}