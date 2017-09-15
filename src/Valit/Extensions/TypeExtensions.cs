using System;
using System.Collections.Generic;

namespace Valit.Extensions
{
    internal static class TypeExtensions
    {
        private static HashSet<Type> NumericTypes = new HashSet<Type>
        {
            typeof(Byte),
            typeof(SByte),
            typeof(UInt16),
            typeof(UInt32),
            typeof(UInt64),
            typeof(Int16),
            typeof(Int32),
            typeof(Int64),
            typeof(Single),
            typeof(Double),
            typeof(Decimal),
        };

        internal static bool IsNumericType(this Type type)
        {
            return NumericTypes.Contains(type) ||
                   NumericTypes.Contains(Nullable.GetUnderlyingType(type));
        }
    }
}
