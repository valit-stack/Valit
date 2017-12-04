using Shouldly;
using Xunit;

namespace Valit.Tests.Decimal
{
    public class Decimal_IsNonZero_Tests
    {
        [Fact]
        public void Decimal_IsNonZero_For_Not_Nullable_Value_Throws_When_Null_Rule_Is_Given()
        {
            var exception = Record.Exception(() =>
            {
                ((IValitRule<Model, decimal>)null)
                    .IsNonZero();
            });

            exception.ShouldBeOfType(typeof(ValitException));
        }

        [Fact]
        public void Decimal_IsNonZero_For_Nullable_Value_Throws_When_Null_Rule_Is_Given()
        {
            var exception = Record.Exception(() =>
            {
                ((IValitRule<Model, decimal?>)null)
                    .IsNonZero();
            });

            exception.ShouldBeOfType(typeof(ValitException));
        }


        [Theory]
        [InlineData(false, true)]
        [InlineData(true, false)]
        public void Decimal_IsNonZero_Returns_Proper_Results_For_Not_Nullable_Value(bool useZeroValue, bool expected)
        {
            IValitResult result = ValitRules<Model>
                .Create()
                .Ensure(m => useZeroValue ? m.ZeroValue : m.Value, _ => _
                    .IsNonZero())
                .For(_model)
                .Validate();

            result.Succeeded.ShouldBe(expected);
        }

        [Theory]
        [InlineData(false, true)]
        [InlineData(true, false)]
        public void Decimal_IsNonZero_Returns_Proper_Results_For_Nullable_Value(bool useZeroValue, bool expected)
        {
            IValitResult result = ValitRules<Model>
                .Create()
                .Ensure(m => useZeroValue ? m.NullableZeroValue : m.NullableValue, _ => _
                    .IsNonZero())
                .For(_model)
                .Validate();

            result.Succeeded.ShouldBe(expected);
        }

        [Fact]
        public void Decimal_IsNonZero_Fails_For_Null_Value()
        {
            IValitResult result = ValitRules<Model>
                .Create()
                .Ensure(m => m.NullValue, _ => _
                    .IsNonZero())
                .For(_model)
                .Validate();

            result.Succeeded.ShouldBeFalse();
        }

        #region ARRANGE
        public Decimal_IsNonZero_Tests()
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
