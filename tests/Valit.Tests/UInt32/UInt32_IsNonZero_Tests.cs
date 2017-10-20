using Shouldly;
using Xunit;

namespace Valit.Tests.UInt32
{
    public class UInt32_IsNonZero_Tests
    {
       [Fact]
        public void UInt32_IsNonZero_For_Not_Nullable_Value_Throws_When_Null_Rule_Is_Given()
        {
            var exception = Record.Exception(() => {
                ((IValitRule<Model, uint>)null)
                    .IsNonZero();
            });
            
            exception.ShouldBeOfType(typeof(ValitException));
        }

        [Fact]
        public void UInt32_IsNonZero_For_Nullable_Value_Throws_When_Null_Rule_Is_Given()
        {
            var exception = Record.Exception(() => {
                ((IValitRule<Model, uint?>)null)
                    .IsNonZero();
            });
            
            exception.ShouldBeOfType(typeof(ValitException));
        }


        [Theory]
        [InlineData(false, true)]
        [InlineData(true, false)] 
        public void UInt32_IsNonZero_Returns_Proper_Results_For_Not_Nullable_Value(bool useZeroValue,  bool expected)
        {            
            IValitResult result = ValitRules<Model>
                .Create()
                .Ensure(m => useZeroValue? m.ZeroValue : m.Value, _=>_
                    .IsNonZero())
                .For(_model)
                .Validate();

            Assert.Equal(result.Succeeded, expected);
        }

        [Theory]
        [InlineData(false, true)]
        [InlineData(true, false)] 
        public void UInt32_IsNonZero_Returns_Proper_Results_For_Nullable_Value(bool useZeroValue,  bool expected)
        {            
            IValitResult result = ValitRules<Model>
                .Create()
                .Ensure(m => useZeroValue? m.NullableZeroValue : m.NullableValue, _=>_
                    .IsNonZero())
                .For(_model)
                .Validate();

            Assert.Equal(result.Succeeded, expected);
        }

        [Fact]
        public void UInt32_IsNonZero_Fails_For_Null_Value()
        {            
            IValitResult result = ValitRules<Model>
                .Create()
                .Ensure(m => m.NullValue, _=>_
                    .IsNonZero())
                .For(_model)
                .Validate();

            Assert.Equal(result.Succeeded, false);
        }

#region ARRANGE
        public UInt32_IsNonZero_Tests()
        {
            _model = new Model();
        }

        private readonly Model _model;

        class Model
        {
            public uint Value => 10;
            public uint ZeroValue => 0;
            public uint? NullableValue => 10;
            public uint? NullableZeroValue => 0;
            public uint? NullValue => null;
        }
#endregion
    }
}