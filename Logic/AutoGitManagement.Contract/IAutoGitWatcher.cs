using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.AutoGitManagement.Contract
{
    public interface IAutoGitWatcher
    {
        event EventHandler<string>? Log;
        void StartWatch(string[] directoryArray);
        void StartPull(string[] directoryArray);
    }
}
