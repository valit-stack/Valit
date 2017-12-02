using System;
using System.Collections.Generic;
using Valit.Errors;
using Valit.Exceptions;
using Valit.Result;

namespace Valit.Rules
{
    internal class ValitRule<TObject, TProperty> : IValitRule<TObject, TProperty>, IValitRuleAccessor<TObject, TProperty> where TObject : class
    {
        public IEnumerable<string> Tags => _tags;

        Func<TObject, TProperty> IValitRuleAccessor<TObject, TProperty>.PropertySelector => _propertySelector;
        IValitRule<TObject, TProperty> IValitRuleAccessor<TObject, TProperty>.PreviousRule => _previousRule;

        private readonly Func<TObject, TProperty> _propertySelector;
        private Predicate<TProperty> _predicate;
        private readonly List<Predicate<TObject>> _conditions;
        private readonly IValitRule<TObject, TProperty> _previousRule;
        private readonly List<ValitRuleError> _errors;
        private readonly List<string> _tags;
        private readonly IValitMessageProvider _messageProvider;

        internal ValitRule(IValitRule<TObject, TProperty> previousRule) : this()
        {
            var previousRuleAccessor = previousRule.GetAccessor();
            _propertySelector = previousRuleAccessor.PropertySelector;
            _previousRule = previousRule;
            _messageProvider = previousRuleAccessor.GetMessageProvider();
        }

        internal ValitRule(Func<TObject, TProperty> propertySelector, IValitMessageProvider messageProvider) : this()
        {
            _propertySelector = propertySelector;
            _messageProvider = messageProvider;
        }

        private ValitRule()
        {
            _errors = new List<ValitRuleError>();
            _conditions = new List<Predicate<TObject>>();
            _tags = new List<string>();
        }

        void IValitRuleAccessor<TObject, TProperty>.SetPredicate(Predicate<TProperty> predicate)
            => _predicate = predicate;

        bool IValitRuleAccessor.HasPredicate()
            => _predicate != null;

        void IValitRuleAccessor.AddError(ValitRuleError error)
            => _errors.Add(error);

        void IValitRuleAccessor<TObject, TProperty>.AddCondition(Predicate<TObject> condition)
            => _conditions.Add(condition);

        void IValitRuleAccessor.AddTags(params string[] tags)
            => _tags.AddRange(tags);

        IValitMessageProvider IValitRuleAccessor.GetMessageProvider()
            => _messageProvider;

        IValitMessageProvider<TKey> IValitRuleAccessor.GetMessageProvider<TKey>()
            => _messageProvider as IValitMessageProvider<TKey>;

        public IValitResult Validate(TObject @object)
        {
            @object.ThrowIfNull();

            var property = _propertySelector(@object);
            var hasAllConditionsFulfilled = true;

            foreach(var condition in _conditions)
                hasAllConditionsFulfilled &= condition(@object);

            var isSatisfied = _predicate?.Invoke(property) != false;

            return !hasAllConditionsFulfilled || isSatisfied ? ValitResult.Success : ValitResult.Fail(_errors.ToArray());
        }
    }
}
