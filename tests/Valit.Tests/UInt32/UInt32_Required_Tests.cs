using Shouldly;
using Xunit;

namespace Valit.Tests.UInt32
{
    public class UInt32_Required_Tests
    {

        [Fact]
        public void UInt32_Required_For_Nullable_Value_Throws_When_Null_Rule_Is_Given()
        {
            var exception = Record.Exception(() => {
                ((IValitRule<Model, uint?>)null)
                    .Required();
            });

            exception.ShouldBeOfType(typeof(ValitException));
        }


        [Theory]
        [InlineData(false, true)]
        [InlineData(true, false)]
        public void UInt32_Required_Returns_Proper_Results_For_Nullable_Value(bool useNullValue,  bool expected)
        {
            IValitResult result = ValitRules<Model>
                .Create()
                .Ensure(m => useNullValue? m.NullValue : m.NullableValue, _=>_
                    .Required())
                .For(_model)
                .Validate();

            result.Succeeded.ShouldBe(expected);
        }

#region ARRANGE
        public UInt32_Required_Tests()
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
