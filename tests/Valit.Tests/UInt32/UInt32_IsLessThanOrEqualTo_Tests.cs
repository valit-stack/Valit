using Shouldly;
using Xunit;

namespace Valit.Tests.UInt32
{
    public class UInt32_IsLessThanOrEqualTo_Tests
    {
        [Fact]
        public void UInt32_IsLessThanOrEqualTo_For_Not_Nullable_Values_Throws_When_Null_Rule_Is_Given()
        {
            var exception = Record.Exception(() => {
                ((IValitRule<Model, uint>)null)
                    .IsLessThanOrEqualTo(1);
            });

            exception.ShouldBeOfType(typeof(ValitException));
        }

        [Fact]
        public void UInt32_IsLessThanOrEqualTo_For_Not_Nullable_Value_And_Nullable_Value_Throws_When_Null_Rule_Is_Given()
        {
            var exception = Record.Exception(() => {
                ((IValitRule<Model, uint>)null)
                    .IsLessThanOrEqualTo((uint?)1);
            });

            exception.ShouldBeOfType(typeof(ValitException));
        }

        [Fact]
        public void UInt32_IsLessThanOrEqualTo_For_Nullable_Value_And_Not_Nullable_Value_Throws_When_Null_Rule_Is_Given()
        {
            var exception = Record.Exception(() => {
                ((IValitRule<Model, uint?>)null)
                    .IsLessThanOrEqualTo(1);
            });

            exception.ShouldBeOfType(typeof(ValitException));
        }

        [Fact]
        public void UInt32_IsLessThanOrEqualTo_For_Nullable_Values_Throws_When_Null_Rule_Is_Given()
        {
            var exception = Record.Exception(() => {
                ((IValitRule<Model, uint?>)null)
                    .IsLessThanOrEqualTo((uint?)1);
            });

            exception.ShouldBeOfType(typeof(ValitException));
        }


        [Theory]
        [InlineData(11, true)]
        [InlineData(10, true)]
        [InlineData(9, false)]
        public void UInt32_IsLessThanOrEqualTo_Returns_Proper_Results_For_Not_Nullable_Values(uint value,  bool expected)
        {
            IValitResult result = ValitRules<Model>
                .Create()
                .Ensure(m => m.Value, _=>_
                    .IsLessThanOrEqualTo(value))
                .For(_model)
                .Validate();

            Assert.Equal(result.Succeeded, expected);
        }

        [Theory]
        [InlineData((uint) 11, true)]
        [InlineData((uint) 10, true)]
        [InlineData((uint) 9, false)]
        [InlineData(null, false)]
        public void UInt32_IsLessThanOrEqualTo_Returns_Proper_Results_For_Not_Nullable_Value_And_Nullable_Value(uint? value,  bool expected)
        {
            IValitResult result = ValitRules<Model>
                .Create()
                .Ensure(m => m.Value, _=>_
                    .IsLessThanOrEqualTo(value))
                .For(_model)
                .Validate();

            Assert.Equal(result.Succeeded, expected);
        }

        [Theory]
        [InlineData(false, 11, true)]
        [InlineData(false, 10, true)]
        [InlineData(false, 9, false)]
        [InlineData(true, 11, false)]
        public void UInt32_IsLessThanOrEqualTo_Returns_Proper_Results_For_Nullable_Value_And_Not_Nullable_Value(bool useNullValue, uint value,  bool expected)
        {
            IValitResult result = ValitRules<Model>
                .Create()
                .Ensure(m => useNullValue? m.NullValue : m.NullableValue, _=>_
                    .IsLessThanOrEqualTo(value))
                .For(_model)
                .Validate();

            Assert.Equal(result.Succeeded, expected);
        }

        [Theory]
        [InlineData(false, (uint) 11, true)]
        [InlineData(false, (uint) 10, true)]
        [InlineData(false, (uint) 9, false)]
        [InlineData(false, null, false)]
        [InlineData(true, (uint) 11, false)]
        [InlineData(true, null, false)]
        public void UInt32_IsLessThanOrEqualTo_Returns_Proper_Results_For_Nullable_Values(bool useNullValue, uint? value,  bool expected)
        {
            IValitResult result = ValitRules<Model>
                .Create()
                .Ensure(m => useNullValue? m.NullValue : m.NullableValue, _=>_
                    .IsLessThanOrEqualTo(value))
                .For(_model)
                .Validate();

            Assert.Equal(result.Succeeded, expected);
        }

#region ARRANGE
        public UInt32_IsLessThanOrEqualTo_Tests()
        {
            _model = new Model();
        }

        private readonly Model _model;

        class Model
        {
            public uint Value => 10;
            public uint? NullableValue => 10;
            public uint? NullValue => null;
        }
#endregion
    }
}
