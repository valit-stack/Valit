using Shouldly;
using Xunit;

namespace Valit.Tests.Int32
{
    public class Int32_Required_Tests
    {

        [Fact]
        public void Int32_Required_For_Nullable_Value_Throws_When_Null_Rule_Is_Given()
        {
            var exception = Record.Exception(() => {
                ((IValitRule<Model, int?>)null)
                    .Required();
            });

            exception.ShouldBeOfType(typeof(ValitException));
        }


        [Theory]
        [InlineData(false, true)]
        [InlineData(true, false)]
        public void Int32_Required_Returns_Proper_Results_For_Nullable_Value(bool useNullValue,  bool expected)
        {
            IValitResult result = ValitRules<Model>
                .Create()
                .Ensure(m => useNullValue? m.NullValue : m.NullableValue, _=>_
                    .Required())
                .For(_model)
                .Validate();

            Assert.Equal(result.Succeeded, expected);
        }

#region ARRANGE
        public Int32_Required_Tests()
        {
            _model = new Model();
        }

        private readonly Model _model;

        class Model
        {
            public int Value => 10;
            public int ZeroValue => 0;
            public int? NullableValue => 10;
            public int? NullableZeroValue => 0;
            public int? NullValue => null;
        }
#endregion
    }
}
