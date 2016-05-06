using System;
using System.Windows.Forms;

namespace UrlCheck {
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // http://stackoverflow.com/questions/995195/how-can-i-make-a-net-windows-forms-application-that-only-runs-in-the-system-tra
            // https://www.simple-talk.com/dotnet/.net-framework/creating-tray-applications-in-.net-a-practical-guide/
            // http://www.codeproject.com/Articles/18683/Creating-a-Tasktray-Application

            try {
                Application.Run(new AppContext());
            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
