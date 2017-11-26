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
            var exception = Record.Exception(() => {
                ValitRules<RootObject>
                    .Create()
                    .Ensure(m => m.NestedObject, ((IValitRulesProvider<NestedObject>)null));
            });
            
            exception.ShouldBeOfType(typeof(ValitException));
        }

        [Fact]
        public void Validation_Fails_When_Invalid_NestedObject_Is_Given()
        {
            var rootObject = RootObject.GetInvalid();

            var result = ValitRules<RootObject>
                .Create()
                .Ensure(m => m.StringValue, _=>_
                    .Required())
                .Ensure(m => m.NestedObject, new NestedObjectRulesProvider())
                .For(rootObject)
                .Validate();

            Assert.False(result.Succeeded);
        }

        [Fact]
        public void Validation_Returns_Proper_Messages_When_Invalid_NestedObject_Is_Given()
        {
            var rootObject = RootObject.GetInvalid();
            
            var result = ValitRules<RootObject>
                .Create()
                .Ensure(m => m.StringValue, _=>_
                    .Required())
                .Ensure(m => m.NestedObject, new NestedObjectRulesProvider())
                .For(rootObject)
                .Validate();

            result.ErrorMessages.ShouldNotContain("One");
            result.ErrorMessages.ShouldContain("Two");
            result.ErrorMessages.ShouldContain("Three");
        }

        [Fact]
        public void Validation_Succeeds_When_Valid_NestedObject_Is_Given()
        {
            var rootObject = RootObject.GetValid();
            
            var result = ValitRules<RootObject>
                .Create()
                .Ensure(m => m.StringValue, _=>_
                    .Required())
                .Ensure(m => m.NestedObject, new NestedObjectRulesProvider())
                .For(rootObject)
                .Validate();

            Assert.True(result.Succeeded);
        }

#region  ARRANGE
        class RootObject
        {
            public string StringValue { get; set; }
            public NestedObject NestedObject { get; set; }

            public static RootObject GetInvalid()
                => new RootObject
                {
                    StringValue = "Text",
                    NestedObject = new NestedObject
                    {
                        NumericValue = 20,
                        StringValue = null
                    }
                };

            public static RootObject GetValid()
                => new RootObject
                {
                    StringValue = "Text",
                    NestedObject = new NestedObject
                    {
                        NumericValue = 20,
                        StringValue = "someemail@test.com"
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