using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Valit.Result;

namespace Valit.Rules
{
    public class ValitRules<TObject>
    {
        private List<string> _errorMessages;
        private TObject _object;

        private ValitRules(TObject @object, List<string> errorMessages)
        {
            _object = @object;
            _errorMessages = errorMessages;
        }

        public static ValitRules<TObject> For(TObject @object)
            => new ValitRules<TObject>(@object, new List<string>());

        public ValitRules<TObject> Ensure<TProperty>(Func<TObject, TProperty> selector, Action<IValitRule<TProperty>> rule)
        {
            var property = selector(_object);
            var validationStep = new ValitRule<TProperty>(null);
            rule(validationStep);
            return new ValitRules<TObject>(_object, _errorMessages);
        }

        public IValitResult Validate()
        {
            return _errorMessages.Any() ? 
                ValitResult.CreateFailed(_errorMessages.ToArray()) 
              : ValitResult.CreateSucceeded();
        }
    }
}
