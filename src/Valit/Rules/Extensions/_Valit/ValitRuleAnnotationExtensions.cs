using System;
using System.Collections.Generic;
using System.Text;
using Valit.Rules;

namespace Valit
{
    public static class ValitRuleAnnotationExtensions
    {
        public static IValitRule<TTarget, TProperty> WithAnnotations<TTarget, TProperty>(this IValitRule<TTarget, TProperty> rule)
            where TTarget : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
          
            return new AnnotationValitRule<TTarget, TProperty>(rule);
        }
    }
}
