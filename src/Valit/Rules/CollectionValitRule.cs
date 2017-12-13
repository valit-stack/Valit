using System;
using System.Collections.Generic;
using System.Linq;
using Valit.Exceptions;
using Valit.Result;

namespace Valit.Rules
{
    internal class CollectionValitRule<TObject, TProperty> : IValitRule<TObject> where TObject : class
    {
        public IEnumerable<string> Tags { get; private set; }

        private readonly Func<TObject, IEnumerable<TProperty>> _collectionSelector;
        private readonly Func<IValitRule<TObject, TProperty>,IValitRule<TObject, TProperty>> _ruleFunc;
        private readonly IValitStrategy _strategy;
        private readonly IValitMessageProvider _messageProvider;

        public CollectionValitRule(
            Func<TObject, IEnumerable<TProperty>> collectionSelector,
            Func<IValitRule<TObject, TProperty>,IValitRule<TObject, TProperty>> ruleFunc,
            IValitStrategy strategy,
            IValitMessageProvider messageProvider)
        {
            Tags = Enumerable.Empty<string>();
            _collectionSelector = collectionSelector;
            _ruleFunc = ruleFunc;
            _strategy = strategy;
            _messageProvider = messageProvider;
        }

        IValitResult IValitRule<TObject>.Validate(TObject @object)
        {
            @object.ThrowIfNull();

            var collection = _collectionSelector(@object);

            var rules = collection.SelectMany(p => 
            {
                Func<TObject, TProperty> selector = _ => p;
                var lastEnsureRule = _ruleFunc(new ValitRule<TObject, TProperty>(selector, _messageProvider));
                return lastEnsureRule.GetAllEnsureRules();
            });

            return rules.ValidateRules(_strategy, @object);
        }
    }
}
