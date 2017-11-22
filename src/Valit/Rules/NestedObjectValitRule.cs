using System;
using System.Collections.Generic;
using System.Linq;

namespace Valit.Rules
{
	internal class NestedObjectValitRule<TObject, TProperty> : IValitRule<TObject> where TObject : class where TProperty : class
	{
		public IEnumerable<string> Tags => Enumerable.Empty<string>();
        private readonly Func<TObject, TProperty> _propertySelector;
        private readonly IValitRulesProvider<TProperty> _valitRulesProvider;
        private readonly IValitStrategy _strategy;

        public NestedObjectValitRule(
            Func<TObject, TProperty> selector, 
            IValitRulesProvider<TProperty> valitRulesProvider,
            IValitStrategy strategy)
        {
            _propertySelector = selector;
            _valitRulesProvider = valitRulesProvider;
            _strategy = strategy;
        }

		public IValitResult Validate(TObject @object)
        {
            var valitRules = _valitRulesProvider.GetRules();
            var property = _propertySelector(@object);

            return ValitRules<TProperty>
                .Create(valitRules)
                .WithStrategy(_strategy)
                .For(property)
                .Validate();
        }                  
	}
}