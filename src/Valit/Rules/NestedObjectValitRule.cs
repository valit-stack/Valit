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
        private readonly IValitMessageProvider _messageProvider;
        private readonly IValitStrategy _strategy;

        public NestedObjectValitRule(
            Func<TObject, TProperty> selector, 
            IValitRulesProvider<TProperty> valitRulesProvider, 
            IValitMessageProvider messageProvider, IValitStrategy strategy)
        {
            _propertySelector = selector;
            _valitRulesProvider = valitRulesProvider;
            _messageProvider = messageProvider;
            _strategy = strategy;
        }

		public IValitResult Validate(TObject @object)
        {
            var valitRules = _valitRulesProvider.GetValitRules();
            var property = _propertySelector(@object);

            return ValitRules<TProperty>
                .Create(valitRules)
                .WithMessageProvider(_messageProvider as IValitMessageProvider<TObject>)
                .WithStrategy(_strategy)
                .For(property)
                .Validate();
        }
                    

	}
}