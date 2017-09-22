using System;
using System.Collections.Generic;
using System.Text;

namespace Valit
{
    internal interface IValitRuleAccessor
    {
        void SetFailure();
        void AddErrorMessage(string message);
        void AddCondition(Func<bool> predicate);
        ValitResult Validate();
    }
    
    internal interface IValitRuleAccessor<TProperty> : IValitRuleAccessor
    {
        TProperty Property { get; }
        IValitRule<TProperty> PreviousRule { get; }        
    }
}
