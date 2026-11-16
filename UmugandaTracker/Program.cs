using System;
using System.Windows.Forms;
using UmugandaTracker.Views;

namespace UmugandaTracker
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // THIS MUST BE LoginForm
            Application.Run(new LoginForm());
        }
    }
}