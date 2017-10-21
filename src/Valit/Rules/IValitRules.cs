using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Valit
{
    public interface IValitRules<TObject> where TObject : class
    {
         IValitRules<TObject> Ensure<TProperty>(Expression<Func<TObject, TProperty>> selector, Func<IValitRule<TObject, TProperty>,IValitRule<TObject, TProperty>> rule);
         IValitRules<TObject> For(TObject @object);
         IEnumerable<IValitRule<TObject>> GetTaggedRules();
         IEnumerable<IValitRule<TObject>> GetUntaggedRules();         
         IValitResult Validate();
         IValitResult Validate(params string[] tags);
         IValitResult Validate(Func<IValitRule<TObject>, bool> predicate);        
    }
}