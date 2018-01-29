using Shouldly;
using Xunit;

namespace Valit.Tests.Byte
{
    public class Byte_IsEqualTo_Tests
    {
        [Fact]
        public void Byte_IsEqualTo_For_Not_Nullable_Values_Throws_When_Null_Rule_Is_Given()
        {
            var exception = Record.Exception(() =>
            {
                ((IValitRule<Model, byte>)null)
                    .IsEqualTo(1);
            });

            exception.ShouldBeOfType(typeof(ValitException));
        }

        [Fact]
        public void Byte_IsEqualTo_For_Not_Nullable_Value_And_Nullable_Value_Throws_When_Null_Rule_Is_Given()
        {
            var exception = Record.Exception(() =>
            {
                ((IValitRule<Model, byte>)null)
                    .IsEqualTo((byte?)1);
            });

            exception.ShouldBeOfType(typeof(ValitException));
        }

        [Fact]
        public void Byte_IsEqualTo_For_Nullable_Value_And_Not_Nullable_Value_Throws_When_Null_Rule_Is_Given()
        {
            var exception = Record.Exception(() =>
            {
                ((IValitRule<Model, byte?>)null)
                    .IsEqualTo(1);
            });

            exception.ShouldBeOfType(typeof(ValitException));
        }

        [Fact]
        public void Byte_IsEqualTo_For_Nullable_Values_Throws_When_Null_Rule_Is_Given()
        {
            var exception = Record.Exception(() =>
            {
                ((IValitRule<Model, byte?>)null)
                    .IsEqualTo((byte?)1);
            });

            exception.ShouldBeOfType(typeof(ValitException));
        }


        [Theory]
        [InlineData(10, true)]
        [InlineData(9, false)]
        [InlineData(11, false)]
        public void Byte_IsEqualTo_Returns_Proper_Results_For_Not_Nullable_Values(byte value, bool expected)
        {
            IValitResult result = ValitRules<Model>
                .Create()
                .Ensure(m => m.Value, _ => _
                    .IsEqualTo(value))
                .For(_model)
                .Validate();

            result.Succeeded.ShouldBe(expected);
        }

        [Theory]
        [InlineData((byte)10, true)]
        [InlineData((byte)9, false)]
        [InlineData((byte)11, false)]
        [InlineData(null, false)]
        public void Byte_IsEqualTo_Returns_Proper_Results_For_Not_Nullable_Value_And_Nullable_Value(byte? value, bool expected)
        {
            IValitResult result = ValitRules<Model>
                .Create()
                .Ensure(m => m.Value, _ => _
                    .IsEqualTo(value))
                .For(_model)
                .Validate();

            result.Succeeded.ShouldBe(expected);
        }

        [Theory]
        [InlineData(false, 10, true)]
        [InlineData(false, 9, false)]
        [InlineData(false, 11, false)]
        [InlineData(true, 10, false)]
        public void Byte_IsEqualTo_Returns_Proper_Results_For_Nullable_Value_And_Not_Nullable_Value(bool useNullValue, byte value, bool expected)
        {
            IValitResult result = ValitRules<Model>
                .Create()
                .Ensure(m => useNullValue ? m.NullValue : m.NullableValue, _ => _
                    .IsEqualTo(value))
                .For(_model)
                .Validate();

            result.Succeeded.ShouldBe(expected);
        }

        [Theory]
        [InlineData(false, (byte)10, true)]
        [InlineData(false, (byte)9, false)]
        [InlineData(false, (byte)11, false)]
        [InlineData(false, null, false)]
        [InlineData(true, (byte)10, false)]
        [InlineData(true, null, false)]
        public void Byte_IsEqualTo_Returns_Proper_Results_For_Nullable_Values(bool useNullValue, byte? value, bool expected)
        {
            IValitResult result = ValitRules<Model>
                .Create()
                .Ensure(m => useNullValue ? m.NullValue : m.NullableValue, _ => _
                    .IsEqualTo(value))
                .For(_model)
                .Validate();

            result.Succeeded.ShouldBe(expected);
        }

        #region ARRANGE
        public Byte_IsEqualTo_Tests()
        {
            _model = new Model();
        }

        private readonly Model _model;

        class Model
        {
            public byte Value => 10;
            public byte? NullableValue => 10;
            public byte? NullValue => null;
        }
        #endregion
    }
}
