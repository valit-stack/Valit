using System;
using System.Collections.Generic;
using System.Linq;
using Valit.Exceptions;

namespace Valit.Rules
{
    internal class NestedObjectValitRule<TObject, TProperty> : IValitRule<TObject> where TObject : class where TProperty : class
    {
        public IEnumerable<string> Tags { get; set; }
        private readonly Func<TObject, TProperty> _propertySelector;
        private readonly IValitator<TProperty> _valitator;
        private readonly IValitStrategy _strategy;

        public NestedObjectValitRule(
            Func<TObject, TProperty> selector,
            IValitRulesProvider<TProperty> valitRulesProvider,
            IValitStrategy strategy)
        {
            Tags = Enumerable.Empty<string>();
            _propertySelector = selector;
            _valitator = valitRulesProvider.CreateValitator();
            _strategy = strategy;
        }

        public IValitResult Validate(TObject @object)
        {
            @object.ThrowIfNull();

            var property = _propertySelector(@object);
            return _valitator.Validate(property, _strategy);
        }

        public IEnumerable<IValitRule<TObject>> GetEnsureRules(TObject @object)
        {
            return new List<IValitRule<TObject>>{ this };
        }                 
	}
}
