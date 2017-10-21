namespace Valit
{
    internal static class ValitExceptionMessages
    {
        public static string NullRule => "Valit rule is null";
        public static string NullPredicate => "Given predicate is null";
        public static string NullTargetObject => "Target object is null";
        public static string NullDereferenced => "Dereferenced a null";
        public static string MissingRuleAccessor => "Rule doesn't have an accessor";
        public static string IncorrectPathExpression => "The path can only contain fields or properties";
    }
}