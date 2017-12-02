using System.Collections.Generic;

namespace Valit.Validators
{
    internal sealed class Valitator<TObject> : IValitator<TObject> where TObject : class
    {
        private readonly IValitRulesStrategyPicker<TObject> _strategyPicker;

        internal Valitator(IValitRulesProvider<TObject> valitRulesProvider)
        {
            var rules = valitRulesProvider.GetRules();
            _strategyPicker = ValitRules<TObject>.Create(rules);
        }

        internal Valitator(IValitRules<TObject> valitRules)
        {
            var rules = valitRules.GetAllRules();
            _strategyPicker = ValitRules<TObject>.Create(rules);
        }

        IValitResult IValitator<TObject>.Validate(TObject @object, IValitStrategy strategy)
        {
            var selectedStrategy = strategy ?? new CompleteValitStrategy();

            return _strategyPicker
                .WithStrategy(selectedStrategy)
                .For(@object)
                .Validate();
        }
    }
}
