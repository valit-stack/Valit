using System;
using System.Collections.Generic;
using Valit.MessageProvider;
using System.Linq.Expressions;
using Valit.Strategies;

namespace Valit
{
    public class ValitRule<TTarget, TProperty> : IValitRule<TTarget, TProperty>, IValitRuleAccessor<TTarget, TProperty> where TTarget : class
    {
		public IValitStrategy Strategy { get; }
        public IEnumerable<string> Tags => _tags;

        Expression<Func<TTarget, TProperty>> IValitRuleAccessor<TTarget, TProperty>.PropertySelector => _propertySelector;
        IValitRule<TTarget, TProperty> IValitRuleAccessor<TTarget, TProperty>.PreviousRule => _previousRule;

		private readonly Expression<Func<TTarget, TProperty>> _propertySelector;
        private Predicate<TProperty> _predicate;
        private readonly List<Predicate<TTarget>> _conditions;
        private readonly IValitRule<TTarget, TProperty> _previousRule;
		private readonly List<ValitRuleError> _errors;
        private readonly List<string> _tags;
        private readonly IValitMessageProvider _messageProvider;

        protected internal ValitRule(IValitRule<TTarget, TProperty> previousRule) : this()
        {
            var previousRuleAccessor = previousRule.GetAccessor();
            _propertySelector = previousRuleAccessor.PropertySelector;
            _previousRule = previousRule;
            _messageProvider = previousRule.GetMessageProvider();
            Strategy = previousRule.Strategy;
        }

        protected internal ValitRule(Expression<Func<TTarget, TProperty>> propertySelector, IValitStrategy strategy, IValitMessageProvider messageProvider) : this()
        {
            _propertySelector = propertySelector;
            _messageProvider = messageProvider;
            Strategy = strategy;
        }

        private ValitRule()
        {        
            _errors = new List<ValitRuleError>();
            _conditions = new List<Predicate<TTarget>>();
            _tags = new List<string>();
        }		

		void IValitRuleAccessor<TTarget, TProperty>.SetPredicate(Predicate<TProperty> predicate)
            => _predicate = predicate;

		void IValitRuleAccessor.AddError(ValitRuleError error)
            => _errors.Add(error);

		void IValitRuleAccessor<TTarget, TProperty>.AddCondition(Predicate<TTarget> condition)
            => _conditions.Add(condition);		

		void IValitRuleAccessor.AddTags(params string[] tags)
            => _tags.AddRange(tags);

        IValitMessageProvider IValitRule.GetMessageProvider()
            => _messageProvider;

        IValitMessageProvider<TKey> IValitRule.GetMessageProvider<TKey>()
            => _messageProvider as IValitMessageProvider<TKey>;

        public virtual IValitResult Validate(TTarget target)
		{
            var property = _propertySelector.Compile()(target);
			var hasAllConditionsFulfilled = true;

            foreach(var condition in _conditions)
                hasAllConditionsFulfilled &= condition(target);

            var isSatisfied = _predicate?.Invoke(property) != false;

            return _errors.Count == 0 && hasAllConditionsFulfilled && isSatisfied ? ValitResult.Success : ValitResult.Fail(_errors.ToArray());		
        }
	}
}
