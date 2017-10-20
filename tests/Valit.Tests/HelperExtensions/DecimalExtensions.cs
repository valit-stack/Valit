using System;

namespace Valit.Tests.HelperExtensions
{
    public static class DecimalExtensions
    {
        public static decimal? AsNullableDecimal(this string stringValue)
            => Convert.ToDecimal(stringValue) > 0? Convert.ToDecimal(stringValue) : (decimal?) null;

    }
}