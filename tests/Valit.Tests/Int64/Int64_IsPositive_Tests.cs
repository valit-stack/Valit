using Shouldly;
using Xunit;

namespace Valit.Tests.Int64
{
    public class Int64_IsPositive_Tests
    {
       [Fact]
        public void Int64_IsPositive_For_Not_Nullable_Value_Throws_When_Null_Rule_Is_Given()
        {
            var exception = Record.Exception(() => {
                ((IValitRule<Model, long>)null)
                    .IsPositive();
            });
            
            exception.ShouldBeOfType(typeof(ValitException));
        }

        [Fact]
        public void Int64_IsPositive_For_Nullable_Value_Throws_When_Null_Rule_Is_Given()
        {
            var exception = Record.Exception(() => {
                ((IValitRule<Model, long?>)null)
                    .IsPositive();
            });
            
            exception.ShouldBeOfType(typeof(ValitException));
        }


        [Fact]
        public void Int64_IsPositive_Succeeds_When_Given_Value_Is_Postive()
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
        public void Int64_IsPositive_Fails_When_Given_Value_Is_Zero()
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
        public void Int64_IsPositive_Fails_When_Given_Value_Is_Negative()
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
        public void Int64_IsPositive_Succeeds_When_Given_Value_Is_NullablePostive()
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
        public void Int64_IsPositive_Fails_When_Given_Value_Is_NullableZero()
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
        public void Int64_IsPositive_Fails_When_Given_Value_Is_NullableNegative()
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
        public void Int64_IsPositive_Fails_When_Given_Value_Is_Null()
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
        public Int64_IsPositive_Tests()
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