using Shouldly;
using System;
using Xunit;

namespace Valit.Tests.Float
{
    public class Float_IsNegative_Tests
    {
        [Fact]
        public void Float_IsNegative_For_Not_Nullable_Value_Throws_When_Null_Rule_Is_Given()
        {
            var exception = Record.Exception(() =>
            {
                ((IValitRule<Model, float>)null)
                    .IsNegative();
            });

            exception.ShouldBeOfType(typeof(ValitException));
        }

        [Fact]
        public void Float_IsNegative_For_Nullable_Value_Throws_When_Null_Rule_Is_Given()
        {
            var exception = Record.Exception(() =>
            {
                ((IValitRule<Model, float?>)null)
                    .IsNegative();
            });

            exception.ShouldBeOfType(typeof(ValitException));
        }


        [Fact]
        public void Float_IsNegative_Fails_When_Given_Value_Is_Postive()
        {
            IValitResult result = ValitRules<Model>
                .Create()
                .Ensure(m => m.PositiveValue, _ => _
                    .IsNegative())
                .For(_model)
                .Validate();

            result.Succeeded.ShouldBeFalse();
        }

        [Fact]
        public void Float_IsNegative_Fails_When_Given_Value_Is_Zero()
        {
            IValitResult result = ValitRules<Model>
                .Create()
                .Ensure(m => m.ZeroValue, _ => _
                    .IsNegative())
                .For(_model)
                .Validate();

            result.Succeeded.ShouldBeFalse();
        }

        [Fact]
        public void Float_IsNegative_Succeeds_When_Given_Value_Is_Negative()
        {
            IValitResult result = ValitRules<Model>
                .Create()
                .Ensure(m => m.NegativeValue, _ => _
                    .IsNegative())
                .For(_model)
                .Validate();

            result.Succeeded.ShouldBeTrue();
        }

        [Fact]
        public void Float_IsNegative_Fails_When_Given_Value_Is_NaN()
        {
            IValitResult result = ValitRules<Model>
                .Create()
                .Ensure(m => m.NaN, _ => _
                    .IsNegative())
                .For(_model)
                .Validate();

            result.Succeeded.ShouldBeFalse();
        }

        [Fact]
        public void Float_IsNegative_Fails_When_Given_Value_Is_NullablePostive()
        {
            IValitResult result = ValitRules<Model>
                .Create()
                .Ensure(m => m.NullablePositiveValue, _ => _
                    .IsNegative())
                .For(_model)
                .Validate();

            result.Succeeded.ShouldBeFalse();
        }

        [Fact]
        public void Float_IsNegative_Fails_When_Given_Value_Is_NullableZero()
        {
            IValitResult result = ValitRules<Model>
                .Create()
                .Ensure(m => m.NullableZeroValue, _ => _
                    .IsNegative())
                .For(_model)
                .Validate();

            result.Succeeded.ShouldBeFalse();
        }

        [Fact]
        public void Float_IsNegative_Succeeds_When_Given_Value_Is_NullableNegative()
        {
            IValitResult result = ValitRules<Model>
                .Create()
                .Ensure(m => m.NullableNegativeValue, _ => _
                    .IsNegative())
                .For(_model)
                .Validate();

            result.Succeeded.ShouldBeTrue();
        }

        [Fact]
        public void Float_IsNegative_Fails_When_Given_Value_Is_Null()
        {
            IValitResult result = ValitRules<Model>
                .Create()
                .Ensure(m => m.NullValue, _ => _
                    .IsNegative())
                .For(_model)
                .Validate();

            result.Succeeded.ShouldBeFalse();
        }

        [Fact]
        public void Float_IsNegative_Fails_When_Given_Value_Is_NullableNaN()
        {
            IValitResult result = ValitRules<Model>
                .Create()
                .Ensure(m => m.NullableNaN, _ => _
                    .IsNegative())
                .For(_model)
                .Validate();

            result.Succeeded.ShouldBeFalse();
        }

        [Theory]
        [InlineData(0f, float.Epsilon, false)]
        [InlineData(-0.000001f, 0.001f, true)]
        [InlineData(-0.000001f, 0f, true)]
        public void Float_IsNegative_Return_Proper_Results_For_Given_Epsilon_Value(float value, float epsilon, bool expected)
        {
            IValitResult result = ValitRules<Model>
                                    .Create()
                                    .Ensure(m => value, _ => _.IsNegative(epsilon))
                                    .For(_model)
                                    .Validate();

            result.Succeeded.ShouldBe(expected);
        }

        #region ARRANGE
        public Float_IsNegative_Tests()
        {
            _model = new Model();
        }

        private readonly Model _model;

        class Model
        {
            public float PositiveValue => 10;
            public float ZeroValue => 0;
            public float NegativeValue => -10;
            public float NaN => Single.NaN;
            public float? NullablePositiveValue => 10;
            public float? NullableZeroValue => 0;
            public float? NullableNegativeValue => -10;
            public float? NullValue => null;
            public float? NullableNaN => Single.NaN;
        }
        #endregion
    }
}
