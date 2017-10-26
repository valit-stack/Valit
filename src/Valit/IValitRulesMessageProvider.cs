using Valit.MessageProvider;

namespace Valit
{
    public interface IValitRulesMessageProvider<TObject> : IValitRulesStrategyPicker<TObject>
        where TObject : class
    {
        IValitRulesStrategyPicker<TObject> WithMessageProvider<TKey>(IValitMessageProvider<TKey> messageProvider);
    }
}