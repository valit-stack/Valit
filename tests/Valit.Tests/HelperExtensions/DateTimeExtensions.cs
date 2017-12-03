using System;

namespace Valit.Tests.HelperExtensions
{
    public static class DateTimeExtensions
    {
        public static DateTime? AsNullableDateTime(this string stringValue)
            => string.IsNullOrWhiteSpace(stringValue)? (DateTime?)null : Convert.ToDateTime(stringValue);

    }
}
