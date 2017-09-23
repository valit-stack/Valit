using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Valit;

namespace Valit
{
    internal class ValitRule<TProperty> : IValitRule<TProperty>, IValitRuleAccessor<TProperty>
    {
        TProperty IValitRuleAccessor<TProperty>.Property => _property;
        IValitRule<TProperty> IValitRuleAccessor<TProperty>.PreviousRule => _previousRule;
		ValitRulesStrategies IValitRuleAccessor.Strategy => _strategy;

		private readonly List<string> _errorMessages;
        private readonly TProperty _property;
        private readonly IValitRule<TProperty> _previousRule;
        private readonly List<Func<bool>> _conditions;
        private readonly ValitRulesStrategies _strategy;
        private Predicate<TProperty> _predicate;

        internal ValitRule(IValitRule<TProperty> previousRule) : this()
        {
            var previousRuleAccessor = previousRule.GetAccessor();
            _property = previousRuleAccessor.Property;
            _previousRule = previousRule;
            _strategy = previousRuleAccessor.Strategy;
        }

        internal ValitRule(TProperty property, ValitRulesStrategies strategy) : this()
        {
            _property = property;
            _previousRule = new ValitRule<TProperty>();
            _strategy = strategy;
        }

        private ValitRule()
        {            
            _errorMessages = new List<string>();
            _conditions = new List<Func<bool>>();
        }		

		void IValitRuleAccessor<TProperty>.SetPredicate(Predicate<TProperty> predicate)
		{
			_predicate = predicate;
		}

		void IValitRuleAccessor.AddErrorMessage(string message)
		{
			_errorMessages.Add(message);
		}

		void IValitRuleAccessor.AddCondition(Func<bool> predicate)
		{
			_conditions.Add(predicate);
		}

		ValitResult IValitRuleAccessor.Validate()
		{
			if(_previousRule == null)
            {
                return GetOwnResult();
            }
            else
            {
                var previousRuleAccessor = _previousRule.GetAccessor();
                var previousRuleResult = previousRuleAccessor.Validate();

                if(_strategy == ValitRulesStrategies.FailFast && !previousRuleResult.Succeeded)
                {
                    return previousRuleResult;
                }
                else 
                {
                    return previousRuleResult & GetOwnResult();
                }                
            }
		}

        private ValitResult GetOwnResult()
        {
            var hasAllConditionsFulfilled = true;

            foreach(var condition in _conditions)
                hasAllConditionsFulfilled &= condition();

            var isSatisfied = (_predicate == null) ? true : _predicate(_property);

            return hasAllConditionsFulfilled && !isSatisfied? ValitResult.CreateFailed(_errorMessages.ToArray()) : ValitResult.CreateSucceeded();
        }
	}
}
