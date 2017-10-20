using System;
using Shouldly;
using Valit.Tests.HelperExtensions;
using Xunit;

namespace Valit.Tests.Decimal
{
    public class Decimal_IsLessThan_Tests
    {
  [Fact]
        public void Decimal_IsLessThan_For_Not_Nullable_Values_Throws_When_Null_Rule_Is_Given()
        {
            var exception = Record.Exception(() => {
                ((IValitRule<Model, decimal>)null)
                    .IsLessThan(1);
            });
            
            exception.ShouldBeOfType(typeof(ValitException));
        }

        [Fact]
        public void Decimal_IsLessThan_For_Not_Nullable_Value_And_Nullable_Value_Throws_When_Null_Rule_Is_Given()
        {
            var exception = Record.Exception(() => {
                ((IValitRule<Model, decimal>)null)
                    .IsLessThan((decimal?)1);
            });
            
            exception.ShouldBeOfType(typeof(ValitException));
        }

        [Fact]
        public void Decimal_IsLessThan_For_Nullable_Value_And_Not_Nullable_Value_Throws_When_Null_Rule_Is_Given()
        {
            var exception = Record.Exception(() => {
                ((IValitRule<Model, decimal?>)null)
                    .IsLessThan(1);
            });
            
            exception.ShouldBeOfType(typeof(ValitException));
        }

        [Fact]
        public void Decimal_IsLessThan_For_Nullable_Values_Throws_When_Null_Rule_Is_Given()
        {
            var exception = Record.Exception(() => {
                ((IValitRule<Model, decimal?>)null)
                    .IsLessThan((decimal?)1);
            });
            
            exception.ShouldBeOfType(typeof(ValitException));
        }


        [Theory]
        [InlineData(11, true)]
        [InlineData(10, false)]
        [InlineData(9, false)]     
        public void Decimal_IsLessThan_Returns_Proper_Results_For_Not_Nullable_Values(decimal value,  bool expected)
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
        [InlineData("11", true)]
        [InlineData("10", false)]
        [InlineData("9", false)]     
        [InlineData(null, false)]     
        public void Decimal_IsLessThan_Returns_Proper_Results_For_Not_Nullable_Value_And_Nullable_Value(string stringValue,  bool expected)
        {            
            decimal? value = stringValue.AsNullableDecimal();

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
        public void Decimal_IsLessThan_Returns_Proper_Results_For_Nullable_Value_And_Not_Nullable_Value(bool useNullValue, decimal value,  bool expected)
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
        [InlineData(false, "11", true)] 
        [InlineData(false, "10", false)]    
        [InlineData(false, "9", false)]
        [InlineData(false, null, false)]     
        [InlineData(true, "11", false)]     
        [InlineData(true, null, false)]     
        public void Decimal_IsLessThan_Returns_Proper_Results_For_Nullable_Values(bool useNullValue, string stringValue,  bool expected)
        {            
            decimal? value = stringValue.AsNullableDecimal();

            IValitResult result = ValitRules<Model>
                .Create()
                .Ensure(m => useNullValue? m.NullValue : m.NullableValue, _=>_
                    .IsLessThan(value))
                .For(_model)
                .Validate();

            Assert.Equal(result.Succeeded, expected);
        }

#region ARRANGE
        public Decimal_IsLessThan_Tests()
        {
            _model = new Model();
        }

        private readonly Model _model;

        class Model
        {
            public decimal Value => 10;
            public decimal? NullableValue => 10;
            public decimal? NullValue => null;
        }
#endregion
    }
    
}