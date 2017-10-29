using System;
using Shouldly;
using Valit.Tests.HelperExtensions;
using Xunit;

namespace Valit.Tests.DateTime_
{
    public class DateTime_IsAfter_Tests
    {
        [Fact]
        public void DateTime_IsAfter_For_Not_Nullable_Values_Throws_When_Null_Rule_Is_Given()
        {
            var exception = Record.Exception(() => {
                ((IValitRule<Model, DateTime>)null)
                    .IsAfter(DateTime.Now);
            });
            
            exception.ShouldBeOfType(typeof(ValitException));
        }

        [Fact]
        public void DateTime_IsAfter_For_Not_Nullable_Value_And_Nullable_Value_Throws_When_Null_Rule_Is_Given()
        {
            var exception = Record.Exception(() => {
                ((IValitRule<Model, DateTime>)null)
                    .IsAfter((DateTime?)DateTime.Now);
            });
            
            exception.ShouldBeOfType(typeof(ValitException));
        }

        [Fact]
        public void DateTime_IsAfter_For_Nullable_Value_And_Not_Nullable_Value_Throws_When_Null_Rule_Is_Given()
        {
            var exception = Record.Exception(() => {
                ((IValitRule<Model, DateTime?>)null)
                    .IsAfter(DateTime.Now);
            });
            
            exception.ShouldBeOfType(typeof(ValitException));
        }    

        [Fact]
        public void DateTime_IsAfter_For_Nullable_Values_Throws_When_Null_Rule_Is_Given()
        {
            var exception = Record.Exception(() => {
                ((IValitRule<Model, DateTime?>)null)
                    .IsAfter((DateTime?) DateTime.Now);
            });
            
            exception.ShouldBeOfType(typeof(ValitException));
        }

        [Theory]
        [InlineData("2017-06-09", true)]
        [InlineData("2017-06-10", false)]
        [InlineData("2017-06-11", false)]     
        public void DateTime_IsAfter_Returns_Proper_Results_For_Not_Nullable_Values(DateTime value,  bool expected)
        {            
            IValitResult result = ValitRules<Model>
                .Create()
                .Ensure(m => m.Value, _=>_
                    .IsAfter(value))
                .For(_model)
                .Validate();

            Assert.Equal(result.Succeeded, expected);
        }   

        [Theory]
        [InlineData("2017-06-09", true)]
        [InlineData("2017-06-10", false)]
        [InlineData("2017-06-11", false)]     
        [InlineData(null, false)]     
        public void DateTime_IsAfter_Returns_Proper_Results_For_Not_Nullable_Value_And_Nullable_Value(string stringValue,  bool expected)
        {            
            DateTime? value = stringValue.AsNullableDateTime();

            IValitResult result = ValitRules<Model>
                .Create()
                .Ensure(m => m.Value, _=>_
                    .IsAfter(value))
                .For(_model)
                .Validate();

            Assert.Equal(result.Succeeded, expected);
        }

        [Theory]
        [InlineData(false, "2017-06-09", true)]
        [InlineData(false, "2017-06-10", false)]        
        [InlineData(false, "2017-06-11", false)]     
        [InlineData(true, "2017-06-09", false)]     
        public void DateTime_IsAfter_Returns_Proper_Results_For_Nullable_Value_And_Not_Nullable_Value(bool useNullValue, DateTime value,  bool expected)
        {            
            IValitResult result = ValitRules<Model>
                .Create()
                .Ensure(m => useNullValue? m.NullValue : m.NullableValue, _=>_
                    .IsAfter(value))
                .For(_model)
                .Validate();

            Assert.Equal(result.Succeeded, expected);
        }

        [Theory]
        [InlineData(false, "2017-06-09", true)] 
        [InlineData(false, "2017-06-10", false)]    
        [InlineData(false, "2017-06-11", false)]
        [InlineData(false, null, false)]     
        [InlineData(true, "2017-06-09", false)]     
        [InlineData(true, null, false)]     
        public void DateTime_IsAfter_Returns_Proper_Results_For_Nullable_Values(bool useNullValue, string stringValue,  bool expected)
        {    
            DateTime? value = stringValue.AsNullableDateTime();

            IValitResult result = ValitRules<Model>
                .Create()
                .Ensure(m => useNullValue? m.NullValue : m.NullableValue, _=>_
                    .IsAfter(value))
                .For(_model)
                .Validate();

            Assert.Equal(result.Succeeded, expected);
        }

#region ARRANGE
        public DateTime_IsAfter_Tests()
        {
            _model = new Model();
        }

        private readonly Model _model;

        class Model
        {
            public DateTime Value => new DateTime(2017, 6, 10);
            public DateTime? NullableValue => new DateTime(2017, 6, 10);
            public DateTime? NullValue => null;
        }
#endregion 
    }
}