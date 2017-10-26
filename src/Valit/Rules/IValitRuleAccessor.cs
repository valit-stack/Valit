using System;
using System.Collections.Generic;
using System.Text;
using Valit.Errors;

namespace Valit.Rules
{
    internal interface IValitRuleAccessor
    {
        void AddError(ValitRuleError error);
        void AddTags(params string[] tags);
    }
    
    internal interface IValitRuleAccessor<TObject, TProperty> : IValitRuleAccessor where TObject : class
    {
        Func<TObject, TProperty> PropertySelector { get; }
        IValitRule<TObject, TProperty> PreviousRule { get; }
        void SetPredicate(Predicate<TProperty> predicate);     
        void AddCondition(Predicate<TObject> condition);        
    }
}
