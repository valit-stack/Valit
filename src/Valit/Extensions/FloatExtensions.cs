using System;

namespace Valit.Extensions
{
    public static class FloatExtensions
    {
        private static readonly float MIN_NORMAL = BitConverter.ToSingle(new byte[] { 0, 0, 0x80, 0 }, 0);

        public static bool IsEqual(this float a, float b, float epsilon)
        {
            if (epsilon == .0f)
                return a == b;
            else
                return a.IsNearlyEqual(b, epsilon);
        }

        public static bool IsNotEqual(this float a, float b, float epsilon) => !IsEqual(a, b, epsilon);

        public static bool IsGreaterThan(this float a, float b, float epsilon) => IsNotEqual(a, b, epsilon) && a > b;

        public static bool IsGreaterOrEqualThan(this float a, float b, float epsilon) => IsEqual(a, b, epsilon) || a > b;

        public static bool IsLessThan(this float a, float b, float epsilon) => IsNotEqual(a, b, epsilon) && a < b;

        public static bool IsLessOrEqualThan(this float a, float b, float epsilon) => IsEqual(a, b, epsilon) || a < b;

        private static bool IsNearlyEqual(this float a, float b, float epsilon)
        {
            if (float.IsNaN(a) || float.IsNaN(b))
                return false;

            if (float.IsNaN(epsilon))
                epsilon = float.Epsilon;

            float absA = Math.Abs(a);
            float absB = Math.Abs(b);
            float diff = Math.Abs(a - b);

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
                return diff / Math.Min((absA + absB), float.MaxValue) < epsilon;
            }
        }
    }
}
