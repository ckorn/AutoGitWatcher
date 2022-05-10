using Logic.AutoGitManagement.Contract;
using SettingsProviderNet;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using UI.AutoGitWatcher.Avalonia.Models;

namespace UI.AutoGitWatcher.Avalonia.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public string Directories { get; set; } = "";
        public string Log { get => log; set { log = value; OnPropertyChanged(); } }
        public string log = "";

        public bool EnableGui { get => enableGui; set { enableGui = value; OnPropertyChanged(); } }
        private bool enableGui = true;

        private readonly IAutoGitWatcher autoGitWatcher = new Logic.AutoGitManagement.AutoGitWatcher();

        private readonly SettingsProvider settingsProvider = new (new RoamingAppDataStorage("AutoGitWatcher.Avalonia"));

        public new event PropertyChangedEventHandler? PropertyChanged;

        public MainWindowViewModel()
        {
            this.autoGitWatcher.Log += AutoGitWatcher_Log;

            LoadSettings();
        }

        public void LoadSettings()
        {
            Settings settings = settingsProvider.GetSettings<Settings>();
            this.Directories = settings.Directories;
        }

        private void AutoGitWatcher_Log(object? sender, string e)
        {
            this.Log = e;
        }

        public void Push()
        {
            string[] directoryArray = Directories.Split(Environment.NewLine);
            this.autoGitWatcher.StartWatch(directoryArray);
            Settings settings = new() { Directories = this.Directories };
            settingsProvider.SaveSettings(settings);
            EnableGui = false;
        }

        public void Pull()
        {
            string[] directoryArray = Directories.Split(Environment.NewLine);
            this.autoGitWatcher.StartPull(directoryArray);
            Settings settings = new() { Directories = this.Directories };
            settingsProvider.SaveSettings(settings);
            EnableGui = false;
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
