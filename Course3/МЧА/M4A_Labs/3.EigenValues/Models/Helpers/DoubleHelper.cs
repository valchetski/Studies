using System;

namespace Lab3.Models.Helpers
{
    public static class DoubleHelper
    {
        public const double EPSILON = 0.0000001;

        public static bool IsZero(this double value)
        {
            return Math.Abs(value) < EPSILON;
        }

        public static bool IsNotZero(this double value)
        {
            return Math.Abs(value) >= EPSILON;
        }

        public static string StringFormat(this double value, string format)
        {
            return String.Format(format, value).Replace(',', '.');
        }
    }
}