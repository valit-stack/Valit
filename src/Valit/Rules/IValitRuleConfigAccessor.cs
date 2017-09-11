using System;
using System.Collections.Generic;
using System.Text;
using Valit.Enums;

namespace Valit.Rules
{
    internal interface IValitRuleConfigAccessor<TProperty>
    {
        bool IsSatisfied { get; set; }
        ValitRuleKind Kind { get; set; }
        TProperty Property { get; }
        List<string> ErrorMessages { get; }
        IValitRule<TProperty> PreviousRule { get; }
    }
}
