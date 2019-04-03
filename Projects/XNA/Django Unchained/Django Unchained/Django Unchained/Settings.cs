using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Django_Unchained
{
    [Serializable]
    public class Settings
    {
        private int screenWidth;
        private int screenHeight;
        private bool isFullscreen;
        private bool isMusicOn;
        private bool isSoundsOn;

        public static int ScreenWidth { get; set; }
        public static int ScreenHeight { get; set; }

        public static bool IsFullscreen { get; set; }
        public static bool IsMusicOn { get; set; }
        public static bool IsSoundsOn { get; set; }

        public static bool isChanged;

        private const string fileName = "settings.bin";

        public static void Save()
        {
            var settings = new Settings
            {
                screenWidth = ScreenWidth,
                screenHeight = ScreenHeight,
                isFullscreen = IsFullscreen,
                isMusicOn = IsMusicOn,
                isSoundsOn = IsSoundsOn
            };
            var formatter = new BinaryFormatter();
            using (Stream s = File.Create(fileName))
                formatter.Serialize(s, settings);
        }

        public static void LoadAll()
        {
            Settings settings;
            try
            {
                var formatter = new BinaryFormatter();
                using (Stream s = File.OpenRead(fileName))
                {
                    settings = (Settings) formatter.Deserialize(s);
                }
                ScreenWidth = settings.screenWidth > 0 ? settings.screenWidth : 1366;
                ScreenHeight = settings.screenHeight > 0 ? settings.screenHeight : 768;
                IsFullscreen = settings.isFullscreen;
                IsMusicOn = settings.isMusicOn;
                IsSoundsOn = settings.isSoundsOn;
            }
            catch (Exception)
            {
                ScreenWidth = 1366;
                ScreenHeight = 768;
                IsFullscreen = true;
                IsMusicOn = true;
                IsSoundsOn = true;
            }
        }
    }
}
