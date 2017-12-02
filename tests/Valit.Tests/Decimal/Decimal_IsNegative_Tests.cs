using Shouldly;
using Xunit;

namespace Valit.Tests.Decimal
{
    public class Decimal_IsNegative_Tests
    {
        [Fact]
        public void Decimal_IsNegative_For_Not_Nullable_Value_Throws_When_Null_Rule_Is_Given()
        {
            var exception = Record.Exception(() => {
                ((IValitRule<Model, decimal>)null)
                    .IsNegative();
            });

            exception.ShouldBeOfType(typeof(ValitException));
        }

        [Fact]
        public void Decimal_IsNegative_For_Nullable_Value_Throws_When_Null_Rule_Is_Given()
        {
            var exception = Record.Exception(() => {
                ((IValitRule<Model, decimal?>)null)
                    .IsNegative();
            });

            exception.ShouldBeOfType(typeof(ValitException));
        }


        [Fact]
        public void Decimal_IsNegative_Succeeds_When_Given_Value_Is_Negative()
        {
            IValitResult result = ValitRules<Model>
                .Create()
                .Ensure(m => m.NegativeValue, _=>_
                    .IsNegative())
                .For(_model)
                .Validate();

            Assert.Equal(result.Succeeded, true);
        }

        [Fact]
        public void Decimal_IsNegative_Fails_When_Given_Value_Is_Zero()
        {
            IValitResult result = ValitRules<Model>
                .Create()
                .Ensure(m => m.ZeroValue, _=>_
                    .IsNegative())
                .For(_model)
                .Validate();

            Assert.Equal(result.Succeeded, false);
        }

        [Fact]
        public void Decimal_IsNegative_Fails_When_Given_Value_Is_Positive()
        {
            IValitResult result = ValitRules<Model>
                .Create()
                .Ensure(m => m.PositiveValue, _=>_
                    .IsNegative())
                .For(_model)
                .Validate();

            Assert.Equal(result.Succeeded, false);
        }

        [Fact]
        public void Decimal_IsNegative_Succeeds_When_Given_Value_Is_NullableNegative()
        {
            IValitResult result = ValitRules<Model>
                .Create()
                .Ensure(m => m.NullableNegativeValue, _=>_
                    .IsNegative())
                .For(_model)
                .Validate();

            Assert.Equal(result.Succeeded, true);
        }

        [Fact]
        public void Decimal_IsNegative_Fails_When_Given_Value_Is_NullableZero()
        {
            IValitResult result = ValitRules<Model>
                .Create()
                .Ensure(m => m.NullableZeroValue, _=>_
                    .IsNegative())
                .For(_model)
                .Validate();

            Assert.Equal(result.Succeeded, false);
        }

        [Fact]
        public void Decimal_IsNegative_Fails_When_Given_Value_Is_NullablePositive()
        {
            IValitResult result = ValitRules<Model>
                .Create()
                .Ensure(m => m.NullablePositiveValue, _=>_
                    .IsNegative())
                .For(_model)
                .Validate();

            Assert.Equal(result.Succeeded, false);
        }

        [Fact]
        public void Decimal_IsNegative_Fails_When_Given_Value_Is_Null()
        {
            IValitResult result = ValitRules<Model>
                .Create()
                .Ensure(m => m.NullValue, _=>_
                    .IsNegative())
                .For(_model)
                .Validate();

            Assert.Equal(result.Succeeded, false);
        }

#region ARRANGE
        public Decimal_IsNegative_Tests()
        {
            _model = new Model();
        }

        private readonly Model _model;

        class Model
        {
            public decimal PositiveValue => 10;
            public decimal ZeroValue => 0;
            public decimal NegativeValue => -10;
            public decimal? NullablePositiveValue => 10;
            public decimal? NullableZeroValue => 0;
            public decimal? NullableNegativeValue => -10;
            public decimal? NullValue => null;
        }
#endregion
    }
}
