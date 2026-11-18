namespace UmugandaTracker.Views
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.btnZones = new System.Windows.Forms.Button();
            this.btnUsers = new System.Windows.Forms.Button();
            this.btnEvents = new System.Windows.Forms.Button();
            this.btnCheckIn = new System.Windows.Forms.Button();
            this.btnReports = new System.Windows.Forms.Button();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.panelHeader.SuspendLayout();
            this.SuspendLayout();

            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(0, 161, 222);
            this.panelHeader.Controls.Add(this.lblTitle);
            this.panelHeader.Controls.Add(this.lblSubtitle);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(680, 85);
            this.panelHeader.TabIndex = 6;

            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(25, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(209, 30);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Umuganda Tracker";

            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(250, 210, 1);
            this.lblSubtitle.Location = new System.Drawing.Point(27, 48);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(325, 17);
            this.lblSubtitle.TabIndex = 1;
            this.lblSubtitle.Text = "Building Rwanda Together • Civic Management System";

            this.btnZones.BackColor = System.Drawing.Color.FromArgb(240, 245, 250);
            this.btnZones.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnZones.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnZones.ForeColor = System.Drawing.Color.FromArgb(0, 100, 160);
            this.btnZones.Location = new System.Drawing.Point(40, 130);
            this.btnZones.Name = "btnZones";
            this.btnZones.Size = new System.Drawing.Size(160, 48);
            this.btnZones.TabIndex = 1;
            this.btnZones.Text = "Manage Zones";
            this.btnZones.UseVisualStyleBackColor = false;
            this.btnZones.Click += new System.EventHandler(this.btnZones_Click);

            this.btnUsers.BackColor = System.Drawing.Color.FromArgb(240, 245, 250);
            this.btnUsers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUsers.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUsers.ForeColor = System.Drawing.Color.FromArgb(0, 100, 160);
            this.btnUsers.Location = new System.Drawing.Point(255, 130);
            this.btnUsers.Name = "btnUsers";
            this.btnUsers.Size = new System.Drawing.Size(160, 48);
            this.btnUsers.TabIndex = 2;
            this.btnUsers.Text = "Manage Citizens";
            this.btnUsers.UseVisualStyleBackColor = false;
            this.btnUsers.Click += new System.EventHandler(this.btnUsers_Click);

            this.btnEvents.BackColor = System.Drawing.Color.FromArgb(240, 245, 250);
            this.btnEvents.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEvents.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEvents.ForeColor = System.Drawing.Color.FromArgb(0, 100, 160);
            this.btnEvents.Location = new System.Drawing.Point(470, 130);
            this.btnEvents.Name = "btnEvents";
            this.btnEvents.Size = new System.Drawing.Size(160, 48);
            this.btnEvents.TabIndex = 3;
            this.btnEvents.Text = "Manage Events";
            this.btnEvents.UseVisualStyleBackColor = false;
            this.btnEvents.Click += new System.EventHandler(this.btnEvents_Click);

            this.btnCheckIn.BackColor = System.Drawing.Color.FromArgb(0, 166, 81);
            this.btnCheckIn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCheckIn.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCheckIn.ForeColor = System.Drawing.Color.White;
            this.btnCheckIn.Location = new System.Drawing.Point(145, 215);
            this.btnCheckIn.Name = "btnCheckIn";
            this.btnCheckIn.Size = new System.Drawing.Size(175, 52);
            this.btnCheckIn.TabIndex = 4;
            this.btnCheckIn.Text = "Attendance Check-In";
            this.btnCheckIn.UseVisualStyleBackColor = false;
            this.btnCheckIn.Click += new System.EventHandler(this.btnCheckIn_Click);

            this.btnReports.BackColor = System.Drawing.Color.FromArgb(0, 161, 222);
            this.btnReports.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReports.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReports.ForeColor = System.Drawing.Color.White;
            this.btnReports.Location = new System.Drawing.Point(360, 215);
            this.btnReports.Name = "btnReports";
            this.btnReports.Size = new System.Drawing.Size(175, 52);
            this.btnReports.TabIndex = 5;
            this.btnReports.Text = "View Reports";
            this.btnReports.UseVisualStyleBackColor = false;
            this.btnReports.Click += new System.EventHandler(this.btnReports_Click);

            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            this.ClientSize = new System.Drawing.Size(680, 310);
            this.Controls.Add(this.panelHeader);
            this.Controls.Add(this.btnReports);
            this.Controls.Add(this.btnUsers);
            this.Controls.Add(this.btnEvents);
            this.Controls.Add(this.btnCheckIn);
            this.Controls.Add(this.btnZones);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Umuganda Tracker - Dashboard";
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Button btnZones;
        private System.Windows.Forms.Button btnCheckIn;
        private System.Windows.Forms.Button btnEvents;
        private System.Windows.Forms.Button btnUsers;
        private System.Windows.Forms.Button btnReports;
    }
}
