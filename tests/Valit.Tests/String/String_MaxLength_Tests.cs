using Xunit;
using Shouldly;

namespace Valit.Tests.String
{
    public class String_MaxLength_Tests
    {
        [Fact]
        public void String_MaxLength_For_Nullable_Values_Throws_When_Null_Rule_Is_Given()
        {
            var exception = Record.Exception(() => {
                ((IValitRule<Model, string>)null)
                    .MaxLength(0);
            });

            exception.ShouldBeOfType(typeof(ValitException));
        }

        [Theory]
        [InlineData(0, false)]
        [InlineData(4, true)]
        [InlineData(8, true)]
        public void String_MaxLength_Returns_Proper_Result_For_Left_Value(int value, bool expected)
        {
            IValitResult result = ValitRules<Model>
                .Create()
                .Ensure(m => m.Value, _ => _
                    .MaxLength(value))
                .For(_model)
                .Validate();

            result.Succeeded.ShouldBe(expected);
        }

        [Theory]
        [InlineData(0, false)]
        [InlineData(4, false)]
        [InlineData(8, false)]
        public void String_MaxLength_Returns_Proper_Result_For_Left_Empty_Value(int value, bool expected)
        {
            IValitResult result = ValitRules<Model>
                .Create()
                .Ensure(m => m.EmptyValue, _ => _
                    .MaxLength(value))
                .For(_model)
                .Validate();

            result.Succeeded.ShouldBe(expected);
        }

        [Theory]
        [InlineData(0, false)]
        [InlineData(4, false)]
        [InlineData(8, false)]
        public void String_MaxLength_Returns_Proper_Result_For_Left_Null_Value(int value, bool expected)
        {
            IValitResult result = ValitRules<Model>
                .Create()
                .Ensure(m => m.NullValue, _ => _
                    .MaxLength(value))
                .For(_model)
                .Validate();

            result.Succeeded.ShouldBe(expected);
        }

#region ARRANGE
        public String_MaxLength_Tests()
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
