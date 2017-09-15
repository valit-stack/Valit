using System;
using System.Collections.Generic;
using System.Text;
using Valit.Enums;

namespace Valit.Rules
{
    internal interface IValitRuleConfigAccessor
    {
        ValitRuleKind Kind { get; set; }
        bool IsSatisfied { get; set; }
        List<string> ErrorMessages { get; }
        IValitRule PreviousRule { get; }
    }

    internal interface IValitRuleConfigAccessor<TProperty> : IValitRuleConfigAccessor
    {
        TProperty Property { get; }
        new IValitRule<TProperty> PreviousRule { get; }
    }
}
