using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Xml.Serialization;
using Microsoft.Win32;

namespace BusinessLayer.Autorun
{
    public static class Autorun
    {
        private const string DISABLED_PROGRAMS_FILENAME = "disabledPrograms.xml";
        private static List<AutorunApp> GetDisabledProgramsFromFile()
        {
            var programs = new List<AutorunApp>();
            if (File.Exists(DISABLED_PROGRAMS_FILENAME))
            {
                using (var file = File.Open(DISABLED_PROGRAMS_FILENAME, FileMode.Open))
                {
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<AutorunApp>));
                    try
                    {
                        programs = ((List<AutorunApp>)xmlSerializer.Deserialize(file)).Where(a => a.Status == Status.Disabled).ToList();
                    }
                    catch (InvalidOperationException)
                    {
                    }
                }
            }
            for (int i = 0; i < programs.Count; i++)
            {
                programs[i].DisplayIcon = RegistryWork.GetDisplayIcon(programs[i].ExePath);
            }
            return programs;
        }

        private static void SetDisabledProgramsToFile(List<AutorunApp> programs)
        {
            using (var file = File.Open(DISABLED_PROGRAMS_FILENAME, FileMode.Create))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<AutorunApp>));
                xmlSerializer.Serialize(file, programs);
            }
        }

        public static List<AutorunApp> GetAllAutorunApps()
        {
            //autorun for current user
            var autorunApps = GetSomeAutorunApps(Registry.CurrentUser);

            //autorun for all users
            var hklm = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64);
            autorunApps.AddRange(GetSomeAutorunApps(hklm));

            var programs = GetDisabledProgramsFromFile();
            autorunApps.AddRange(programs);

            autorunApps.Sort((x, y) => string.Compare(x.Name.ToLower(), y.Name.ToLower(), StringComparison.Ordinal));

            return autorunApps;
        }

        private static List<AutorunApp> GetSomeAutorunApps(RegistryKey key)
        {
            var autorunApps = new List<AutorunApp>();
            using (RegistryKey registryKey = key.OpenSubKey(RegistryWork.AUTO_RUN_KEY, false))
            {
                foreach (string valueName in registryKey.GetValueNames())
                {
                    string exePath = registryKey.GetValue(valueName).ToString();
                    if (IsFileExists(exePath))
                    {
                        string name = RegistryWork.GetNameExe(exePath) ?? valueName;
                        string source = registryKey.Name;

                        var program = new AutorunApp(name, valueName, source, exePath);
                        autorunApps.Add(program);
                    }
                }
            }
            return autorunApps;
        }

        private static bool IsFileExists(string exePath)
        {
            exePath = RegistryWork.ExtractPath(exePath);
            return File.Exists(exePath);
        }

        public static bool IsProgramAlreadyInAutorun(string autorunType, string name)
        {
            RegistryKey registryKey = GetRegistryKeyForAutorun(autorunType);
            return registryKey.GetValue(name) != null;
        }

        public static void AddProgramToAutorun(string appName, string autorunType, string exePath)
        {
            RegistryKey registryKey = GetRegistryKeyForAutorun(autorunType);
            registryKey.SetValue(appName, exePath);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>If it returns null -- app wasn't be in autorun</returns>
        public static bool? RemoveProgramFromAutorun(string name)
        {
            bool? result = null;
            var sourceTypes = new[] {"HKEY_CURRENT_USER", "HKEY_LOCAL_MACHINE"};
            foreach (var sourceType in sourceTypes)
            {
                RegistryKey registryKey = GetRegistryKeyForAutorun(sourceType);
                if (registryKey.GetValue(name) != null)
                {
                    registryKey.DeleteValue(name);
                    result = true;
                    break;
                }
            }
            return result;
        }
        public static void RemoveProgramFromAutorun(AutorunApp app)
        {
            RegistryKey registryKey = GetRegistryKeyForAutorun(app.SourceType);
            if (registryKey.GetValue(app.RegistryValueName) != null)
            {
                registryKey.DeleteValue(app.RegistryValueName);

                var disabledApps = GetDisabledProgramsFromFile();
                app.Status = Status.Disabled;
                disabledApps.Add(app);
                SetDisabledProgramsToFile(disabledApps);
            }
        }

        private static RegistryKey GetRegistryKeyForAutorun(string autorunType)
        {
            RegistryKey registryKey = RegistryWork.GetRegistryKeyType(autorunType);
            if (registryKey.Name.ToLower().Contains("hkey_local_machine"))
            {
                registryKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64);
            }
            return registryKey.OpenSubKey(RegistryWork.AUTO_RUN_KEY, true);
        }

        public static void RemoveProgramFromEverywhere(AutorunApp app)
        {
            RemoveProgramFromAutorun(app);

            var programs = GetDisabledProgramsFromFile();
            programs = programs.Where(p => p.Name != app.Name).ToList();
            SetDisabledProgramsToFile(programs);
        }
    }
}
