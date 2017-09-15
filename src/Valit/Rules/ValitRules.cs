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
        private static object _previousStep;

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
            _previousStep = _previousStep ?? new ValitRule<TProperty>(property);
            var validationStep = new ValitRule<TProperty>(_previousStep as IValitRule<TProperty>);
            rule(validationStep);
            _previousStep = validationStep;
            return new ValitRules<TObject>(_object, _errorMessages);
        }

        public IValitResult Validate()
        {
            var tail = _previousStep as IValitRuleConfigAccessor;
            var succeded = tail?.IsSatisfied;
            while(tail != null && succeded.HasValue && succeded.Value)
            {
                succeded = tail?.IsSatisfied;
                tail = tail.PreviousRule as IValitRuleConfigAccessor;
            }
            return !succeded.HasValue || !succeded.Value || _errorMessages.Any() ? 
                ValitResult.CreateFailed(_errorMessages.ToArray()) 
              : ValitResult.CreateSucceeded();
        }
    }
}
