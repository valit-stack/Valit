using Shouldly;
using Xunit;

namespace Valit.Tests.UInt64
{
    public class UInt64_IsLessThan_Tests
    {
        
        [Fact]
        public void UInt64_IsLessThan_For_Not_Nullable_Values_Throws_When_Null_Rule_Is_Given()
        {
            var exception = Record.Exception(() => {
                ((IValitRule<Model, ulong>)null)
                    .IsLessThan(1);
            });
            
            exception.ShouldBeOfType(typeof(ValitException));
        }

        [Fact]
        public void UInt64_IsLessThan_For_Not_Nullable_Value_And_Nullable_Value_Throws_When_Null_Rule_Is_Given()
        {
            var exception = Record.Exception(() => {
                ((IValitRule<Model, ulong>)null)
                    .IsLessThan((ulong?)1);
            });
            
            exception.ShouldBeOfType(typeof(ValitException));
        }

        [Fact]
        public void UInt64_IsLessThan_For_Nullable_Value_And_Not_Nullable_Value_Throws_When_Null_Rule_Is_Given()
        {
            var exception = Record.Exception(() => {
                ((IValitRule<Model, ulong?>)null)
                    .IsLessThan(1);
            });
            
            exception.ShouldBeOfType(typeof(ValitException));
        }

        [Fact]
        public void UInt64_IsLessThan_For_Nullable_Values_Throws_When_Null_Rule_Is_Given()
        {
            var exception = Record.Exception(() => {
                ((IValitRule<Model, ulong?>)null)
                    .IsLessThan((ulong?)1);
            });
            
            exception.ShouldBeOfType(typeof(ValitException));
        }


        [Theory]
        [InlineData(11, true)]
        [InlineData(10, false)]
        [InlineData(9, false)]     
        public void UInt64_IsLessThan_Returns_Proper_Results_For_Not_Nullable_Values(ulong value,  bool expected)
        {            
            IValitResult result = ValitRules<Model>
                .Create()
                .Ensure(m => m.Value, _=>_
                    .IsLessThan(value))
                .For(_model)
                .Validate();

            Assert.Equal(result.Succeeded, expected);
        }

        [Theory]
        [InlineData((ulong) 11, true)]
        [InlineData((ulong) 10, false)]
        [InlineData((ulong) 9, false)]     
        [InlineData(null, false)]     
        public void UInt64_IsLessThan_Returns_Proper_Results_For_Not_Nullable_Value_And_Nullable_Value(ulong? value,  bool expected)
        {            
            IValitResult result = ValitRules<Model>
                .Create()
                .Ensure(m => m.Value, _=>_
                    .IsLessThan(value))
                .For(_model)
                .Validate();

            Assert.Equal(result.Succeeded, expected);
        }

        [Theory]
        [InlineData(false, 11, true)]
        [InlineData(false, 10, false)]        
        [InlineData(false, 9, false)]     
        [InlineData(true, 11, false)]     
        public void UInt64_IsLessThan_Returns_Proper_Results_For_Nullable_Value_And_Not_Nullable_Value(bool useNullValue, ulong value,  bool expected)
        {            
            IValitResult result = ValitRules<Model>
                .Create()
                .Ensure(m => useNullValue? m.NullValue : m.NullableValue, _=>_
                    .IsLessThan(value))
                .For(_model)
                .Validate();

            Assert.Equal(result.Succeeded, expected);
        }

        [Theory]
        [InlineData(false, (ulong) 11, true)] 
        [InlineData(false, (ulong) 10, false)]    
        [InlineData(false, (ulong) 9, false)]
        [InlineData(false, null, false)]     
        [InlineData(true, (ulong) 11, false)]     
        [InlineData(true, null, false)]     
        public void UInt64_IsLessThan_Returns_Proper_Results_For_Nullable_Values(bool useNullValue, ulong? value,  bool expected)
        {            
            IValitResult result = ValitRules<Model>
                .Create()
                .Ensure(m => useNullValue? m.NullValue : m.NullableValue, _=>_
                    .IsLessThan(value))
                .For(_model)
                .Validate();

            Assert.Equal(result.Succeeded, expected);
        }

#region ARRANGE
        public UInt64_IsLessThan_Tests()
        {
            _model = new Model();
        }

        private readonly Model _model;

        class Model
        {
            public ulong Value => 10;
            public ulong? NullableValue => 10;
            public ulong? NullValue => null;
        }
#endregion
    }
    
}