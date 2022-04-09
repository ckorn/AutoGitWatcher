using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AutoGitWatcher
{
    public class ViewModel : INotifyPropertyChanged
    {
        public bool EnableGui { get => enableGui; set { enableGui = value; OnPropertyChanged(); } }
        private bool enableGui = true;
        public string Directories { get; set; } = string.Empty;

        private readonly AutoGitWatcher autoGitWatcher = new();

        public event EventHandler<string>? Log;
        public event PropertyChangedEventHandler? PropertyChanged;

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

        public void Push() 
        {
            string[] directoryArray = Directories.Split(Environment.NewLine);
            this.autoGitWatcher.StartWatch(directoryArray);
            Properties.Settings.Default.Directories = this.Directories;
            Properties.Settings.Default.Save();
            EnableGui = false;
        }

        public void Pull()
        {
            string[] directoryArray = Directories.Split(Environment.NewLine);
            this.autoGitWatcher.StartPull(directoryArray);
            Properties.Settings.Default.Directories = this.Directories;
            Properties.Settings.Default.Save();
            EnableGui = false;
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "") 
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
