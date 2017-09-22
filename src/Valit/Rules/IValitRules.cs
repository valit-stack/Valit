using System;

namespace Valit
{
    public interface IValitRules<TObject> where TObject : class
    {
         IValitRules<TObject> Ensure<TProperty>(Func<TObject, TProperty> selector, Func<IValitRule<TProperty>,IValitRule<TProperty>> rule);
         ValitResult Validate();
    }
}