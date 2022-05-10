using Avalonia.Controls;
using Avalonia.ReactiveUI;
using System.ComponentModel;
using UI.AutoGitWatcher.Avalonia.ViewModels;

namespace UI.AutoGitWatcher.Avalonia.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            this.DataContextChanged += MainWindow_DataContextChanged;
        }

        private void MainWindow_DataContextChanged(object? sender, System.EventArgs e)
        {
            if (DataContext is MainWindowViewModel viewModel)
            {
                viewModel.PropertyChanged += MainWindow_PropertyChanged;
                this.pbPull.IsEnabled = viewModel.EnableGui;
                this.pbPush.IsEnabled = viewModel.EnableGui;
                this.mlLog.Text = viewModel.Log;
            }
        }

        private void MainWindow_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(MainWindowViewModel.EnableGui))
            {
                if (DataContext is MainWindowViewModel viewModel)
                {
                    this.pbPull.IsEnabled = viewModel.EnableGui;
                    this.pbPush.IsEnabled = viewModel.EnableGui;
                }
            }
            else if (e.PropertyName == nameof(MainWindowViewModel.Log))
            {
                if (DataContext is MainWindowViewModel viewModel)
                {
                    this.mlLog.Text = viewModel.Log;
                }
            }
        }
    }
}
