using System;
using System.Windows.Forms;
using System.Diagnostics;

namespace CoevenLauncher
{
    public static class ProcessExtensions
    {
        public static bool estaFuncionando(string process)
        {
            foreach (Process p in Process.GetProcesses())
            {
                if (p.ProcessName.Equals(process))
                {
                    return true;
                }
            }
            
            return false;
        }

        public static void killProceso(string process)
        {
            foreach (Process proc in Process.GetProcessesByName(process))
            {
                proc.Kill();
            }
        }

        public static void findKill(string process)
        {
            foreach (Process proc in Process.GetProcessesByName(process))
            {
                proc.Kill();
            }
        }

    }
}
