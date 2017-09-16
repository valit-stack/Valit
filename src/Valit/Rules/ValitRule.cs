using System;
using System.Collections.Generic;
using System.Text;
using Valit.Enums;
using Valit.Extensions;

namespace Valit.Rules
{
    internal class ValitRule<TProperty> : IValitRule<TProperty>, IValitRuleConfigAccessor<TProperty>
    {        
        bool IValitRuleConfigAccessor.IsSatisfied { get; set; }
        ValitRuleKinds IValitRuleConfigAccessor.Kind { get; set; }
        List<string> IValitRuleConfigAccessor.ErrorMessages => _errorMessages;
        
        TProperty IValitRuleConfigAccessor<TProperty>.Property => _property;
        IValitRule<TProperty> IValitRuleConfigAccessor<TProperty>.PreviousRule => _previousRule;

        private readonly List<string> _errorMessages;
        private readonly TProperty _property;
        private readonly IValitRule<TProperty> _previousRule;

        internal ValitRule(IValitRule<TProperty> previousRule)
        {
            var previousRuleAccessor = previousRule.GetAccessor();
            _property = previousRuleAccessor.Property;
            _errorMessages = previousRuleAccessor.ErrorMessages;
            _previousRule = previousRule;
        }

        internal ValitRule(TProperty property)
        {
            _property = property;
            _previousRule = null;
            _errorMessages = new List<string>();
        }
    }
}
