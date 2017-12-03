using System.Collections.Generic;

namespace Valit
{
    public interface IValitRule
    {
        IEnumerable<string> Tags { get; }
    }

    public interface IValitRule<TObject> : IValitRule where TObject : class
    {
        IValitResult Validate(TObject @object);

        IEnumerable<IValitRule<TObject>> GetEnsureRules(TObject @object);
    }
    public interface IValitRule<TObject, TProperty> : IValitRule<TObject> where TObject : class
    {
    }
}
