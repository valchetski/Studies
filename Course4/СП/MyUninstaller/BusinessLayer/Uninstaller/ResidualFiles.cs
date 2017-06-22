using System.Collections.Generic;
using System.IO;
using System.Security;
using Microsoft.Win32;

namespace BusinessLayer.Uninstaller
{
    public static class ResidualFiles
    {
        #region Find residual files in registry

        private static Dictionary<RegistryKey, string> matches;
        public static Dictionary<RegistryKey, string> FindResidualFilesRegistry(InstalledApp installedApp)
        {
            matches = new Dictionary<RegistryKey, string>();
            string key = RegistryWork.GetRegistryKeyNameWithoutPath(installedApp.RegistryKey);

            List<RegistryKey> keys = new List<RegistryKey>
            {
                RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64).OpenSubKey(RegistryWork.SOFTWARE_KEY),
                Registry.LocalMachine.OpenSubKey(RegistryWork.SOFTWARE_KEY),
                RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64).OpenSubKey(RegistryWork.WOW6432_NODE_KEY),
                Registry.LocalMachine.OpenSubKey(RegistryWork.WOW6432_NODE_KEY)
            };
            foreach (var registryKey in keys)
            {
                FindRegistryNotRecursive(key, registryKey);
            }

            List<RegistryKey> keysRecursive = new List<RegistryKey>
            {
                Registry.CurrentUser,
                RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64).OpenSubKey(RegistryWork.UNINSTALL_KEY),
                Registry.LocalMachine.OpenSubKey(RegistryWork.UNINSTALL_KEY),
            };
            foreach (var registryKey in keysRecursive)
            {
                FindRegistryRecursive(key, registryKey);
            }
            return matches;
        }

        private static void FindRegistryNotRecursive(string keyName, RegistryKey registryKey)
        {
            //search by keys
            var subKeysNames = registryKey.GetSubKeyNames();
            foreach (var subKeysName in subKeysNames)
            {
                var subKey = registryKey.OpenSubKey(subKeysName);
                if (RegistryWork.GetRegistryKeyNameWithoutPath(subKey.Name).ToLower().Contains(keyName.ToLower()))
                {
                    matches.Add(subKey, null);
                }
            }

            //search by values
            if (RegistryWork.GetRegistryKeyNameWithoutPath(registryKey.Name).ToLower().Contains(keyName.ToLower()) == false)
            {
                var valueNames = registryKey.GetValueNames();
                foreach (var valueName in valueNames)
                {
                    if (registryKey.GetValue(valueName)?.ToString().ToLower().Contains(keyName.ToLower()) == true)
                    {
                        matches.Add(registryKey, valueName + " [" + registryKey.GetValue(valueName) + "]");
                    }
                }
            }
        }


        private static void FindRegistryRecursive(string keyName, RegistryKey registryKey)
        {
            FindRegistryNotRecursive(keyName, registryKey);
            var subKeyNames = registryKey.GetSubKeyNames();
            foreach (var subKeyName in subKeyNames)
            {
                try
                {
                    FindRegistryRecursive(keyName, registryKey.OpenSubKey(subKeyName));
                }
                catch (SecurityException)
                {
                }

            }
        }

        #endregion

        public static List<DirectoryInfo> FindResidualFiles(InstalledApp installedApp)
        {
            var files = new List<DirectoryInfo>();
            if (Directory.Exists(installedApp.Location))
            {
                var directory = new DirectoryInfo(installedApp.Location);
                files.Add(directory);
            }
            return files;
        }
    }
}
