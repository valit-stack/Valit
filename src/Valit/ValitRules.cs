using System;
using System.Collections.Generic;
using System.Linq;
using Valit.Exceptions;
using Valit.MessageProvider;
using Valit.Result;
using Valit.Rules;

namespace Valit
{
    public class ValitRules<TObject> :
        IValitRules<TObject>,
        IValitRulesMessageProvider<TObject>,
        IValitRulesStrategyPicker<TObject>
        where TObject : class
    {
        private TObject _object;
        private readonly List<IValitRule<TObject>> _rules;
        private IValitStrategy _strategy;
        private IValitMessageProvider _messageProvider;

        private ValitRules(IEnumerable<IValitRule<TObject>> rules)
        {
            _rules = rules?.ToList() ?? new List<IValitRule<TObject>>();
            _strategy = default(DefaultValitStrategies).Complete;
            _messageProvider = new EmptyMessageProvider();
        }

        public static IValitRulesMessageProvider<TObject> Create(IEnumerable<IValitRule<TObject>> rules = null)
            => new ValitRules<TObject>(rules);

        IValitRulesStrategyPicker<TObject> IValitRulesMessageProvider<TObject>.WithMessageProvider<TKey>(IValitMessageProvider<TKey> messageProvider)
        {
            _messageProvider = messageProvider;
            return this;
        }

        IValitRules<TObject> IValitRulesStrategyPicker<TObject>.WithStrategy(IValitStrategy strategy)
        {
            _strategy = strategy;
            return this;
        }

        IValitRules<TObject> IValitRules<TObject>.Ensure<TProperty>(Func<TObject, TProperty> selector, Func<IValitRule<TObject, TProperty>, IValitRule<TObject, TProperty>> ruleFunc)
        {
            selector.ThrowIfNull();
            ruleFunc.ThrowIfNull();

            AddEnsureRules(selector, ruleFunc);
            return this;
        }

        IValitRules<TObject> IValitRules<TObject>.Ensure<TProperty>(Func<TObject, TProperty> selector, IValitRulesProvider<TProperty> valitRulesProvider)
        {
            selector.ThrowIfNull();
            valitRulesProvider.ThrowIfNull();

            var nestedValitRule = new NestedObjectValitRule<TObject, TProperty>(selector, valitRulesProvider, _strategy);
            _rules.Add(nestedValitRule);
            return this;
        }

        IValitRules<TObject> IValitRules<TObject>.Ensure<TProperty>(Func<TObject, TProperty> selector, Func<IValitRule<TObject, TProperty>, TObject, IValitRule<TObject, TProperty>> ruleFunc)
        {
            selector.ThrowIfNull();
            ruleFunc.ThrowIfNull();

            var lastEnsureRule = new ValitRule<TObject, TProperty>(selector, _messageProvider, ruleFunc);
            _rules.Add(lastEnsureRule);
            return this;
        }

        IValitRules<TObject> IValitRules<TObject>.EnsureFor<TProperty>(Func<TObject, IEnumerable<TProperty>> selector, Func<IValitRule<TObject, TProperty>, IValitRule<TObject, TProperty>> ruleFunc)
        {
            selector.ThrowIfNull();
            ruleFunc.ThrowIfNull();

            var collectionValitRule = new CollectionValitRule<TObject, TProperty>(selector, ruleFunc, _strategy, _messageProvider);
            _rules.Add(collectionValitRule);
            return this;
        }

        IValitRules<TObject> IValitRules<TObject>.EnsureFor<TProperty>(Func<TObject, IEnumerable<TProperty>> selector, IValitRulesProvider<TProperty> valitRulesProvider)
        {
            selector.ThrowIfNull();
            valitRulesProvider.ThrowIfNull();

            var collectionValitRule = new NestedObjectCollectionValitRule<TObject, TProperty>(selector, valitRulesProvider, _strategy);
            _rules.Add(collectionValitRule);
            return this;
        }

        IValitRules<TObject> IValitRules<TObject>.For(TObject @object)
        {
            @object.ThrowIfNull();

            _object = @object;
            return this;
        }

        IEnumerable<IValitRule<TObject>> IValitRules<TObject>.GetAllRules()
            => _rules;

        IEnumerable<IValitRule<TObject>> IValitRules<TObject>.GetTaggedRules()
            => _rules.Where(r => r.Tags.Any());

        IEnumerable<IValitRule<TObject>> IValitRules<TObject>.GetUntaggedRules()
            => _rules.Where(r => !r.Tags.Any());

        IValitResult IValitRules<TObject>.Validate()
            => Validate(_rules);

        IValitResult IValitRules<TObject>.Validate(params string[] tags)
        {
            tags.ThrowIfNull();
            var taggedRules = _rules.Where(r => r.Tags.Intersect(tags).Any());

            return Validate(taggedRules);
        }

        IValitResult IValitRules<TObject>.Validate(Func<IValitRule<TObject>, bool> predicate)
        {
            predicate.ThrowIfNull(ValitExceptionMessages.NullPredicate);
            var taggedRules = _rules.Where(predicate);

            return Validate(taggedRules);
        }

        private IValitResult Validate(IEnumerable<IValitRule<TObject>> rules)
        {
            var result = ValitResult.Success;
            foreach(var rule in rules.ToList())
            {
                result &= ValidateRule(rule, out bool cancel);
                if (cancel)
                {
                    break;
                }
            }

            _strategy.Done(result);

            return result;
        }

        private IValitResult ValidateRule(IValitRule<TObject> rule, out bool cancelValidation)
        {
            var result = ValitResult.Success;
            cancelValidation = false;
            var ensureRules = rule is IValitRuleAccessor<TObject> ?
                rule.GetAccessor().GetEnsureRules(_object) :
                new[] { rule };
            foreach(var ensureRule in ensureRules)
            {
                result &= ensureRule.Validate(_object);
                if (!result.Succeeded)
                {
                    _strategy.Fail(ensureRule, result, out bool cancel);
                    if (cancel)
                    {
                        cancelValidation = true;
                        break;
                    }
                }
            }

            return result;
        }

        private void AddEnsureRules<TProperty>(Func<TObject,TProperty> propertySelector, Func<IValitRule<TObject, TProperty>,IValitRule<TObject, TProperty>> ruleFunc)
        {
            var lastEnsureRule = ruleFunc(new ValitRule<TObject, TProperty>(propertySelector, _messageProvider));
            var ensureRules = lastEnsureRule.GetAllEnsureRules();
            _rules.AddRange(ensureRules);
        }
    }
}
