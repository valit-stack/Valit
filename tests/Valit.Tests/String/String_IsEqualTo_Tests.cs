using Xunit;
using Shouldly;

namespace Valit.Tests.String
{
    public class String_IsEqualTo_Tests
    {
        [Fact]
        public void String_IsEqualTo_For_Nullable_Values_Throws_When_Null_Rule_Is_Given()
        {
            var exception = Record.Exception(() => {
                ((IValitRule<Model, string>)null)
                    .IsEqualTo("text");
            });

            exception.ShouldBeOfType(typeof(ValitException));
        }

        [Theory]
        [InlineData("text", true)]
        [InlineData("other", false)]
        [InlineData("", false)]
        [InlineData(null, false)]
        public void String_IsEqualTo_Returns_Proper_Result_For_Left_Value(string value, bool expected)
        {
            IValitResult result = ValitRules<Model>
                .Create()
                .Ensure(m => m.Value, _ => _
                    .IsEqualTo(value))
                .For(_model)
                .Validate();

            result.Succeeded.ShouldBe(expected);
        }

        [Theory]
        [InlineData("text", false)]
        [InlineData("other", false)]
        [InlineData("", true)]
        [InlineData(null, false)]
        public void String_IsEqualTo_Returns_Proper_Result_For_Left_Empty_Value(string value, bool expected)
        {
            IValitResult result = ValitRules<Model>
                .Create()
                .Ensure(m => m.EmptyValue, _ => _
                    .IsEqualTo(value))
                .For(_model)
                .Validate();

            result.Succeeded.ShouldBe(expected);
        }

        [Theory]
        [InlineData("text", false)]
        [InlineData("other", false)]
        [InlineData("", false)]
        [InlineData(null, false)]
        public void String_IsEqualTo_Returns_Proper_Result_For_Left_Null_Value(string value, bool expected)
        {
            IValitResult result = ValitRules<Model>
                .Create()
                .Ensure(m => m.NullValue, _ => _
                    .IsEqualTo(value))
                .For(_model)
                .Validate();

            result.Succeeded.ShouldBe(expected);
        }

#region ARRANGE
        public String_IsEqualTo_Tests()
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
