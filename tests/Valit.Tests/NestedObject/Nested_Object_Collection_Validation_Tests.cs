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
                ValitRules<RootObject>
                    .Create()
                    .EnsureFor(m => m.NestedObjectCollection, ((IValitRulesProvider<NestedObject>)null));
            });
            
            exception.ShouldBeOfType(typeof(ValitException));
        }

        [Fact]
        public void Validation_With_Complete_Strategy_Fails_When_Invalid_Collection_Is_Given()
        {
            var rootObject = RootObject.GetInvalid();

            var result = ValitRules<RootObject>
                .Create()
                .Ensure(m => m.StringValue, _=>_
                    .Required())
                .EnsureFor(m => m.NestedObjectCollection, new NestedObjectRulesProvider())
                .For(rootObject)
                .Validate();

            Assert.False(result.Succeeded);
            result.ErrorMessages.Where(m => m == "One").Count().ShouldBe(1);
            result.ErrorMessages.Where(m => m == "Two").Count().ShouldBe(1);
            result.ErrorMessages.Where(m => m == "Three").Count().ShouldBe(2);
        }

        [Fact]
        public void Validation_With_FailFast_Strategy_Fails_When_Invalid_Collection_Is_Given()
        {
            var rootObject = RootObject.GetInvalid();
            
            var result = ValitRules<RootObject>
                .Create()
                .WithStrategy(picker => picker.FailFast)
                .Ensure(m => m.StringValue, _=>_
                    .Required())
                .EnsureFor(m => m.NestedObjectCollection, new NestedObjectRulesProvider())
                .For(rootObject)
                .Validate();

            Assert.False(result.Succeeded);
            result.ErrorMessages.Count().ShouldBe(1);
            result.ErrorMessages.First().ShouldBe("Two");
        }

        [Fact]
        public void Validation_With_Complete_Strategy_Succeeds_When_Valid_Collection_Is_Given()
        {
            var rootObject = RootObject.GetValid();
            
            var result = ValitRules<RootObject>
                .Create()
                .Ensure(m => m.StringValue, _=>_
                    .Required())
                .EnsureFor(m => m.NestedObjectCollection, new NestedObjectRulesProvider())
                .For(rootObject)
                .Validate();

            Assert.True(result.Succeeded);
        }

        [Fact]
        public void Validation_With_FailFast_Strategy_Succeeds_When_Valid_Collection_Is_Given()
        {
            var rootObject = RootObject.GetValid();
            
            var result = ValitRules<RootObject>
                .Create()
                .WithStrategy(picker => picker.FailFast)                
                .Ensure(m => m.StringValue, _=>_
                    .Required())
                .EnsureFor(m => m.NestedObjectCollection, new NestedObjectRulesProvider())
                .For(rootObject)
                .Validate();

            Assert.True(result.Succeeded);
        }

#region  ARRANGE
        class RootObject
        {
            public string StringValue { get; set; }
            public IEnumerable<NestedObject> NestedObjectCollection { get; set; }

            public static RootObject GetInvalid()
                => new RootObject
                {
                    StringValue = "Text",
                    NestedObjectCollection = new List<NestedObject>
                    {
                        new NestedObject { NumericValue = 20, StringValue = null },
                        new NestedObject { NumericValue = 1, StringValue = "invali.email@" },
                    }
                };

            public static RootObject GetValid()
                => new RootObject
                {
                    StringValue = "Text",
                    NestedObjectCollection = new List<NestedObject>
                    {
                        new NestedObject { NumericValue = 20, StringValue = "valid.email@test.com" },
                        new NestedObject { NumericValue = 30, StringValue = "another.valid.email@test.com" },
                    }
                };
        }   

        class NestedObject
        {
            public ushort NumericValue { get; set;}
            public string StringValue { get; set;}
        }

		class NestedObjectRulesProvider : IValitRulesProvider<NestedObject>
		{
			public IEnumerable<IValitRule<NestedObject>> GetRules()
                => ValitRules<NestedObject>
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