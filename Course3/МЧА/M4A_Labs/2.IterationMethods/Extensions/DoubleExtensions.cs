using System;

namespace Lab2.Extensions
{
    public static class DoubleExtensions
    {
        public const double Epsilon = 0.0000001;

        public static bool IsNotZero(this double value)
        {
            return Math.Abs(value) >= Epsilon;
        }

        public static string StringFormat(this double value, string format)
        {
            return String.Format(format, value);
        }
    }
}