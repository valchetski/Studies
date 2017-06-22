using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Media;
using Microsoft.Win32;

namespace BusinessLayer.Uninstaller
{
    public static class Uninstaller
    {
        public static List<InstalledApp> GetAllPrograms()
        {
            //all users x64 
            var hklm = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64);
            var programs = GetSomePrograms(hklm.OpenSubKey(RegistryWork.UNINSTALL_KEY));

            //all users x32
            programs.AddRange(GetSomePrograms(Registry.LocalMachine.OpenSubKey(RegistryWork.UNINSTALL_KEY)));

            //current user
            programs.AddRange(GetSomePrograms(Registry.CurrentUser.OpenSubKey(RegistryWork.UNINSTALL_KEY)));

            programs.Sort((x, y) => string.Compare(x.Name.ToLower(), y.Name.ToLower(), StringComparison.Ordinal));
            return programs;
        }


        private static List<InstalledApp> GetSomePrograms(RegistryKey registryKey)
        {
            var programs = new List<InstalledApp>();
            foreach (string skName in registryKey.GetSubKeyNames())
            {
                using (RegistryKey subKey = registryKey.OpenSubKey(skName))
                {
                    string name = RegistryWork.GetDisplayName(subKey);
                    bool isSystemComponent = RegistryWork.IsSystemComponent(subKey);


                    if (name != "" && isSystemComponent == false && RegistryWork.IsHaveParent(subKey) == false)
                    {
                        //ImageSource displayIcon = null;
                        ImageSource displayIcon = RegistryWork.GetDisplayIcon(subKey);
                        long size = RegistryWork.GetSize(subKey);
                        DateTime? installDate = GetInstallDate(subKey);
                        object version = subKey.GetValue("DisplayVersion");
                        object publisher = subKey.GetValue("Publisher");
                        string installLocation = RegistryWork.GetInstallLocation(subKey);
                        string uninstallString = RegistryWork.GetUninstallString(subKey);
                        string rKey = subKey.Name;
                        //DateTime? lastUseDateTime = GetLastUseDateTime(installLocation);

                        var program = new InstalledApp(name, displayIcon, size, installDate, version, publisher, installLocation,
                            uninstallString, isSystemComponent, rKey);

                        programs.Add(program);

                    }
                }
            }
            return programs;
        }

        private static DateTime? GetInstallDate(RegistryKey registryKey)
        {
            DateTime? installedDateTime = null;
            string dateString = Convert.ToString(registryKey.GetValue("InstallDate"));
            if (dateString != "" && dateString.Length == 8)
            {
                int year = Convert.ToInt32(dateString.Substring(0, 4));
                int month = Convert.ToInt32(dateString.Substring(4, 2));
                int day = Convert.ToInt32(dateString.Substring(6, 2));
                installedDateTime = new DateTime(year, month, day);
            }
            else
            {
                string path = RegistryWork.GetInstallLocation(registryKey);
                if (Directory.Exists(path))
                {
                    installedDateTime = Directory.GetCreationTime(path);
                }
            }
            return installedDateTime;
        }

    }
}
