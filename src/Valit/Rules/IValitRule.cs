using System;
using System.Collections.Generic;
using System.Text;

namespace Valit
{
    public interface IValitRule
    {
        ValitRulesStrategies Strategy { get; }
    }

    public interface IValitRule<TObject> : IValitRule where TObject : class
    {
        IValitResult Validate(TObject @object);
    }
    public interface IValitRule<TObject, TProperty> : IValitRule<TObject> where TObject : class
    {
    }
}
