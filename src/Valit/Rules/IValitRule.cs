using System;
using System.Collections.Generic;
using System.Text;

namespace Valit.Rules
{
    public interface IValitRule
    {
    }

    public interface IValitRule<TProperty> : IValitRule
    {
    }
}
