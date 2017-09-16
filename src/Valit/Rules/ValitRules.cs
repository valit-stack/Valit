using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Valit.Enums;
using Valit.Extensions;
using Valit.Result;

namespace Valit.Rules
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

        IValitRules<TObject> IValitRules<TObject>.Ensure<TProperty>(Func<TObject, TProperty> selector, Action<IValitRule<TProperty>> rule)
        {
            if(! _succeed && _strategy == ValitRulesStrategies.FailFaast) 
            {
                return this;
            }

            var property = selector(_object);
            var validationRule = new ValitRule<TProperty>(property);
            var accessor = validationRule.GetAccessor();

            rule(validationRule); 
            _succeed = _succeed && accessor.IsSatisfied;
            _errorMessages.AddRange(accessor.ErrorMessages);
            return this;
        }

        IValitResult IValitRules<TObject>.Validate()
            => _succeed ? ValitResult.CreateSucceeded() : ValitResult.CreateFailed(_errorMessages.ToArray());

		
	}
}
