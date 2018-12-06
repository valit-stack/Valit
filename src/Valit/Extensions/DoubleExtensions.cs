using System;

namespace Valit.Extensions
{
    public static class DoubleExtensions
    {
        static readonly double MIN_NORMAL = BitConverter.ToDouble(new byte[] { 00, 00, 00, 00, 00, 00, 0x10, 00 }, 0);
        static readonly double MAX_VALUE = Double.MaxValue;

        public static bool IsEqual(this double a, double b, double epsilon)
        {
            if (epsilon == .0d)
                return a == b;
            else
                return a.IsNearlyEqual(b, epsilon);
        }

        public static bool IsNotEqual(this double a, double b, double epsilon)  => !IsEqual(a, b, epsilon);

        public static bool IsGreaterThan(this double a, double b, double epsilon) => IsNotEqual(a, b, epsilon) && a > b;

        public static bool IsGreaterOrEqualThan(this double a, double b, double epsilon) => IsEqual(a, b, epsilon) || a > b;

        public static bool IsLessThan(this double a, double b, double epsilon) => IsNotEqual(a, b, epsilon) && a < b;

        public static bool IsLessOrEqualThan(this double a, double b, double epsilon) => IsEqual(a, b, epsilon) || a < b;

        /// <summary>
        /// receipes taken from: https://floating-point-gui.de/errors/comparison/
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="epsilon"></param>
        /// <returns></returns>
        private static bool IsNearlyEqual(this double a, double b, double epsilon)
        {
            if (Double.IsNaN(a) || Double.IsNaN(b))
                return false;

            if (Double.IsNaN(epsilon))
                epsilon = Double.Epsilon;

            double absA = Math.Abs(a);
            double absB = Math.Abs(b);
            double diff = Math.Abs(a - b);

            if (a == b)
            { // shortcut, handles infinities
                return true;
            }
            else if (a == 0 || b == 0 || diff < MIN_NORMAL)
            {
                // a or b is zero or both are extremely close to it
                // relative error is less meaningful here
                return diff < (epsilon * MIN_NORMAL);
            }
            else
            { // use relative error
                return diff / Math.Min((absA + absB), MAX_VALUE) < epsilon;
            }
        }

        private static bool HasValue(this double? a)
        {
            return a.HasValue && !Double.IsNaN(a.Value);
        }
    }
}
