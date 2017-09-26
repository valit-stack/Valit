using System;
using System.Collections.Generic;
using System.Text;

namespace Valit
{
    internal interface IValitRuleAccessor
    {
        void AddErrorMessage(string message);
        void AddCondition(Func<bool> predicate);
    }
    
    internal interface IValitRuleAccessor<TObject, TProperty> : IValitRuleAccessor where TObject : class
    {
        Func<TObject, TProperty> PropertySelector { get; }
        IValitRule<TObject, TProperty> PreviousRule { get; }
        void SetPredicate(Predicate<TProperty> predicate);     
    }
}
