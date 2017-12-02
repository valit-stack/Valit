using Shouldly;
using Xunit;

namespace Valit.Tests.Int16
{
    public class Int16_IsPositive_Tests
    {
        [Fact]
        public void Int16_IsPositive_For_Not_Nullable_Value_Throws_When_Null_Rule_Is_Given()
        {
            var exception = Record.Exception(() => {
                ((IValitRule<Model, short>)null)
                    .IsPositive();
            });

            exception.ShouldBeOfType(typeof(ValitException));
        }

        [Fact]
        public void Int16_IsPositive_For_Nullable_Value_Throws_When_Null_Rule_Is_Given()
        {
            var exception = Record.Exception(() => {
                ((IValitRule<Model, short?>)null)
                    .IsPositive();
            });

            exception.ShouldBeOfType(typeof(ValitException));
        }


        [Fact]
        public void Int16_IsPositive_Succeeds_When_Given_Value_Is_Postive()
        {
            IValitResult result = ValitRules<Model>
                .Create()
                .Ensure(m => m.PositiveValue, _=>_
                    .IsPositive())
                .For(_model)
                .Validate();

            Assert.Equal(result.Succeeded, true);
        }

        [Fact]
        public void Int16_IsPositive_Fails_When_Given_Value_Is_Zero()
        {
            IValitResult result = ValitRules<Model>
                .Create()
                .Ensure(m => m.ZeroValue, _=>_
                    .IsPositive())
                .For(_model)
                .Validate();

            Assert.Equal(result.Succeeded, false);
        }

        [Fact]
        public void Int16_IsPositive_Fails_When_Given_Value_Is_Negative()
        {
            IValitResult result = ValitRules<Model>
                .Create()
                .Ensure(m => m.NegativeValue, _=>_
                    .IsPositive())
                .For(_model)
                .Validate();

            Assert.Equal(result.Succeeded, false);
        }

        [Fact]
        public void Int16_IsPositive_Succeeds_When_Given_Value_Is_NullablePostive()
        {
            IValitResult result = ValitRules<Model>
                .Create()
                .Ensure(m => m.NullablePositiveValue, _=>_
                    .IsPositive())
                .For(_model)
                .Validate();

            Assert.Equal(result.Succeeded, true);
        }

        [Fact]
        public void Int16_IsPositive_Fails_When_Given_Value_Is_NullableZero()
        {
            IValitResult result = ValitRules<Model>
                .Create()
                .Ensure(m => m.NullableZeroValue, _=>_
                    .IsPositive())
                .For(_model)
                .Validate();

            Assert.Equal(result.Succeeded, false);
        }

        [Fact]
        public void Int16_IsPositive_Fails_When_Given_Value_Is_NullableNegative()
        {
            IValitResult result = ValitRules<Model>
                .Create()
                .Ensure(m => m.NullableNegativeValue, _=>_
                    .IsPositive())
                .For(_model)
                .Validate();

            Assert.Equal(result.Succeeded, false);
        }

        [Fact]
        public void Int16_IsPositive_Fails_When_Given_Value_Is_Null()
        {
            IValitResult result = ValitRules<Model>
                .Create()
                .Ensure(m => m.NullValue, _=>_
                    .IsPositive())
                .For(_model)
                .Validate();

            Assert.Equal(result.Succeeded, false);
        }

#region ARRANGE
        public Int16_IsPositive_Tests()
        {
            _model = new Model();
        }

        private readonly Model _model;

        class Model
        {
            public short PositiveValue => 10;
            public short ZeroValue => 0;
            public short NegativeValue => -10;
            public short? NullablePositiveValue => 10;
            public short? NullableZeroValue => 0;
            public short? NullableNegativeValue => -10;
            public short? NullValue => null;
        }
#endregion
    }
}
