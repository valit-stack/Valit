using Shouldly;
using Xunit;

namespace Valit.Tests.Int16
{
    public class Int16_IsNonZero_Tests
    {
        [Fact]
        public void Int16_IsNonZero_For_Not_Nullable_Value_Throws_When_Null_Rule_Is_Given()
        {
            var exception = Record.Exception(() =>
            {
                ((IValitRule<Model, short>)null)
                    .IsNonZero();
            });

            exception.ShouldBeOfType(typeof(ValitException));
        }

        [Fact]
        public void Int16_IsNonZero_For_Nullable_Value_Throws_When_Null_Rule_Is_Given()
        {
            var exception = Record.Exception(() =>
            {
                ((IValitRule<Model, short?>)null)
                    .IsNonZero();
            });

            exception.ShouldBeOfType(typeof(ValitException));
        }


        [Theory]
        [InlineData(false, true)]
        [InlineData(true, false)]
        public void Int16_IsNonZero_Returns_Proper_Results_For_Not_Nullable_Value(bool useZeroValue, bool expected)
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
        public void Int16_IsNonZero_Returns_Proper_Results_For_Nullable_Value(bool useZeroValue, bool expected)
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
        public void Int16_IsNonZero_Fails_For_Null_Value()
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
        public Int16_IsNonZero_Tests()
        {
            _model = new Model();
        }

        private readonly Model _model;

        class Model
        {
            public short Value => 10;
            public short ZeroValue => 0;
            public short? NullableValue => 10;
            public short? NullableZeroValue => 0;
            public short? NullValue => null;
        }
        #endregion
    }
}
