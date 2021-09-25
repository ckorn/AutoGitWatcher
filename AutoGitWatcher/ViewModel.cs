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

        public void Apply() 
        {
            string[] directoryArray = Directories.Split(Environment.NewLine);
            this.autoGitWatcher.StartWatch(directoryArray);
        }
    }
}
