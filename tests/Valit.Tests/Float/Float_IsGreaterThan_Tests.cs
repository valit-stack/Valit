using Shouldly;
using System;
using Xunit;

namespace Valit.Tests.Float
{
    public class Float_IsGreaterThan_Tests
    {
        [Fact]
        public void Float_IsGreaterThan_For_Not_Nullable_Values_Throws_When_Null_Rule_Is_Given()
        {
            var exception = Record.Exception(() => {
                ((IValitRule<Model, float>)null)
                    .IsGreaterThan(1);
            });

            exception.ShouldBeOfType(typeof(ValitException));
        }

        [Fact]
        public void Float_IsGreaterThan_For_Not_Nullable_Value_And_Nullable_Value_Throws_When_Null_Rule_Is_Given()
        {
            var exception = Record.Exception(() => {
                ((IValitRule<Model, float>)null)
                    .IsGreaterThan((float?)1);
            });

            exception.ShouldBeOfType(typeof(ValitException));
        }

        [Fact]
        public void Float_IsGreaterThan_For_Nullable_Value_And_Not_Nullable_Value_Throws_When_Null_Rule_Is_Given()
        {
            var exception = Record.Exception(() => {
                ((IValitRule<Model, float?>)null)
                    .IsGreaterThan(1);
            });

            exception.ShouldBeOfType(typeof(ValitException));
        }

        [Fact]
        public void Float_IsGreaterThan_For_Nullable_Values_Throws_When_Null_Rule_Is_Given()
        {
            var exception = Record.Exception(() => {
                ((IValitRule<Model, float?>)null)
                    .IsGreaterThan((float?)1);
            });

            exception.ShouldBeOfType(typeof(ValitException));
        }

        [Theory]
        [InlineData(9, false)]
        [InlineData(Single.NaN, false)]
        public void Float_IsGreaterThan_Returns_Proper_Results_For_NaN_And_Value(float value, bool expected)
        {
            IValitResult result = ValitRules<Model>
                .Create()
                .Ensure(m => m.NaN, _ => _
                    .IsGreaterThan(value))
                .For(_model)
                .Validate();

            result.Succeeded.ShouldBe(expected);
        }

        [Theory]
        [InlineData(9, false)]
        [InlineData(Single.NaN, false)]
        public void Float_IsGreaterThan_Returns_Proper_Results_For_NaN_And_NullableValue(float? value, bool expected)
        {
            IValitResult result = ValitRules<Model>
                .Create()
                .Ensure(m => m.NaN, _ => _
                    .IsGreaterThan(value))
                .For(_model)
                .Validate();

            result.Succeeded.ShouldBe(expected);
        }

        [Theory]
        [InlineData(9, false)]
        [InlineData(Single.NaN, false)]
        public void Float_IsGreaterThan_Returns_Proper_Results_For_NullableNaN_And_Value(float value, bool expected)
        {
            IValitResult result = ValitRules<Model>
                .Create()
                .Ensure(m => m.NullableNaN, _ => _
                    .IsGreaterThan(value))
                .For(_model)
                .Validate();

            result.Succeeded.ShouldBe(expected);
        }

        [Theory]
        [InlineData(9, false)]
        [InlineData(Single.NaN, false)]
        public void Float_IsGreaterThan_Returns_Proper_Results_For_NullableNaN_And_NullableValue(float? value, bool expected)
        {
            IValitResult result = ValitRules<Model>
                .Create()
                .Ensure(m => m.NullableNaN, _ => _
                    .IsGreaterThan(value))
                .For(_model)
                .Validate();

            result.Succeeded.ShouldBe(expected);
        }

        [Theory]
        [InlineData(9, true)]
        [InlineData(10, false)]
        [InlineData(11, false)]
        [InlineData(Single.NaN, false)]
        public void Float_IsGreaterThan_Returns_Proper_Results_For_Not_Nullable_Values(float value, bool expected)
        {
            IValitResult result = ValitRules<Model>
                .Create()
                .Ensure(m => m.Value, _ => _
                    .IsGreaterThan(value))
                .For(_model)
                .Validate();

            result.Succeeded.ShouldBe(expected);
        }

        [Theory]
        [InlineData((float)9, true)]
        [InlineData((float)10, false)]
        [InlineData((float)11, false)]
        [InlineData(Single.NaN, false)]
        [InlineData(null, false)]
        public void Float_IsGreaterThan_Returns_Proper_Results_For_Not_Nullable_Value_And_Nullable_Value(float? value, bool expected)
        {
            IValitResult result = ValitRules<Model>
                .Create()
                .Ensure(m => m.Value, _ => _
                    .IsGreaterThan(value))
                .For(_model)
                .Validate();

            result.Succeeded.ShouldBe(expected);
        }

        [Theory]
        [InlineData(false, 9, true)]
        [InlineData(false, 10, false)]
        [InlineData(false, 11, false)]
        [InlineData(true, 10, false)]
        [InlineData(false, Single.NaN, false)]
        [InlineData(true, Single.NaN, false)]
        public void Float_IsGreaterThan_Returns_Proper_Results_For_Nullable_Value_And_Not_Nullable_Value(bool useNullValue, float value, bool expected)
        {
            IValitResult result = ValitRules<Model>
                .Create()
                .Ensure(m => useNullValue ? m.NullValue : m.NullableValue, _ => _
                    .IsGreaterThan(value))
                .For(_model)
                .Validate();

            result.Succeeded.ShouldBe(expected);
        }

        [Theory]
        [InlineData(false, (float)9, true)]
        [InlineData(false, (float)10, false)]
        [InlineData(false, (float)11, false)]
        [InlineData(false, Single.NaN, false)]
        [InlineData(false, null, false)]
        [InlineData(true, (float)10, false)]
        [InlineData(true, Single.NaN, false)]
        [InlineData(true, null, false)]
        public void Float_IsGreaterThan_Returns_Proper_Results_For_Nullable_Values(bool useNullValue, float? value, bool expected)
        {
            IValitResult result = ValitRules<Model>
                .Create()
                .Ensure(m => useNullValue ? m.NullValue : m.NullableValue, _ => _
                    .IsGreaterThan(value))
                .For(_model)
                .Validate();

            result.Succeeded.ShouldBe(expected);
        }

        [Theory]
        [InlineData(9.999f, 0.000001f, true)]
        [InlineData(9.999f, 0.01f, false)]
        [InlineData(10f, float.Epsilon, false)]
        [InlineData(10.0001f, 0.01f, false)]
        [InlineData(10.0001f, 0.000001f, false)]
        public void Float_IsGreaterThan_Returns_Proper_Results_For_Given_Epsilon_Value(float b, float epsilon, bool expected)
        {
            IValitResult result = ValitRules<Model>
                                    .Create()
                                    .Ensure(m => m.Value, _ => _.IsGreaterThan(b, epsilon))
                                    .For(_model)
                                    .Validate();

            result.Succeeded.ShouldBe(expected);
        }

        #region ARRANGE
        public Float_IsGreaterThan_Tests()
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
