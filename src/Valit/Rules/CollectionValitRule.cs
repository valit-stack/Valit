using System;
using System.Collections.Generic;
using System.Linq;
using Valit.Exceptions;
using Valit.Result;

namespace Valit.Rules
{
	internal class CollectionValitRule<TObject, TProperty> : IValitRule<TObject> where TObject : class
	{
		IEnumerable<string> IValitRule.Tags => Enumerable.Empty<string>();

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
            _collectionSelector = collectionSelector;
			_ruleFunc = ruleFunc;
            _strategy = strategy;
			_messageProvider = messageProvider;
        }

		IValitResult IValitRule<TObject>.Validate(TObject @object)
		{
			@object.ThrowIfNull();

			var collection = _collectionSelector(@object);

			var result = ValitResult.Success;

			foreach(var property in collection)
			{
				Func<TObject, TProperty> selector = _ => property;
				var lastEnsureRule = _ruleFunc(new ValitRule<TObject, TProperty>(selector, _messageProvider));
            	var propertyRules = lastEnsureRule.GetAllEnsureRules();

				result &= ValidatePropertyRules(propertyRules, @object);

                if(!result.Succeeded)
                {
                    _strategy.Fail(default(IValitRule<TObject>), result, out bool cancel);
                    if(cancel)
                    {
                        break;
                    }
                }
			}

			return result;
		}

		private IValitResult ValidatePropertyRules(IEnumerable<IValitRule<TObject>> propertyRules, TObject @object)
			=> ValitRules<TObject>
				.Create(propertyRules)
				.WithStrategy(_strategy)
				.For(@object)
				.Validate();
	}
}