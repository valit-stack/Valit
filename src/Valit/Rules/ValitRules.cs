using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Valit
{
    public class ValitRules<TObject> : IValitRules<TObject>, IValitRulesStrategyPicker<TObject> where TObject : class
    {
        private readonly TObject _object;       
        private readonly List<Func<ValitResult>> _rulesResults;
        private ValitRulesStrategies _strategy;


        private ValitRules(TObject @object)
        {
            _object = @object;      
            _rulesResults = new List<Func<ValitResult>>();  
        }

        public static IValitRulesStrategyPicker<TObject> For(TObject @object)
            => new ValitRules<TObject>(@object);

        IValitRules<TObject> IValitRulesStrategyPicker<TObject>.WithStrategy(ValitRulesStrategies strategy)
		{
			_strategy = strategy;
            return this;
		}

        IValitRules<TObject> IValitRules<TObject>.Ensure<TProperty>(Func<TObject, TProperty> selector, Func<IValitRule<TProperty>,IValitRule<TProperty>> ruleFunc)
        {            
            var property = selector(_object);
            Func<ValitResult> ruleResult = () => ((IValitRuleAccessor<TProperty>)ruleFunc(new ValitRule<TProperty>(property))).Validate(); 
            _rulesResults.Add(ruleResult);
            
            return this;
        }

        IValitResult IValitRules<TObject>.Validate()
        {
            var result = ValitResult.CreateSucceeded();

            foreach(var ruleResult in _rulesResults)
                result &= ruleResult();

            return result;
        } 
	}
}
