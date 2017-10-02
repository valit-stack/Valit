using System;
using System.Collections.Generic;
using System.Text;

namespace Valit
{
    internal interface IValitRuleAccessor
    {
        void AddErrorMessage(string message);
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
