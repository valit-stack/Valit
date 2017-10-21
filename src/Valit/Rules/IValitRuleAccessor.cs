using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Valit
{
    internal interface IValitRuleAccessor
    {
        void AddError(ValitRuleError error);
        void AddTags(params string[] tags);
    }
    
    internal interface IValitRuleAccessor<TObject, TProperty> : IValitRuleAccessor where TObject : class
    {
        Expression<Func<TObject, TProperty>> PropertySelector { get; }
        IValitRule<TObject, TProperty> PreviousRule { get; }
        void SetPredicate(Predicate<TProperty> predicate);     
        void AddCondition(Predicate<TObject> condition);        
    }
}
