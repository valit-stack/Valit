using System.Collections.Generic;

namespace Valit
{
    public interface IValitRulesProvider<TObject> where TObject : class
    {
         IEnumerable<IValitRule<TObject>> GetValitRules();
    }
}