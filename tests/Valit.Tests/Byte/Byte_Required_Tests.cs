using Shouldly;
using Xunit;

namespace Valit.Tests.Byte
{
    public class Byte_Required_Tests
    {

        [Fact]
        public void Byte_Required_For_Nullable_Value_Throws_When_Null_Rule_Is_Given()
        {
            var exception = Record.Exception(() => {
                ((IValitRule<Model, byte?>)null)
                    .Required();
            });

            exception.ShouldBeOfType(typeof(ValitException));
        }


        [Theory]
        [InlineData(false, true)]
        [InlineData(true, false)]
        public void Byte_Required_Returns_Proper_Results_For_Nullable_Value(bool useNullValue,  bool expected)
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
        public Byte_Required_Tests()
        {
            _model = new Model();
        }

        private readonly Model _model;

        class Model
        {
            public byte Value => 10;
            public byte ZeroValue => 0;
            public byte? NullableValue => 10;
            public byte? NullableZeroValue => 0;
            public byte? NullValue => null;
        }
#endregion
    }
}
