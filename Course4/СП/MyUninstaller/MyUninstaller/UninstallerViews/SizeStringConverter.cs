using System;
using System.Globalization;
using System.Windows.Data;

namespace MyUninstaller.UninstallerViews
{
    class SizeStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string result = null;
            if (value is long)
            {
                long size = (long) value;
                result = size < Math.Pow(2, 30) //1 Gb
                    ? Math.Round(size / Math.Pow(2, 20), 2) + " Mb"
                    : Math.Round(size / Math.Pow(2, 30), 2) + " Gb";
            }
            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return 0;
        }
    }
}
