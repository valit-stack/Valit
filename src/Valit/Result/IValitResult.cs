using System;
using System.Collections.Generic;
using System.Text;

namespace Valit
{
    public interface IValitResult
    {
        bool Succeeded { get; }
        string[] Errors { get; }
    }
}
