using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Valit.Enums;
using Valit.Rules;

namespace Valit.Extensions
{
    public static class ValitRuleExtensions
    {
        public static IValitRule<TProperty> Satisifes<TProperty>(this IValitRule<TProperty> step, Func<TProperty, bool> predicate)
        {
            var accessor = step.GetAccessor();
            accessor.Kind = ValitRuleKind.Rule;
            accessor.IsSatisfied = predicate(accessor.Property);
            return new ValitRule<TProperty>(step);
        }

        public static IValitRule<TProperty> Required<TProperty>(this IValitRule<TProperty> step)
        {
            return step.Satisifes(p => p != null && !p.Equals(default(TProperty)));
        }

        public static IValitRule<TProperty> Equals<TProperty>(this IValitRule<TProperty> step, TProperty expectedValue)
        {
            return step.Satisifes(p => p != null && p.Equals(expectedValue));
        }

        //TODO: Check Int64 overflow
        public static IValitRule<TProperty> IsGreaterThan<TProperty>(this IValitRule<TProperty> step, TProperty expectedValue) where TProperty : IComparable
        {
            var typeCode = Type.GetTypeCode(typeof(TProperty));
            return step.Satisifes(p => p != null && expectedValue != null
                && (   typeCode == TypeCode.Int16 || typeCode == TypeCode.Int32 || typeCode == TypeCode.Int64 || typeCode == TypeCode.UInt16 
                    || typeCode == TypeCode.UInt32 || typeCode == TypeCode.UInt64 || typeCode == TypeCode.Double || typeCode == TypeCode.Decimal)
                && Comparer<TProperty>.Default.Compare(p, expectedValue) > 0);
        }

        public static IValitRule<TProperty> IsLessThan<TProperty>(this IValitRule<TProperty> step, TProperty expectedValue) where TProperty : IComparable
        {
            var typeCode = Type.GetTypeCode(typeof(TProperty));
            return step.Satisifes(p => p != null && expectedValue != null
                && (typeCode == TypeCode.Int16 || typeCode == TypeCode.Int32 || typeCode == TypeCode.Int64 || typeCode == TypeCode.UInt16
                    || typeCode == TypeCode.UInt32 || typeCode == TypeCode.UInt64 || typeCode == TypeCode.Double || typeCode == TypeCode.Decimal)
                && Comparer<TProperty>.Default.Compare(p, expectedValue) < 0);
        }

        //need to cast ot string somehow
        public static IValitRule<TProperty> Matches<TProperty>(this IValitRule<TProperty> step, string regularExpression)
        {
            var typeCode = Type.GetTypeCode(typeof(TProperty));
            return step.Satisifes(p => p != null && !String.IsNullOrEmpty(regularExpression) && typeCode == TypeCode.String);
        }

        public static IValitRule<TProperty> Email<TProperty>(this IValitRule<TProperty> step)
        {
            return step.Matches(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
        }

        public static IValitRule<TProperty> WithMessage<TProperty>(this IValitRule<TProperty> step, string message)
        {
            var accessor = step.GetAccessor();
            var previousRuleAccessor = accessor.PreviousRule.GetAccessor();

            if (previousRuleAccessor.Kind == ValitRuleKind.Message) throw new ArgumentException();
            if (!previousRuleAccessor.IsSatisfied) accessor.ErrorMessages.Add(message);

            accessor.Kind = ValitRuleKind.Message;
            return new ValitRule<TProperty>(step);
        }        
    }
}
