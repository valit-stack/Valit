using System;
using System.Collections.Generic;
using System.Text;
using Valit.Strategies;

namespace Valit
{
    public interface IValitRule
    {
        IValitStrategy Strategy { get; }
        IEnumerable<string> Tags { get; }
    }

    public interface IValitRule<TObject> : IValitRule where TObject : class
    {
        IValitResult Validate(TObject @object);
    }
    public interface IValitRule<TObject, TProperty> : IValitRule<TObject> where TObject : class
    {
    }
}
