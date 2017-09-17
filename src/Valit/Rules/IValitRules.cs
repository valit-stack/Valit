using System;

namespace Valit
{
    public interface IValitRules<TObject> where TObject : class
    {
         IValitRules<TObject> Ensure<TProperty>(Func<TObject, TProperty> selector, Action<IValitRule<TProperty>> rule);
         IValitResult Validate();
    }
}