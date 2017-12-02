using Shouldly;
using Xunit;

namespace Valit.Tests.Int16
{
    public class Int16_IsLessThan_Tests
    {

        [Fact]
        public void Int16_IsLessThan_For_Not_Nullable_Values_Throws_When_Null_Rule_Is_Given()
        {
            var exception = Record.Exception(() => {
                ((IValitRule<Model, short>)null)
                    .IsLessThan(1);
            });

            exception.ShouldBeOfType(typeof(ValitException));
        }

        [Fact]
        public void Int16_IsLessThan_For_Not_Nullable_Value_And_Nullable_Value_Throws_When_Null_Rule_Is_Given()
        {
            var exception = Record.Exception(() => {
                ((IValitRule<Model, short>)null)
                    .IsLessThan((short?)1);
            });

            exception.ShouldBeOfType(typeof(ValitException));
        }

        [Fact]
        public void Int16_IsLessThan_For_Nullable_Value_And_Not_Nullable_Value_Throws_When_Null_Rule_Is_Given()
        {
            var exception = Record.Exception(() => {
                ((IValitRule<Model, short?>)null)
                    .IsLessThan(1);
            });

            exception.ShouldBeOfType(typeof(ValitException));
        }

        [Fact]
        public void Int16_IsLessThan_For_Nullable_Values_Throws_When_Null_Rule_Is_Given()
        {
            var exception = Record.Exception(() => {
                ((IValitRule<Model, short?>)null)
                    .IsLessThan((short?)1);
            });

            exception.ShouldBeOfType(typeof(ValitException));
        }


        [Theory]
        [InlineData(11, true)]
        [InlineData(10, false)]
        [InlineData(9, false)]
        public void Int16_IsLessThan_Returns_Proper_Results_For_Not_Nullable_Values(short value,  bool expected)
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
        [InlineData((short) 11, true)]
        [InlineData((short) 10, false)]
        [InlineData((short) 9, false)]
        [InlineData(null, false)]
        public void Int16_IsLessThan_Returns_Proper_Results_For_Not_Nullable_Value_And_Nullable_Value(short? value,  bool expected)
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
        public void Int16_IsLessThan_Returns_Proper_Results_For_Nullable_Value_And_Not_Nullable_Value(bool useNullValue, short value,  bool expected)
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
        [InlineData(false, (short) 11, true)]
        [InlineData(false, (short) 10, false)]
        [InlineData(false, (short) 9, false)]
        [InlineData(false, null, false)]
        [InlineData(true, (short) 11, false)]
        [InlineData(true, null, false)]
        public void Int16_IsLessThan_Returns_Proper_Results_For_Nullable_Values(bool useNullValue, short? value,  bool expected)
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
        public Int16_IsLessThan_Tests()
        {
            _model = new Model();
        }

        private readonly Model _model;

        class Model
        {
            public short Value => 10;
            public short? NullableValue => 10;
            public short? NullValue => null;
        }
#endregion
    }

}
