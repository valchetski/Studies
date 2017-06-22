using System.Diagnostics;
using System.IO;
using System.Linq;

namespace BusinessLayer.Autorun
{
    public enum Status
    {
        Running, NotRunning, Disabled
    }
    public class AutorunApp : BaseApp
    {
        public string RegistryValueName { get; set; }
        public string Source { get; set; }
        public string SourceType => Source.Split('\\')[0];
        public string ExePath { get; set; }

        public string DisplayIconPath { get; set; }

        private Status status;

        public Status Status
        {
            get
            {
                if (status != Status.Disabled)
                {
                    string exePath = RegistryWork.ExtractPath(ExePath);
                    string exeName = Path.GetFileNameWithoutExtension(exePath);
                    status = Process.GetProcesses().Any(p => p.ProcessName == exeName)
                        ? Status.Running
                        : Status.NotRunning;
                }
                return status;
            }
            set
            {
                status = value;
            }
        }


        public AutorunApp(string name, string registryValueName, string source, string exePath)
        {
            Name = name;
            RegistryValueName = registryValueName;
            Source = source;
            ExePath = exePath;
            DisplayIcon = RegistryWork.GetDisplayIcon(exePath);
        }

        public AutorunApp() { }
    }
}
