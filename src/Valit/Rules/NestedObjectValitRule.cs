using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Valit.Exceptions;

namespace Valit.Rules
{
    internal class NestedObjectValitRule<TObject, TProperty> : IValitRule<TObject> where TObject : class where TProperty : class
    {
        public IEnumerable<string> Tags { get; set; }
        private readonly Expression<Func<TObject, TProperty>> _propertySelector;
        private readonly IValitator<TProperty> _valitator;
        private readonly IValitStrategy _strategy;

        public NestedObjectValitRule(
            Expression<Func<TObject, TProperty>> propertySelector,
            IValitator<TProperty> valitator,
            IValitStrategy strategy)
        {
            Tags = Enumerable.Empty<string>();
            _propertySelector = propertySelector;
            _valitator = valitator;
            _strategy = strategy;
        }

        public IValitResult Validate(TObject @object)
        {
            @object.ThrowIfNull();

            var property = _propertySelector.Compile().Invoke(@object);
            return _valitator.Validate(property, _strategy);
        }
    }
}
