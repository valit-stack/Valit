using System.Collections.Generic;

namespace Valit.Validators
{
    internal sealed class Valitator<TObject> : IValitator<TObject> where TObject : class
    {
        private readonly IValitRulesStrategyPicker<TObject> _strategyPicker;

        internal Valitator(IValitRules<TObject> valitRules)
        {
            _strategyPicker = ValitRules<TObject>.Create(valitRules);
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
