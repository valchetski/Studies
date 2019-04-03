using System.Configuration;

namespace _3.Readers
{
    static class AppSettings
    {
        public static string ReadSetting(string key)
        {
            string result;
            try
            {
                var appSettings = ConfigurationManager.AppSettings;
                result = appSettings[key];
            }
            catch (ConfigurationErrorsException)
            {
                result = null;
            }
            return result;
        }

    }
}
