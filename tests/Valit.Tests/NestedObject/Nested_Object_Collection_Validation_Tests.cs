using System.Collections.Generic;
using System.Linq;
using Shouldly;
using Xunit;

namespace Valit.Tests.NestedObject
{
    public class Nested_Object_Collection_Validation_Tests
    {
        [Fact]
        public void EnsureFor_Throws_When_Null_ValitRulesProvider_Is_Given()
        {
            var exception = Record.Exception(() => {
                ValitRules<Model>
                    .Create()
                    .EnsureFor(m => m.NestedObjectCollection, ((IValitRulesProvider<NestedModel>)null));
            });

            exception.ShouldBeOfType(typeof(ValitException));
        }

        [Fact]
        public void Validation_With_Complete_Strategy_Fails_When_Invalid_Collection_Is_Given()
        {
            var rootObject = Model.GetInvalid();

            var result = ValitRules<Model>
                .Create()
                .EnsureFor(m => m.NestedObjectCollection, new NestedModelRulesProvider())
                .For(rootObject)
                .Validate();

            Assert.False(result.Succeeded);
            result.ErrorMessages.Count(m => m == "One").ShouldBe(1);
            result.ErrorMessages.Count(m => m == "Two").ShouldBe(1);
            result.ErrorMessages.Count(m => m == "Three").ShouldBe(2);
        }

        [Fact]
        public void Validation_With_FailFast_Strategy_Fails_When_Invalid_Collection_Is_Given()
        {
            var rootObject = Model.GetInvalid();

            var result = ValitRules<Model>
                .Create()
                .WithStrategy(picker => picker.FailFast)
                .EnsureFor(m => m.NestedObjectCollection, new NestedModelRulesProvider())
                .For(rootObject)
                .Validate();

            Assert.False(result.Succeeded);
            result.ErrorMessages.Count().ShouldBe(1);
            result.ErrorMessages.First().ShouldBe("Two");
        }

        [Fact]
        public void Validation_With_Complete_Strategy_Succeeds_When_Valid_Collection_Is_Given()
        {
            var rootObject = Model.GetValid();

            var result = ValitRules<Model>
                .Create()
                .EnsureFor(m => m.NestedObjectCollection, new NestedModelRulesProvider())
                .For(rootObject)
                .Validate();

            Assert.True(result.Succeeded);
        }

        [Fact]
        public void Validation_With_FailFast_Strategy_Succeeds_When_Valid_Collection_Is_Given()
        {
            var rootObject = Model.GetValid();

            var result = ValitRules<Model>
                .Create()
                .WithStrategy(picker => picker.FailFast)
                .EnsureFor(m => m.NestedObjectCollection, new NestedModelRulesProvider())
                .For(rootObject)
                .Validate();

            Assert.True(result.Succeeded);
        }

#region  ARRANGE
        class Model
        {
            public IEnumerable<NestedModel> NestedObjectCollection { get; set; }

            public static Model GetInvalid()
                => new Model
                {
                    NestedObjectCollection = new List<NestedModel>
                    {
                        new NestedModel { NumericValue = 20, StringValue = null },
                        new NestedModel { NumericValue = 1, StringValue = "invali.email@" },
                    }
                };

            public static Model GetValid()
                => new Model
                {
                    NestedObjectCollection = new List<NestedModel>
                    {
                        new NestedModel { NumericValue = 20, StringValue = "valid.email@test.com" },
                        new NestedModel { NumericValue = 30, StringValue = "another.valid.email@test.com" },
                    }
                };
        }

        class NestedModel
        {
            public ushort NumericValue { get; set;}
            public string StringValue { get; set;}
        }

        class NestedModelRulesProvider : IValitRulesProvider<NestedModel>
        {
            public IEnumerable<IValitRule<NestedModel>> GetRules()
                => ValitRules<NestedModel>
                        .Create()
                        .Ensure(m => m.NumericValue, _=>_
                            .IsGreaterThan(10)
                                .WithMessage("One"))
                        .Ensure(m => m.StringValue, _=>_
                            .Required()
                                .WithMessage("Two")
                            .Email()
                                .WithMessage("Three"))
                        .GetAllRules();
        }
    }
#endregion
}
