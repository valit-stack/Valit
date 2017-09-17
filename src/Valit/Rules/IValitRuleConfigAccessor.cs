using System;
using System.Collections.Generic;
using System.Text;
using Valit.Enums;

namespace Valit.Rules
{
    internal interface IValitRuleConfigAccessor
    {
        bool IsSatisfied { get; set; }
        List<string> ErrorMessages { get; }
    }
    
    internal interface IValitRuleConfigAccessor<TProperty> : IValitRuleConfigAccessor
    {
        TProperty Property { get; }
        IValitRule<TProperty> PreviousRule { get; }        
    }
}
