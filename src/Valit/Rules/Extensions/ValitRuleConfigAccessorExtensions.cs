using System;
using System.Collections.Generic;
using System.Text;

namespace Valit
{
    internal static class ValitRuleConfigAccessorExtensions
    {
        internal static IValitRuleConfigAccessor<TProperty> GetAccessor<TProperty>(this IValitRule<TProperty> rule)
        {
            var accessor = rule as IValitRuleConfigAccessor<TProperty>;

            if (accessor == null)
            {
                throw new ArgumentException("Rule doesn't have an accessor");
            }

            return accessor;
        }
    }
}
