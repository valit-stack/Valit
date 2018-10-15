using System;

namespace Valit.Extensions
{
    public static class DoubleExtensions
    {
        public static bool IsEqualTo(this double a, double b, double epsilon)
        {
            if (epsilon == .0d)
                return a == b;
            else
                return a.IsNearlyEqual(b, epsilon);
        }

        public static bool IsNotEqual(this double a, double b, double epsilon)  => !IsEqualTo(a, b, epsilon);

        /// <summary>
        /// receipes taken from: https://floating-point-gui.de/errors/comparison/
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="epsilon"></param>
        /// <returns></returns>
        public static bool IsNearlyEqual(this double a, double b, double epsilon)
        {
            double absA = Math.Abs(a);
            double absB = Math.Abs(b);
            double diff = Math.Abs(a - b);

            if (a == b)
            { // shortcut, handles infinities
                return true;
            }
            else if (a == 0 || b == 0 || diff < Double.MinValue)
            {
                // a or b is zero or both are extremely close to it
                // relative error is less meaningful here
                return diff < (epsilon * Double.MinValue);
            }
            else
            { // use relative error
                return diff / Math.Min((absA + absB), Double.MaxValue) < epsilon;
            }
        }

        public static bool IsGreaterThan(this double a, double b, double epsilon) => IsNotEqual(a, b, epsilon) && a > b;

        public static bool IsGreaterOrEqualThan(this double a, double b, double epsilon) => IsEqualTo(a, b, epsilon) || a > b;

        public static bool IsLessThan(this double a, double b, double epsilon) => IsNotEqual(a, b, epsilon) && a < b;

        public static bool IsLessOrEqualThan(this double a, double b, double epsilon) => IsEqualTo(a, b, epsilon) || a < b;
    }
}
