namespace Valit
{
    public interface IValitRulesStrategyPicker<TObject>  where TObject : class
    {
         IValitRules<TObject> WithStrategy(ValitRulesStrategies strategy);
    }
}