using System.Collections.Generic;
using Shouldly;
using Xunit;

namespace Valit.Tests.Valitator
{
    public class Valitator_ValitRules_Tests
    {
        [Fact]
        public void CreateValitator_Throws_When_Null_ValitRulesProvider_Is_Given()
        {
            var exception = Record.Exception(() => {
                var valitator = ((IValitRules<Model>)null).CreateValitator();
            });

            exception.ShouldBeOfType(typeof(ValitException));
        }

        [Fact]
        public void Created_Valitator_Properly_Handles_Complete_Strategy()
        {
            var valitator = _valitRules.CreateValitator();
            var result = valitator.Validate(_model);

            result.Succeeded.ShouldBeFalse();
            result.ErrorMessages.ShouldContain("One");
            result.ErrorMessages.ShouldNotContain("Two");
            result.ErrorMessages.ShouldContain("Three");
        }

        [Fact]
        public void Created_Valitator_Properly_Handles_FailFast_Strategy()
        {
            var valitator = _valitRules.CreateValitator();
            var result = valitator.Validate(_model, new FailFastValitStrategy());

            result.Succeeded.ShouldBeFalse();
            result.ErrorMessages.ShouldContain("One");
            result.ErrorMessages.ShouldNotContain("Two");
            result.ErrorMessages.ShouldNotContain("Three");
        }


#region  ARRANGE

        class Model
        {
            public ushort NumericValue { get; set; }
            public string StringValue { get; set; }
        }

        private readonly Model _model;
        private readonly IValitRules<Model> _valitRules;

        public Valitator_ValitRules_Tests()
        {
            _model = new Model
            {
                NumericValue = 3,
                StringValue = "Text"
            };

            _valitRules = ValitRules<Model>
                .Create()
                .Ensure(m => m.NumericValue, _=>_
                    .IsGreaterThan(10)
                        .WithMessage("One"))
                .Ensure(m => m.StringValue, _=>_
                    .Required()
                        .WithMessage("Two")
                    .Email()
                        .WithMessage("Three"));
        }
    }
#endregion

}
