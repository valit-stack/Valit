using Valit.Enums;

namespace Valit.Rules
{
    public interface IValitRulesStrategyPicker<TObject>  where TObject : class
    {
         IValitRules<TObject> WithStrategy(ValitRulesStrategies strategy);
    }
}