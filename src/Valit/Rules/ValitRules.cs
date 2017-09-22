using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Valit
{
    public class ValitRules<TObject> : IValitRules<TObject>, IValitRulesStrategyPicker<TObject> where TObject : class
    {
        private readonly TObject _object;        
        private readonly List<string> _errorMessages;  
        private ValitRulesStrategies _strategy;
        private bool _succeed;      

        private ValitRules(TObject @object)
        {
            _object = @object;
            _errorMessages = new List<string>();
            _succeed = true;            
        }

        public static IValitRulesStrategyPicker<TObject> For(TObject @object)
            => new ValitRules<TObject>(@object);

        IValitRules<TObject> IValitRulesStrategyPicker<TObject>.WithStrategy(ValitRulesStrategies strategy)
		{
			_strategy = strategy;
            return this;
		}

        IValitRules<TObject> IValitRules<TObject>.Ensure<TProperty>(Func<TObject, TProperty> selector, Func<IValitRule<TProperty>,IValitRule<TProperty>> rule)
        {
            
            var property = selector(_object);
            var validationRule = rule(new ValitRule<TProperty>(property)); 
            
            var ruleAccessor = validationRule.GetAccessor();
            var currentRuleResult = ruleAccessor.Validate();

            _succeed &= currentRuleResult.Succeeded;
            _errorMessages.AddRange(currentRuleResult.Errors);
            return this;
        }

        IValitResult IValitRules<TObject>.Validate()
            => _succeed ? ValitResult.CreateSucceeded() : ValitResult.CreateFailed(_errorMessages.ToArray());		
	}
}
