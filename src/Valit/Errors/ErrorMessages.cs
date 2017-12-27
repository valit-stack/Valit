namespace Valit.Errors
{
    internal static class ErrorMessages
    {
        internal static string Required => "The {0} field is required.";
        internal static string Satisifes => "The {0} field does not satisfy the rule.";
        internal static string IsTrue => "The {0} field is not true.";
        internal static string IsFalse => "The {0} field is not false.";
        internal static string IsEqualTo => "The {0} field is not equal to {1}.";
        internal static string IsGreaterThan => "The {0} field is not greater than {1}.";
        internal static string IsGreaterThanOrEqualTo => "The {0} field is not greater than or equal to {1}.";
        internal static string IsLessThan => "The {0} field is not less than {1}.";
        internal static string IsLessThanOrEqualTo => "The {0} field is not less than or equal to {1}.";
        internal static string IsNonZero => "The {0} field is a zero.";
        internal static string IsAfter => "The {0} field is not after {1}.";
        internal static string IsAfterOrSameAs => "The {0} field is not after or same as {1}.";
        internal static string IsBefore => "The {0} field is not before {1}.";
        internal static string IsBeforeOrSameAs => "The {0} field is not before or same as {1}.";
        internal static string IsSameAs => "The {0} field is not same as {1}.";
        internal static string IsNegative => "The {0} field is not a negative number.";
        internal static string IsPositive => "The {0} field is not a positive number.";
        internal static string IsNaN => "The {0} field is not NaN.";
        internal static string IsNumber => "The {0} field is not a number.";
        internal static string MinItems => "The {0} field has less than {1} elements.";
        internal static string MaxItems => "The {0} field has more than {1} elements.";
        internal static string Email => "The {0} field is not valid email.";
        internal static string Matches => "The {0} field does not match the patter.";
        internal static string MinLength => "The {0} field's length is less than {1}.";
        internal static string MaxLength => "The {0} field's length is greater than {1}.";
        internal static string IsNotEmpty => "The {0} field is empty.";
    }
}