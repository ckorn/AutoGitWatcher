using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoGitWatcher
{
    public class ViewModel
    {
        public string Directories { get; set; } = string.Empty;

        private readonly AutoGitWatcher autoGitWatcher = new();

        public event EventHandler<string>? Log;

        public ViewModel()
        {
            this.autoGitWatcher.Log += AutoGitWatcher_Log;
        }

        public void LoadSettings() 
        {
            this.Directories = Properties.Settings.Default.Directories;
        }

        private void AutoGitWatcher_Log(object? sender, string e)
        {
            this.Log?.Invoke(this, e);
        }

        public void Apply() 
        {
            string[] directoryArray = Directories.Split(Environment.NewLine);
            this.autoGitWatcher.StartWatch(directoryArray);
            Properties.Settings.Default.Directories = this.Directories;
            Properties.Settings.Default.Save();
        }
    }
}
