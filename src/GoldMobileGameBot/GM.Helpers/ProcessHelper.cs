using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GM.Helpers
{
    public class ProcessHelper : IProcessHelper
    {
        public bool CheckRunProgramName(string name) => Process.GetProcesses().Any(x => x.ProcessName.Contains(name));
        public Process[] GetRunProgramsNames() => Process.GetProcesses();
    }

    public interface IProcessHelper
    {
        bool CheckRunProgramName(string name);
        Process[] GetRunProgramsNames();
    }
}
