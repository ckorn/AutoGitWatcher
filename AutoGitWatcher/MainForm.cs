using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoGitWatcher
{
    public partial class MainForm : Form
    {
        private readonly ViewModel viewModel;
        public MainForm()
        {
            InitializeComponent();

            this.viewModel = new ViewModel();
            this.viewModel.LoadSettings();
            this.bindingSourceViewModel.DataSource = this.viewModel;
            this.viewModel.Log += ViewModel_Log;
        }

        private void ViewModel_Log(object? sender, string e)
        {
            void DoLog() 
            {
                this.mlLog.AppendText($"{DateTime.Now}: {e}{Environment.NewLine}");
            }
            if (this.InvokeRequired)
            {
                this.Invoke(DoLog);
            }
            else
            {
                DoLog();
            }
        }

        private void pbApply_Click(object sender, EventArgs e)
        {
            this.viewModel.Push();
        }

        private void pbPull_Click(object sender, EventArgs e)
        {
            this.viewModel.Pull();
        }
    }
}
