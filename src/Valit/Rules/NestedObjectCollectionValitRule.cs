using System;
using System.Collections.Generic;
using System.Linq;
using Valit.Exceptions;
using Valit.Result;

namespace Valit.Rules
{
    internal class NestedObjectCollectionValitRule<TObject, TProperty> : IValitRule<TObject> where TObject : class where TProperty : class
	{
		public IEnumerable<string> Tags { get; private set; }
        private readonly Func<TObject, IEnumerable<TProperty>> _collectionSelector;
        private readonly IValitRulesProvider<TProperty> _valitRulesProvider;
        private readonly IValitStrategy _strategy;

        public NestedObjectCollectionValitRule(
			Func<TObject, IEnumerable<TProperty>> collectionSelector, 
			IValitRulesProvider<TProperty> valitRulesProvider,
			IValitStrategy strategy)
        {
            Tags = Enumerable.Empty<string>();
            _collectionSelector = collectionSelector;
			_valitRulesProvider = valitRulesProvider;
            _strategy = strategy;
        }

        IValitResult IValitRule<TObject>.Validate(TObject @object)
		{
            @object.ThrowIfNull();
            
            var collection = _collectionSelector(@object);

			var result = ValitResult.Success;

			foreach(var property in collection)
			{
				Func<TObject, TProperty> selector = _ => property;
				var nestedObjectValitRule = new NestedObjectValitRule<TObject, TProperty>(selector, _valitRulesProvider, _strategy);

				result &= nestedObjectValitRule.Validate(@object);

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
        
    }
}