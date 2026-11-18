using System;
using System.Windows.Forms;
using UmugandaTracker.Controllers;

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
                var dt = _ctrl.GetReport();
                dgvReport.DataSource = null;
                dgvReport.DataSource = dt;
                lblTotal.Text = "Total Records: " + dt.Rows.Count;
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
