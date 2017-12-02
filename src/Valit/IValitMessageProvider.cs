namespace Valit
{
    public interface IValitMessageProvider
    {
    }

    public interface IValitMessageProvider<TKey> : IValitMessageProvider
    {
        string GetByKey(TKey key);
    }
}
