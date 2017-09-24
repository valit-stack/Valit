using System;
using System.Collections.Generic;
using System.Text;

namespace Valit
{
    internal static class ValitRuleAccessorExtensions
    {
        internal static IValitRuleAccessor<TProperty> GetAccessor<TProperty>(this IValitRule<TProperty> rule)
        {
            var accessor = rule as IValitRuleAccessor<TProperty>;

            if (accessor == null)
            {
                throw new ArgumentException("Rule doesn't have an accessor");
            }

            return accessor;
        }
    }
}
