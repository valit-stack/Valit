using System;
using Shouldly;
using Xunit;

namespace Valit.Tests.Boolean
{
    public class Boolean_IsEqualTo_Tests
    {
        [Fact]
        public void Boolean_IsEqualTo_For_Not_Nullable_Values_Throws_When_Null_Rule_Is_Given()
        {
            var exception = Record.Exception(() =>
            {
                ((IValitRule<Model, bool>)null)
                    .IsEqualTo(true);
            });

            exception.ShouldBeOfType(typeof(ValitException));
        }

        [Fact]
        public void Boolean_IsEqualTo_For_Not_Nullable_Value_And_Nullable_Value_Throws_When_Null_Rule_Is_Given()
        {
            var exception = Record.Exception(() =>
            {
                ((IValitRule<Model, bool>)null)
                    .IsEqualTo((bool?)true);
            });

            exception.ShouldBeOfType(typeof(ValitException));
        }

        [Fact]
        public void Boolean_IsEqualTo_For_Nullable_Value_And_Not_Nullable_Value_Throws_When_Null_Rule_Is_Given()
        {
            var exception = Record.Exception(() =>
            {
                ((IValitRule<Model, bool?>)null)
                    .IsEqualTo(true);
            });

            exception.ShouldBeOfType(typeof(ValitException));
        }

        [Fact]
        public void Boolean_IsEqualTo_For_Nullable_Values_Throws_When_Null_Rule_Is_Given()
        {
            var exception = Record.Exception(() =>
            {
                ((IValitRule<Model, bool?>)null)
                    .IsEqualTo((bool?)true);
            });

            exception.ShouldBeOfType(typeof(ValitException));
        }

        [Theory]
        [InlineData(true, true)]
        [InlineData(false, false)]
        public void Boolean_IsEqualTo_Returns_Proper_Results_For_Not_Nullable_Values(bool value, bool expected)
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
        [InlineData(false, true, true)]
        [InlineData(false, false, false)]
        [InlineData(true, true, false)]
        [InlineData(true, false, false)]
        public void Boolean_IsEqualTo_Returns_Proper_Results_For_Nullable_Value_And_Not_Nullable_Value(bool useNullValue, bool value, bool expected)
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
        public Boolean_IsEqualTo_Tests()
        {
            _model = new Model();
        }

        private readonly Model _model;

        class Model
        {
            public bool Value => true;
            public bool? NullableValue => true;
            public bool? NullValue => null;
        }
        #endregion
    }
}
