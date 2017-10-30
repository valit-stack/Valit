namespace Valit.MessageProvider
{
    internal sealed class EmptyMessageProvider : IValitMessageProvider<string>
    {
        public string GetByKey(string key)
            => string.Empty;
    }
}
