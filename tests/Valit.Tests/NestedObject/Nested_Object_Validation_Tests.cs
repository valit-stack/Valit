using System.Collections.Generic;
using Shouldly;
using Xunit;

namespace Valit.Tests.NestedObject
{
    public class Nested_Object_Validation_Tests
    {

        [Fact]
        public void Ensure_Throws_When_Null_ValitRulesProvider_Is_Given()
        {
            var exception = Record.Exception(() =>
            {
                ValitRules<Model>
                    .Create()
                    .Ensure(m => m.NestedObject, ((IValitator<NestedModel>)null));
            });

            exception.ShouldBeOfType(typeof(ValitException));
        }

        [Fact]
        public void Validation_Fails_When_Invalid_NestedObject_Is_Given()
        {
            var rootObject = Model.GetInvalid();

            var result = ValitRules<Model>
                .Create()
                .Ensure(m => m.NestedObject, _modelValitator)
                .For(rootObject)
                .Validate();

            result.Succeeded.ShouldBeFalse();
        }

        [Fact]
        public void Validation_Returns_Proper_Messages_When_Invalid_NestedObject_Is_Given()
        {
            var rootObject = Model.GetInvalid();

            var result = ValitRules<Model>
                .Create()
                .Ensure(m => m.NestedObject, _modelValitator)
                .For(rootObject)
                .Validate();

            result.ErrorMessages.ShouldNotContain("One");
            result.ErrorMessages.ShouldContain("Two");
            result.ErrorMessages.ShouldContain("Three");
        }

        [Fact]
        public void Validation_Succeeds_When_Valid_NestedObject_Is_Given()
        {
            var rootObject = Model.GetValid();

            var result = ValitRules<Model>
                .Create()
                .Ensure(m => m.NestedObject, _modelValitator)
                .For(rootObject)
                .Validate();

            result.Succeeded.ShouldBeTrue();
        }

        #region  ARRANGE

        public Nested_Object_Validation_Tests()
        {
            _modelValitator = new NestedModelRulesProvider().CreateValitator();
        }

        private readonly IValitator<NestedModel> _modelValitator;

        class Model
        {
            public NestedModel NestedObject { get; set; }

            public static Model GetInvalid()
                => new Model
                {
                    NestedObject = new NestedModel
                    {
                        NumericValue = 20,
                        StringValue = null
                    }
                };

            public static Model GetValid()
                => new Model
                {
                    NestedObject = new NestedModel
                    {
                        NumericValue = 20,
                        StringValue = "someemail@test.com"
                    }
                };
        }

        class NestedModel
        {
            public ushort NumericValue { get; set; }
            public string StringValue { get; set; }
        }

        class NestedModelRulesProvider : IValitRulesProvider<NestedModel>
        {
            public IEnumerable<IValitRule<NestedModel>> GetRules()
                => ValitRules<NestedModel>
                        .Create()
                        .Ensure(m => m.NumericValue, _ => _
                            .IsGreaterThan(10)
                                .WithMessage("One"))
                        .Ensure(m => m.StringValue, _ => _
                            .Required()
                                .WithMessage("Two")
                            .Email()
                                .WithMessage("Three"))
                        .GetAllRules();
        }
    }
    #endregion
}
