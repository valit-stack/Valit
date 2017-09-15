using System;
using System.Collections.Generic;
using System.Text;
using Valit.Enums;

namespace Valit.Rules
{
    internal interface IValitRuleConfigAccessor<TProperty>
    {
        TProperty Property { get; }
        IValitRule<TProperty> PreviousRule { get; } 
        ValitRuleKinds Kind { get; set; }
        bool IsSatisfied { get; set; }
        List<string> ErrorMessages { get; }
    }
}
