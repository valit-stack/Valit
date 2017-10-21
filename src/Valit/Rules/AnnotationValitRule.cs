using System.ComponentModel.DataAnnotations;
using Valit.Expressions;
using System.Linq;
using System.Reflection;
using static Valit.Exceptions.SemanticExceptions;
using System.ComponentModel;
using System.Collections.Generic;
using System;

namespace Valit.Rules
{
    public class AnnotationValitRule<TTarget, TProperty> : ValitRule<TTarget, TProperty> where TTarget : class
    {
        public AnnotationValitRule(IValitRule<TTarget, TProperty> previousRule) 
            : base(previousRule)
        {
        }

        public override IValitResult Validate(TTarget target)
        {
            var accessor = this.GetAccessor();

            var context = new ValidationContext(target); // TODO: support IServiceProvider here, IDictionary<object, object> items
            // context.InitializeServiceProvider(...) // alternativeToServiceProvider

            var member = PropertyPath<TTarget>.GetRightToLeft(accessor.PropertySelector).FirstOrDefault();
            if (member == null)
                throw IncorrectPathExpression();

            var validators = member.GetCustomAttributes<ValidationAttribute>(true);

            var val = accessor.PropertySelector.Compile().Invoke(target);

            var results = new List<ValidationResult>();

            foreach (var validator in validators)
            {
                context.MemberName = member.Name;

                context.DisplayName = member.GetCustomAttribute<DisplayNameAttribute>(true)?.DisplayName ?? context.MemberName;

                if (!Validator.TryValidateValue(val, context, results, new[] { validator }))
                {
                    accessor.AddError(ValitRuleError.CreateForMessage(validator.FormatErrorMessage(context.DisplayName)));
                }                  
            }

            return base.Validate(target);
        }

        private static void Validate(IValitRuleAccessor<TTarget, TProperty> accessor, TProperty val, ValidationAttribute validator, string name)
        {

            if (!validator.IsValid(val))
            {
                accessor.AddError(ValitRuleError.CreateForMessage(validator.FormatErrorMessage(name)));
            }
        }
    }
}
