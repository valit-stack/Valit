using System;
using System.Collections.Generic;

namespace Valit
{
    public interface IValitRules<TObject> where TObject : class
    {
         IValitRules<TObject> Ensure<TProperty>(Func<TObject, TProperty> selector, Func<IValitRule<TProperty>,IValitRule<TProperty>> rule);
         IValitRules<TObject> EnsureFor<TProperty>(Func<TObject, IEnumerable<TProperty>> selector, Func<IValitRule<TProperty>,IValitRule<TProperty>> ruleFunc);
         IValitResult Validate();
    }
}