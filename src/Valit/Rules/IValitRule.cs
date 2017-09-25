using System;
using System.Collections.Generic;
using System.Text;

namespace Valit
{
    public interface IValitRule
    {
        ValitRulesStrategies Strategy { get; }
        IValitResult Validate();
    }
    public interface IValitRule<TProperty> : IValitRule
    {
    }
}
