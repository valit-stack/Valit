using Shouldly;
using Xunit;

namespace Valit.Tests.Int64
{
    public class Int64_IsNonZero_Tests
    {
        [Fact]
        public void Int64_IsNonZero_For_Not_Nullable_Value_Throws_When_Null_Rule_Is_Given()
        {
            var exception = Record.Exception(() =>
            {
                ((IValitRule<Model, long>)null)
                    .IsNonZero();
            });

            exception.ShouldBeOfType(typeof(ValitException));
        }

        [Fact]
        public void Int64_IsNonZero_For_Nullable_Value_Throws_When_Null_Rule_Is_Given()
        {
            var exception = Record.Exception(() =>
            {
                ((IValitRule<Model, long?>)null)
                    .IsNonZero();
            });

            exception.ShouldBeOfType(typeof(ValitException));
        }


        [Theory]
        [InlineData(false, true)]
        [InlineData(true, false)]
        public void Int64_IsNonZero_Returns_Proper_Results_For_Not_Nullable_Value(bool useZeroValue, bool expected)
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
        public void Int64_IsNonZero_Returns_Proper_Results_For_Nullable_Value(bool useZeroValue, bool expected)
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
        public void Int64_IsNonZero_Fails_For_Null_Value()
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
        public Int64_IsNonZero_Tests()
        {
            _model = new Model();
        }

        private readonly Model _model;

        class Model
        {
            public long Value => 10;
            public long ZeroValue => 0;
            public long? NullableValue => 10;
            public long? NullableZeroValue => 0;
            public long? NullValue => null;
        }
        #endregion
    }
}
