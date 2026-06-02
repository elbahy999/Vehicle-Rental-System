using System;
using System.Windows.Forms;

namespace projjjjj
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            // ── Global exception handlers ─────────────────────────────────────
            // Catches any unhandled exception on the UI thread
            Application.ThreadException += (sender, e) =>
            {
                ErrorLogger.Log(e.Exception, "UnhandledException.UIThread");
                MessageBox.Show(
                    "An unexpected error occurred:\n\n" + e.Exception.Message +
                    "\n\nThis has been logged. The application will continue.",
                    "Unexpected Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            };

            // Catches fatal exceptions on background threads
            AppDomain.CurrentDomain.UnhandledException += (sender, e) =>
            {
                ErrorLogger.Log(e.ExceptionObject as Exception, "UnhandledException.Fatal");
            };

            // Must be set before any UI is created
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
