using System;
using System.Collections.Generic;

namespace Valit
{
    public interface IValitRules<TObject> where TObject : class
    {
         IValitRules<TObject> Ensure<TProperty>(Func<TObject, TProperty> selector, Func<IValitRule<TObject, TProperty>,IValitRule<TObject, TProperty>> rule);
         IValitRules<TObject> EnsureFor<TProperty>(Func<TObject, IEnumerable<TProperty>> selector, Func<IValitRule<TObject, TProperty>,IValitRule<TObject, TProperty>> ruleFunc);
         IValitResult Validate();
    }
}