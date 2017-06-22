using System;
using System.Windows.Media;

namespace BusinessLayer.Uninstaller
{
    public class InstalledApp : BaseApp
    {
        //размер в байтах
        public long Size { get; }
        public DateTime? InstalledDateTime { get; set; }
        public string Version { get; set; }
        public string Publisher { get; set; }
        public string Location { get; set; }
        public string UninstallString { get; set; }
        public bool IsSystemComponent { get; set; }
        public string RegistryKey { get; set; }


        public InstalledApp()
        {

        }

        public InstalledApp(string name, ImageSource displayIcon, long size, DateTime? installedDate, object version,
            object publisher, string location, string uninstallString, bool isSystemComponent, string registryKey)
        {
            Name = name;
            DisplayIcon = displayIcon;
            Size = size;
            InstalledDateTime = installedDate;
            Version = Convert.ToString(version ?? "");
            Publisher = Convert.ToString(publisher ?? "");
            Location = location;
            UninstallString = uninstallString;
            IsSystemComponent = isSystemComponent;
            RegistryKey = registryKey;
        }
    }
}
