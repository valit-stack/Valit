using Shouldly;
using Xunit;

namespace Valit.Tests.Int16
{
    public class Int16_Required_Tests
    {

        [Fact]
        public void Int16_Required_For_Nullable_Value_Throws_When_Null_Rule_Is_Given()
        {
            var exception = Record.Exception(() => {
                ((IValitRule<Model, short?>)null)
                    .Required();
            });
            
            exception.ShouldBeOfType(typeof(ValitException));
        }


        [Theory]
        [InlineData(false, true)]
        [InlineData(true, false)] 
        public void Int16_Required_Returns_Proper_Results_For_Nullable_Value(bool useNullValue,  bool expected)
        {            
            IValitResult result = ValitRules<Model>
                .Create()
                .Ensure(m => useNullValue? m.NullValue : m.NullableValue, _=>_
                    .Required())
                .For(_model)
                .Validate();

            Assert.Equal(result.Succeeded, expected);
        }

#region ARRANGE
        public Int16_Required_Tests()
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