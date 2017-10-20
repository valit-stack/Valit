using Shouldly;
using Xunit;

namespace Valit.Tests.UInt16
{
    public class UInt16_Required_Tests
    {

        [Fact]
        public void UInt16_Required_For_Nullable_Value_Throws_When_Null_Rule_Is_Given()
        {
            var exception = Record.Exception(() => {
                ((IValitRule<Model, ushort?>)null)
                    .Required();
            });
            
            exception.ShouldBeOfType(typeof(ValitException));
        }


        [Theory]
        [InlineData(false, true)]
        [InlineData(true, false)] 
        public void UInt16_Required_Returns_Proper_Results_For_Nullable_Value(bool useNullValue,  bool expected)
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
        public UInt16_Required_Tests()
        {
            _model = new Model();
        }

        private readonly Model _model;

        class Model
        {
            public ushort Value => 10;
            public ushort ZeroValue => 0;
            public ushort? NullableValue => 10;
            public ushort? NullableZeroValue => 0;
            public ushort? NullValue => null;
        }
#endregion
    }
}