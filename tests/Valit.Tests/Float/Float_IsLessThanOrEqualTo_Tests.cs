using Shouldly;
using System;
using Xunit;

namespace Valit.Tests.Float
{
    public class Float_IsLessThanOrEqualTo_Tests
    {
        [Fact]
        public void Float_IsLessThanOrEqualTo_For_Not_Nullable_Values_Throws_When_Null_Rule_Is_Given()
        {
            var exception = Record.Exception(() => {
                ((IValitRule<Model, float>)null)
                    .IsLessThanOrEqualTo(1);
            });

            exception.ShouldBeOfType(typeof(ValitException));
        }

        [Fact]
        public void Float_IsLessThanOrEqualTo_For_Not_Nullable_Value_And_Nullable_Value_Throws_When_Null_Rule_Is_Given()
        {
            var exception = Record.Exception(() => {
                ((IValitRule<Model, float>)null)
                    .IsLessThanOrEqualTo((float?)1);
            });

            exception.ShouldBeOfType(typeof(ValitException));
        }

        [Fact]
        public void Float_IsLessThanOrEqualTo_For_Nullable_Value_And_Not_Nullable_Value_Throws_When_Null_Rule_Is_Given()
        {
            var exception = Record.Exception(() => {
                ((IValitRule<Model, float?>)null)
                    .IsLessThanOrEqualTo(1);
            });

            exception.ShouldBeOfType(typeof(ValitException));
        }

        [Fact]
        public void Float_IsLessThanOrEqualTo_For_Nullable_Values_Throws_When_Null_Rule_Is_Given()
        {
            var exception = Record.Exception(() => {
                ((IValitRule<Model, float?>)null)
                    .IsLessThanOrEqualTo((float?)1);
            });

            exception.ShouldBeOfType(typeof(ValitException));
        }


        [Theory]
        [InlineData(11, true)]
        [InlineData(10, true)]
        [InlineData(9, false)]
        [InlineData(Single.NaN, false)]
        public void Float_IsLessThanOrEqualTo_Returns_Proper_Results_For_Not_Nullable_Values(float value, bool expected)
        {
            IValitResult result = ValitRules<Model>
                .Create()
                .Ensure(m => m.Value, _ => _
                    .IsLessThanOrEqualTo(value))
                .For(_model)
                .Validate();

            result.Succeeded.ShouldBe(expected);
        }

        [Theory]
        [InlineData(11, false)]
        [InlineData(Single.NaN, false)]
        public void Float_IsLessThanOrEqualTo_Returns_Proper_Results_For_NaN_And_Value(float value, bool expected)
        {
            IValitResult result = ValitRules<Model>
                .Create()
                .Ensure(m => m.NaN, _ => _
                    .IsLessThanOrEqualTo(value))
                .For(_model)
                .Validate();

            result.Succeeded.ShouldBe(expected);
        }

        [Theory]
        [InlineData(11, false)]
        [InlineData(Single.NaN, false)]
        public void Float_IsLessThanOrEqualTo_Returns_Proper_Results_For_NaN_And_NullableValue(float? value, bool expected)
        {
            IValitResult result = ValitRules<Model>
                .Create()
                .Ensure(m => m.NaN, _ => _
                    .IsLessThanOrEqualTo(value))
                .For(_model)
                .Validate();

            result.Succeeded.ShouldBe(expected);
        }

        [Theory]
        [InlineData(11, false)]
        [InlineData(Single.NaN, false)]
        public void Float_IsLessThanOrEqualTo_Returns_Proper_Results_For_NullableNaN_And_Value(float value, bool expected)
        {
            IValitResult result = ValitRules<Model>
                .Create()
                .Ensure(m => m.NullableNaN, _ => _
                    .IsLessThanOrEqualTo(value))
                .For(_model)
                .Validate();

            result.Succeeded.ShouldBe(expected);
        }

        [Theory]
        [InlineData(11, false)]
        [InlineData(Single.NaN, false)]
        public void Float_IsLessThanOrEqualTo_Returns_Proper_Results_For_NullableNaN_And_NullableValue(float? value, bool expected)
        {
            IValitResult result = ValitRules<Model>
                .Create()
                .Ensure(m => m.NullableNaN, _ => _
                    .IsLessThanOrEqualTo(value))
                .For(_model)
                .Validate();

            result.Succeeded.ShouldBe(expected);
        }

        [Theory]
        [InlineData((float)11, true)]
        [InlineData((float)10, true)]
        [InlineData((float)9, false)]
        [InlineData(Single.NaN, false)]
        [InlineData(null, false)]
        public void Float_IsLessThanOrEqualTo_Returns_Proper_Results_For_Not_Nullable_Value_And_Nullable_Value(float? value, bool expected)
        {
            IValitResult result = ValitRules<Model>
                .Create()
                .Ensure(m => m.Value, _ => _
                    .IsLessThanOrEqualTo(value))
                .For(_model)
                .Validate();

            result.Succeeded.ShouldBe(expected);
        }

        [Theory]
        [InlineData(false, 11, true)]
        [InlineData(false, 10, true)]
        [InlineData(false, 9, false)]
        [InlineData(true, 10, false)]
        [InlineData(false, Single.NaN, false)]
        [InlineData(true, Single.NaN, false)]
        public void Float_IsLessThanOrEqualTo_Returns_Proper_Results_For_Nullable_Value_And_Not_Nullable_Value(bool useNullValue, float value, bool expected)
        {
            IValitResult result = ValitRules<Model>
                .Create()
                .Ensure(m => useNullValue ? m.NullValue : m.NullableValue, _ => _
                    .IsLessThanOrEqualTo(value))
                .For(_model)
                .Validate();

            result.Succeeded.ShouldBe(expected);
        }

        [Theory]
        [InlineData(false, (float)11, true)]
        [InlineData(false, (float)10, true)]
        [InlineData(false, (float)9, false)]
        [InlineData(false, Single.NaN, false)]
        [InlineData(false, null, false)]
        [InlineData(true, (float)10, false)]
        [InlineData(true, Single.NaN, false)]
        [InlineData(true, null, false)]
        public void Float_IsLessThanOrEqualTo_Returns_Proper_Results_For_Nullable_Values(bool useNullValue, float? value, bool expected)
        {
            IValitResult result = ValitRules<Model>
                .Create()
                .Ensure(m => useNullValue ? m.NullValue : m.NullableValue, _ => _
                    .IsLessThanOrEqualTo(value))
                .For(_model)
                .Validate();

            result.Succeeded.ShouldBe(expected);
        }

        #region ARRANGE
        public Float_IsLessThanOrEqualTo_Tests()
        {
            _model = new Model();
        }

        private readonly Model _model;

        class Model
        {
            public float Value => 10;
            public float NaN => Single.NaN;
            public float? NullableValue => 10;
            public float? NullValue => null;
            public float? NullableNaN => Single.NaN;
        }
        #endregion

    }
}
