using System;
using System.Windows.Forms;
using UmugandaTracker.Controllers;
using UmugandaTracker.Models;

namespace UmugandaTracker.Views
{
    public partial class ReportForm : Form
    {
        private readonly AttendanceController _ctrl = new AttendanceController();

        public ReportForm()
        {
            InitializeComponent();
            dgvReport.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            LoadReport();
        }

        private void LoadReport()
        {
            try
            {
                var records = _ctrl.GetAll();
                dgvReport.DataSource = null;
                dgvReport.DataSource = records;
                lblTotal.Text = "Total Records: " + records.Count;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading report: " + ex.Message);
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadReport();
        }
    }
}
