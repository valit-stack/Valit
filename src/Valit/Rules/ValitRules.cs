using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Valit.Enums;
using Valit.Extensions;
using Valit.Result;

namespace Valit.Rules
{
    public class ValitRules<TObject> : IValitRules<TObject> where TObject : class
    {
        private readonly TObject _object;        
        private readonly List<string> _errorMessages;  
        private readonly ValitRulesStrategies _strategy;
        private bool _succeed;      

        private ValitRules(TObject @object, ValitRulesStrategies strategy = ValitRulesStrategies.Complete)
        {
            _object = @object;
            _errorMessages = new List<string>();
            _strategy = strategy;
            _succeed = true;            
        }

        public static IValitRules<TObject> For(TObject @object, ValitRulesStrategies strategy = ValitRulesStrategies.Complete)
            => new ValitRules<TObject>(@object, strategy);

        IValitRules<TObject> IValitRules<TObject>.Ensure<TProperty>(Func<TObject, TProperty> selector, Action<IValitRule<TProperty>> rule)
        {
            if(! _succeed && _strategy == ValitRulesStrategies.FailFaast) 
            {
                return this;
            }

            var property = selector(_object);
            var validationRule = new ValitRule<TProperty>(property);
            var accessor = validationRule.GetAccessor();

            rule(validationRule); 
            _succeed = _succeed && accessor.IsSatisfied;
            _errorMessages.AddRange(accessor.ErrorMessages);
            return this;
        }

        IValitResult IValitRules<TObject>.Validate()
            => _succeed ? ValitResult.CreateSucceeded() : ValitResult.CreateFailed(_errorMessages.ToArray());
        
    }
}
