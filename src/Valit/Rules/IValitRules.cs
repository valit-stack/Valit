using System;
using System.Collections.Generic;

namespace Valit
{
    public interface IValitRules<TObject> where TObject : class
    {
         IValitRules<TObject> Ensure<TProperty>(Func<TObject, TProperty> selector, Func<IValitRule<TObject, TProperty>,IValitRule<TObject, TProperty>> rule);
         IEnumerable<IValitRule<TObject>> GetTaggedRules();
         IEnumerable<IValitRule<TObject>> GetUntaggedRules();
         IValitResult Validate();
         IValitResult Validate(params string[] tags);
         IValitResult Validate(Func<IValitRule<TObject>, bool> predicate);
    }
}