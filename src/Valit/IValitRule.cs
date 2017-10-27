using System.Collections.Generic;
using Valit.MessageProvider;

namespace Valit
{
    public interface IValitRule
    {
        IValitStrategy Strategy { get; }
        IEnumerable<string> Tags { get; }
        IValitMessageProvider GetMessageProvider();
        IValitMessageProvider<TKey> GetMessageProvider<TKey>();
    }

    public interface IValitRule<TObject> : IValitRule where TObject : class
    {
        IValitResult Validate(TObject @object);
    }
    public interface IValitRule<TObject, TProperty> : IValitRule<TObject> where TObject : class
    {
    }
}
