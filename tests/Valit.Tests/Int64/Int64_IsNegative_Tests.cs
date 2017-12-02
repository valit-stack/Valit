using Shouldly;
using Xunit;

namespace Valit.Tests.Int64
{
    public class Int64_IsNegative_Tests
    {
        [Fact]
        public void Int64_IsNegative_For_Not_Nullable_Value_Throws_When_Null_Rule_Is_Given()
        {
            var exception = Record.Exception(() => {
                ((IValitRule<Model, long>)null)
                    .IsNegative();
            });

            exception.ShouldBeOfType(typeof(ValitException));
        }

        [Fact]
        public void Int64_IsNegative_For_Nullable_Value_Throws_When_Null_Rule_Is_Given()
        {
            var exception = Record.Exception(() => {
                ((IValitRule<Model, long?>)null)
                    .IsNegative();
            });

            exception.ShouldBeOfType(typeof(ValitException));
        }


        [Fact]
        public void Int64_IsNegative_Succeeds_When_Given_Value_Is_Negative()
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
        public void Int64_IsNegative_Fails_When_Given_Value_Is_Zero()
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
        public void Int64_IsNegative_Fails_When_Given_Value_Is_Positive()
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
        public void Int64_IsNegative_Succeeds_When_Given_Value_Is_NullableNegative()
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
        public void Int64_IsNegative_Fails_When_Given_Value_Is_NullableZero()
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
        public void Int64_IsNegative_Fails_When_Given_Value_Is_NullablePositive()
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
        public void Int64_IsNegative_Fails_When_Given_Value_Is_Null()
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
        public Int64_IsNegative_Tests()
        {
            _model = new Model();
        }

        private readonly Model _model;

        class Model
        {
            public long PositiveValue => 10;
            public long ZeroValue => 0;
            public long NegativeValue => -10;
            public long? NullablePositiveValue => 10;
            public long? NullableZeroValue => 0;
            public long? NullableNegativeValue => -10;
            public long? NullValue => null;
        }
#endregion
    }
}
