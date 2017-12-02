using Shouldly;
using Xunit;

namespace Valit.Tests.Decimal
{
    public class Decimal_Required_Tests
    {

        [Fact]
        public void Decimal_Required_For_Nullable_Value_Throws_When_Null_Rule_Is_Given()
        {
            var exception = Record.Exception(() => {
                ((IValitRule<Model, decimal?>)null)
                    .Required();
            });

            exception.ShouldBeOfType(typeof(ValitException));
        }


        [Theory]
        [InlineData(false, true)]
        [InlineData(true, false)]
        public void Decimal_Required_Returns_Proper_Results_For_Nullable_Value(bool useNullValue,  bool expected)
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
        public Decimal_Required_Tests()
        {
            _model = new Model();
        }

        private readonly Model _model;

        class Model
        {
            public decimal Value => 10;
            public decimal ZeroValue => 0;
            public decimal? NullableValue => 10;
            public decimal? NullableZeroValue => 0;
            public decimal? NullValue => null;
        }
#endregion
    }
}
