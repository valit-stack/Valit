using System;
using System.Collections.Generic;
using System.Text;

namespace Valit.MessageProvider
{
    public interface IValitMessageProvider
    {
    }

    public interface IValitMessageProvider<TKey> : IValitMessageProvider
    {
        string GetByKey(TKey key);
    }
}
