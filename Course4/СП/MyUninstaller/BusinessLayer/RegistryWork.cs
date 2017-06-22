using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Security;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Microsoft.Win32;

namespace BusinessLayer
{
    public static class RegistryWork
    {
        public const string AUTO_RUN_KEY = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Run";
        public const string UNINSTALL_KEY = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall";
        public const string SOFTWARE_KEY = @"SOFTWARE";
        public const string WOW6432_NODE_KEY = @"SOFTWARE\Wow6432Node";

        const string INSTALLER_PATH = @"C:\Windows\Installer\";


        public static string GetInstallLocation(RegistryKey registryKey)
        {
            string path = Convert.ToString(registryKey.GetValue("InstallLocation"));
            if (path == "" || Directory.Exists(path) == false)
            {
                path = GetUninstallString(registryKey);
                if (path != "")
                {
                    path = Path.GetDirectoryName(ExtractPath(path));
                }
            }
            return path;
        }

        //в байтах
        public static long GetSize(RegistryKey registryKey)
        {
            long size = Convert.ToInt64(registryKey.GetValue("EstimatedSize"));
            if (size == 0)
            {
                string path = GetInstallLocation(registryKey);
                if (Directory.Exists(path) && path.ToLower().Contains("system32") == false)
                {
                    Scripting.FileSystemObject fso = new Scripting.FileSystemObject();
                    Scripting.Folder folder = fso.GetFolder(path);
                    size = (long)folder.Size;
                }
            }
            else
            {
                size = size * 1024; //в реестре хранится значение в килобайтах. Мы переводим в байты
            }
            return size;
        }

        public static string GetDisplayName(RegistryKey registryKey)
        {
            return registryKey != null ? Convert.ToString(registryKey.GetValue("DisplayName")) : "";
        }

        public static ImageSource GetDisplayIcon(RegistryKey registryKey)
        {
            string path = Convert.ToString(registryKey.GetValue("DisplayIcon"));
            
            path = ExtractPath(path);
            if (path == "" || File.Exists(path) == false)
            {
                path = Convert.ToString(registryKey.GetValue("InstallLocation"));
                if (Directory.Exists(path) == false)
                {
                    path = GetUninstallString(registryKey);
                    if (path.ToLower().Contains("msiexec.exe"))
                    {
                        string path1 = INSTALLER_PATH + path.Substring(path.IndexOf('{'));
                        if (Directory.Exists(path1))
                        {
                            path = Directory.GetFiles(path1).FirstOrDefault();
                        }
                    }
                }
                else
                {
                    path = Directory.GetFiles(path, "*.exe").FirstOrDefault();
                }
            }

            return GetDisplayIcon(path);
        }

        public static ImageSource GetDisplayIcon(string path)
        {
            path = ExtractPath(path);
            ImageSource imageSource = null;
            if (File.Exists(path))
            {
                var icon = Icon.ExtractAssociatedIcon(path);
                using (Bitmap bmp = icon.ToBitmap())
                {
                    var stream = new MemoryStream();
                    bmp.Save(stream, ImageFormat.Png);
                    imageSource = BitmapFrame.Create(stream);
                }
            }
            return imageSource;
        }

        /// <summary>
        /// Returns path with any parametrs
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string ExtractPath(string path)
        {
            string extractedPath = path;
            if (path != null)
            {
                var substring = path.Split('"').FirstOrDefault(s => s.Contains(":\\"));
                if (substring != null)
                {
                    int i = substring.LastIndexOf('.');
                    if (i != -1)
                    {
                        int j = substring.IndexOfAny(new[] { ' ', ',' }, i);

                        extractedPath = j != -1 ? substring.Substring(0, j) : substring;
                    }
                }
            }
            return extractedPath;
        }

        public  static string GetUninstallString(RegistryKey registryKey)
        {
            return Convert.ToString(registryKey.GetValue("UninstallString"));
        }

        public static bool IsSystemComponent(RegistryKey registryKey)
        {
            return Convert.ToBoolean(registryKey.GetValue("SystemComponent"));
        }

        public static bool IsHaveParent(RegistryKey registryKey)
        {
            return registryKey.GetValue("ParentKeyName") != null;
        }


        public static string GetNameExe(string exePath)
        {
            exePath = ExtractPath(exePath);
            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(exePath);
            return fvi.FileDescription;
        }

        public static RegistryKey GetRegistryKeyType(string autorunType)
        {
            RegistryKey registryKey = null;
            autorunType = autorunType.Split('\\').FirstOrDefault();
            switch (autorunType)
            {
                case "Current user":
                case "HKEY_CURRENT_USER":
                    registryKey = Registry.CurrentUser;
                    break;
                case "HKEY_LOCAL_MACHINE":
                case "All users":
                    registryKey = Registry.LocalMachine;
                    break;
            }
            return registryKey;
        }

        public static string GetRegistryKeyNameWithoutPath(string registryKeyName)
        {
            return registryKeyName.Split('\\').LastOrDefault();
        }

        public static string GetRegistryKeyNameWithoutType(string registryKeyName)
        {
            return registryKeyName.Substring(registryKeyName.IndexOf('\\') + 1); 
        }

        public static void AddValue(string keyName, string value, string valueName)
        {
            var registryKey = GetRegistryKeyType(keyName);
            string key = keyName.Substring(keyName.IndexOf(registryKey.Name));
            registryKey = registryKey.OpenSubKey(key, true);
            registryKey.SetValue(valueName, value);
        }

        public static void Remove(string keyName, string valueName, string value)
        {
            var registryKey = GetRegistryKeyType(keyName);
            string subKey = GetRegistryKeyNameWithoutType(keyName);

            try
            {
                registryKey = registryKey.OpenSubKey(subKey, true);
            }
            catch (SecurityException)
            {
                registryKey = Getx64Key(registryKey, subKey);
            }
            

            if (registryKey.GetValue(valueName) != null)
            {
                registryKey.DeleteValue(valueName);
            }

            if (registryKey.ValueCount == 0)
            {
                registryKey = GetRegistryKeyType(keyName);
                subKey = subKey.Substring(0, subKey.LastIndexOf('\\'));
                registryKey = registryKey.OpenSubKey(subKey, true);
                registryKey.DeleteSubKey(GetRegistryKeyNameWithoutPath(keyName));
            }
        }

        private static RegistryKey Getx64Key(RegistryKey registryKey, string subKey)
        {
            var key = GetRegistryKeyType(registryKey.Name);
            RegistryHive registryHive = RegistryHive.LocalMachine;
            if (key == Registry.LocalMachine)
            {
                registryHive = RegistryHive.LocalMachine;
            }
            else if (key == Registry.CurrentUser)
            {
                registryHive = RegistryHive.CurrentUser;
            }
            var hklm = RegistryKey.OpenBaseKey(registryHive, RegistryView.Registry64);
            return hklm.OpenSubKey(subKey);
        }
    }
}
