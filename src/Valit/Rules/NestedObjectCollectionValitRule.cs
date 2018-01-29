using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Valit.Exceptions;
using Valit.Result;

namespace Valit.Rules
{
    internal class NestedObjectCollectionValitRule<TObject, TProperty> : IValitRule<TObject> where TObject : class where TProperty : class
    {
        public IEnumerable<string> Tags { get; private set; }
        private readonly Expression<Func<TObject, IEnumerable<TProperty>>> _collectionSelector;
        private readonly IValitator<TProperty> _valitator;
        private readonly IValitStrategy _strategy;

        public NestedObjectCollectionValitRule(
            Expression<Func<TObject, IEnumerable<TProperty>>> collectionSelector,
            IValitator<TProperty> valitator,
            IValitStrategy strategy)
        {
            Tags = Enumerable.Empty<string>();
            _collectionSelector = collectionSelector;
            _valitator = valitator;
            _strategy = strategy;
        }

        IValitResult IValitRule<TObject>.Validate(TObject @object)
        {
            @object.ThrowIfNull();

            var collection = _collectionSelector.Compile().Invoke(@object);

            var rules = collection.Select(p => 
            {
                Expression<Func<TObject, TProperty>> selector = _ => p;
                return new NestedObjectValitRule<TObject, TProperty>(selector, _valitator, _strategy);
            });

            return rules.ValidateRules(_strategy, @object);
        }

    }
}
