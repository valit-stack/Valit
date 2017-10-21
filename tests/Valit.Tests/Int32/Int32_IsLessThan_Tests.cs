using Shouldly;
using Xunit;

namespace Valit.Tests.Int32
{
    public class Int32_IsLessThan_Tests
    {
        
        [Fact]
        public void Int32_IsLessThan_For_Not_Nullable_Values_Throws_When_Null_Rule_Is_Given()
        {
            var exception = Record.Exception(() => {
                ((IValitRule<Model, int>)null)
                    .IsLessThan(1);
            });
            
            exception.ShouldBeOfType(typeof(ValitException));
        }

        [Fact]
        public void Int32_IsLessThan_For_Not_Nullable_Value_And_Nullable_Value_Throws_When_Null_Rule_Is_Given()
        {
            var exception = Record.Exception(() => {
                ((IValitRule<Model, int>)null)
                    .IsLessThan((int?)1);
            });
            
            exception.ShouldBeOfType(typeof(ValitException));
        }

        [Fact]
        public void Int32_IsLessThan_For_Nullable_Value_And_Not_Nullable_Value_Throws_When_Null_Rule_Is_Given()
        {
            var exception = Record.Exception(() => {
                ((IValitRule<Model, int?>)null)
                    .IsLessThan(1);
            });
            
            exception.ShouldBeOfType(typeof(ValitException));
        }

        [Fact]
        public void Int32_IsLessThan_For_Nullable_Values_Throws_When_Null_Rule_Is_Given()
        {
            var exception = Record.Exception(() => {
                ((IValitRule<Model, int?>)null)
                    .IsLessThan((int?)1);
            });
            
            exception.ShouldBeOfType(typeof(ValitException));
        }


        [Theory]
        [InlineData(11, true)]
        [InlineData(10, false)]
        [InlineData(9, false)]     
        public void Int32_IsLessThan_Returns_Proper_Results_For_Not_Nullable_Values(int value,  bool expected)
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
        [InlineData((int) 11, true)]
        [InlineData((int) 10, false)]
        [InlineData((int) 9, false)]     
        [InlineData(null, false)]     
        public void Int32_IsLessThan_Returns_Proper_Results_For_Not_Nullable_Value_And_Nullable_Value(int? value,  bool expected)
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
        public void Int32_IsLessThan_Returns_Proper_Results_For_Nullable_Value_And_Not_Nullable_Value(bool useNullValue, int value,  bool expected)
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
        [InlineData(false, (int) 11, true)] 
        [InlineData(false, (int) 10, false)]    
        [InlineData(false, (int) 9, false)]
        [InlineData(false, null, false)]     
        [InlineData(true, (int) 11, false)]     
        [InlineData(true, null, false)]     
        public void Int32_IsLessThan_Returns_Proper_Results_For_Nullable_Values(bool useNullValue, int? value,  bool expected)
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
        public Int32_IsLessThan_Tests()
        {
            _model = new Model();
        }

        private readonly Model _model;

        class Model
        {
            public int Value => 10;
            public int? NullableValue => 10;
            public int? NullValue => null;
        }
#endregion
    }
    
}