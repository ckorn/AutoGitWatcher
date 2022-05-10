using Logic.AutoGitManagement.Contract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
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

        public new event PropertyChangedEventHandler? PropertyChanged;

        public MainWindowViewModel()
        {
            this.autoGitWatcher.Log += AutoGitWatcher_Log;

            LoadSettings();
        }

        private string GetSettingsFile()
        {
            string settingsPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "AutoGitWatcher.Avalonia");
            if (!Directory.Exists(settingsPath))
            {
                Directory.CreateDirectory(settingsPath);
            }
            settingsPath = Path.Combine(settingsPath, "settings.json");
            return settingsPath;
        }

        public void LoadSettings()
        {
            string settingsPath = GetSettingsFile();
            if (File.Exists(settingsPath))
            {
                string json = File.ReadAllText(settingsPath);
                Settings settings = Newtonsoft.Json.JsonConvert.DeserializeObject<Settings>(json) ?? new Settings();
                this.Directories = settings.Directories;
            }
        }


        public void SaveSettings(Settings settings)
        {
            string settingsPath = GetSettingsFile();
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(settings);
            File.WriteAllText(settingsPath, json);
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
            SaveSettings(settings);
            EnableGui = false;
        }

        public void Pull()
        {
            string[] directoryArray = Directories.Split(Environment.NewLine);
            this.autoGitWatcher.StartPull(directoryArray);
            Settings settings = new() { Directories = this.Directories };
            SaveSettings(settings);
            EnableGui = false;
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
