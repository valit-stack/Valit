using System;
using System.Collections.Generic;
using System.Text;

namespace Valit.MessageProvider
{
    internal sealed class EmptyMessageProvider : IValitMessageProvider<string>
    {
        public string GetByKey(string key)
            => string.Empty;
    }
}
