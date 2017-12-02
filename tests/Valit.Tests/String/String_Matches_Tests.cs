using Xunit;
using Shouldly;

namespace Valit.Tests.String
{
    public class String_Matches_Tests
    {
        [Fact]
        public void String_Matches_For_Nullable_Values_Throws_When_Null_Rule_Is_Given()
        {
            var exception = Record.Exception(() => {
                ((IValitRule<Model, string>)null)
                    .Matches(@"\d+");
            });

            exception.ShouldBeOfType(typeof(ValitException));
        }

        [Theory]
        [InlineData(@"\w", true)]
        [InlineData(@"\d", false)]
        [InlineData("", false)]
        [InlineData(null, false)]
        public void String_Matches_Returns_Proper_Result_For_Left_Value(string value, bool expected)
        {
            IValitResult result = ValitRules<Model>
                .Create()
                .Ensure(m => m.Value, _ => _
                    .Matches(value))
                .For(_model)
                .Validate();

            result.Succeeded.ShouldBe(expected);
        }

        [Theory]
        [InlineData(@"\w", false)]
        [InlineData(@"\d", false)]
        [InlineData("", false)]
        [InlineData(null, false)]
        public void String_Matches_Returns_Proper_Result_For_Left_Empty_Value(string value, bool expected)
        {
            IValitResult result = ValitRules<Model>
                .Create()
                .Ensure(m => m.EmptyValue, _ => _
                    .Matches(value))
                .For(_model)
                .Validate();

            result.Succeeded.ShouldBe(expected);
        }

        [Theory]
        [InlineData(@"\w", false)]
        [InlineData(@"\d", false)]
        [InlineData("", false)]
        [InlineData(null, false)]
        public void String_Matches_Returns_Proper_Result_For_Left_Null_Value(string value, bool expected)
        {
            IValitResult result = ValitRules<Model>
                .Create()
                .Ensure(m => m.NullValue, _ => _
                    .Matches(value))
                .For(_model)
                .Validate();

            result.Succeeded.ShouldBe(expected);
        }

#region ARRANGE
        public String_Matches_Tests()
        {
            _model = new Model();
        }

        private readonly Model _model;

        class Model
        {
            public string EmptyValue => string.Empty;
            public string Value => "text";
            public string NullValue => null;
        }
#endregion
    }
}
