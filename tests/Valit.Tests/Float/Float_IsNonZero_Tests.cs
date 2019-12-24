using Shouldly;
using System;
using Xunit;

namespace Valit.Tests.Float
{
    public class Float_IsNonZero_Tests
    {
        [Fact]
        public void Float_IsNonZero_For_Not_Nullable_Value_Throws_When_Null_Rule_Is_Given()
        {
            var exception = Record.Exception(() =>
            {
                ((IValitRule<Model, float>)null)
                    .IsNonZero();
            });

            exception.ShouldBeOfType(typeof(ValitException));
        }

        [Fact]
        public void Float_IsNonZero_For_Nullable_Value_Throws_When_Null_Rule_Is_Given()
        {
            var exception = Record.Exception(() =>
            {
                ((IValitRule<Model, float?>)null)
                    .IsNonZero();
            });

            exception.ShouldBeOfType(typeof(ValitException));
        }

        public void Float_IsNonZero_Returns_Proper_Results_For_Not_Nullable_Value(bool useZeroValue, bool expected)
        {
            IValitResult result = ValitRules<Model>
                .Create()
                .Ensure(m => useZeroValue ? m.ZeroValue : m.Value, _ => _
                    .IsNonZero())
                .For(_model)
                .Validate();

            result.Succeeded.ShouldBe(expected);
        }

        [Fact]
        public void Float_IsNonZero_Fails_For_NaN()
        {
            IValitResult result = ValitRules<Model>
                .Create()
                .Ensure(m => m.NaN, _ => _
                    .IsNonZero())
                .For(_model)
                .Validate();

            result.Succeeded.ShouldBeFalse();
        }

        [Fact]
        public void Float_IsNonZero_Fails_For_NullableNaN()
        {
            IValitResult result = ValitRules<Model>
                .Create()
                .Ensure(m => m.NullableNaN, _ => _
                    .IsNonZero())
                .For(_model)
                .Validate();

            result.Succeeded.ShouldBeFalse();
        }

        [Theory]
        [InlineData(false, true)]
        [InlineData(true, false)]
        public void Float_IsNonZero_Returns_Proper_Results_For_Nullable_Value(bool useZeroValue, bool expected)
        {
            IValitResult result = ValitRules<Model>
                .Create()
                .Ensure(m => useZeroValue ? m.NullableZeroValue : m.NullableValue, _ => _
                    .IsNonZero())
                .For(_model)
                .Validate();

            result.Succeeded.ShouldBe(expected);
        }

        [Fact]
        public void Float_IsNonZero_Fails_For_Null_Value()
        {
            IValitResult result = ValitRules<Model>
                .Create()
                .Ensure(m => m.NullValue, _ => _
                    .IsNonZero())
                .For(_model)
                .Validate();

            result.Succeeded.ShouldBeFalse();
        }

        [Theory]
        [InlineData(0f, float.Epsilon, false)]
        [InlineData(0.000001f, 0.001f, true)]
        [InlineData(0.000001f, 0f, true)]
        public void Float_IsNonZero_Return_Proper_Results_For_Given_Epsilon_Value(float value, float epsilon, bool expected)
        {
            IValitResult result = ValitRules<Model>
                                    .Create()
                                    .Ensure(m => value, _ => _.IsNonZero(epsilon))
                                    .For(_model)
                                    .Validate();

            result.Succeeded.ShouldBe(expected);
        }

        #region ARRANGE
        public Float_IsNonZero_Tests()
        {
            _model = new Model();
        }

        private readonly Model _model;

        class Model
        {
            public float Value => 10;
            public float ZeroValue => 0;
            public float NaN => Single.NaN;
            public float? NullableValue => 10;
            public float? NullableZeroValue => 0;
            public float? NullValue => null;
            public float? NullableNaN => Single.NaN;
        }
        #endregion
    }
}
