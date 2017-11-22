using System.Collections.Generic;

namespace Valit.Validators
{
	internal sealed class Valitator<TObject> : IValitator<TObject> where TObject : class
	{
        private readonly IValitRulesStrategyPicker<TObject> _strategyPicker;

        internal Valitator(IValitRulesProvider<TObject> valitRulesProvider)
        {
            _strategyPicker = CreateStrategyPicker(valitRulesProvider);
        }

		IValitResult IValitator<TObject>.Validate(TObject @object, IValitStrategy strategy)
		{
			var selectedStrategy = strategy ?? new CompleteValitStrategy();

            return _strategyPicker
                .WithStrategy(selectedStrategy)
                .For(@object)
                .Validate();
		}

        private IValitRulesStrategyPicker<TObject> CreateStrategyPicker(IValitRulesProvider<TObject> valitRulesProvider)
        {
            var rules = valitRulesProvider.GetRules();
            return ValitRules<TObject>.Create(rules);
        }
	}
}