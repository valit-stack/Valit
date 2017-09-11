using System;
using System.Collections.Generic;
using System.Text;
using Valit.Enums;
using Valit.Extensions;

namespace Valit.Rules
{
    internal class ValitRule<TProperty> : IValitRule<TProperty>, IValitRuleConfigAccessor<TProperty>
    {
        private readonly List<string> _errorMessages;
        private readonly TProperty _property;
        private readonly IValitRule<TProperty> _previousRule;

        bool IValitRuleConfigAccessor<TProperty>.IsSatisfied { get; set; }

        ValitRuleKind IValitRuleConfigAccessor<TProperty>.Kind { get; set; }

        TProperty IValitRuleConfigAccessor<TProperty>.Property => _property;

        List<string> IValitRuleConfigAccessor<TProperty>.ErrorMessages => _errorMessages;

        IValitRule<TProperty> IValitRuleConfigAccessor<TProperty>.PreviousRule => _previousRule;

        public ValitRule(IValitRule<TProperty> previousRule)
        {
            var previousRuleAccessor = previousRule.GetAccessor();
            _property = previousRuleAccessor.Property;
            _errorMessages = previousRuleAccessor.ErrorMessages;
            _previousRule = previousRule;
        }
    }
}
