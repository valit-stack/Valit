using System;

namespace Valit.Tests.HelperExtensions
{
    public static class DateTimeOffsetExtensions
    {
        public static DateTimeOffset? AsNullableDateTimeOffset(this string stringValue)
            => string.IsNullOrWhiteSpace(stringValue)? (DateTimeOffset?)null : Convert.ToDateTime(stringValue);
    }
}