using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.AutoGitWatcher
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (Properties.Settings.Default.UpgradePending)
            {
                Properties.Settings.Default.Upgrade();
                Properties.Settings.Default.UpgradePending = false;
                Properties.Settings.Default.Save();
            }

            ApplicationConfiguration.Initialize();
            Application.Run(new MainForm());
        }
    }
}
