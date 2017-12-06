using Shouldly;
using System;
using Xunit;

namespace Valit.Tests.Double
{
    public class Double_IsPositive_Tests
    {
        [Fact]
        public void Double_IsPositive_For_Not_Nullable_Value_Throws_When_Null_Rule_Is_Given()
        {
            var exception = Record.Exception(() =>
            {
                ((IValitRule<Model, double>)null)
                    .IsPositive();
            });

            exception.ShouldBeOfType(typeof(ValitException));
        }

        [Fact]
        public void Double_IsPositive_For_Nullable_Value_Throws_When_Null_Rule_Is_Given()
        {
            var exception = Record.Exception(() =>
            {
                ((IValitRule<Model, double?>)null)
                    .IsPositive();
            });

            exception.ShouldBeOfType(typeof(ValitException));
        }


        [Fact]
        public void Double_IsPositive_Succeeds_When_Given_Value_Is_Postive()
        {
            IValitResult result = ValitRules<Model>
                .Create()
                .Ensure(m => m.PositiveValue, _ => _
                    .IsPositive())
                .For(_model)
                .Validate();

            result.Succeeded.ShouldBeTrue();
        }

        [Fact]
        public void Double_IsPositive_Fails_When_Given_Value_Is_Zero()
        {
            IValitResult result = ValitRules<Model>
                .Create()
                .Ensure(m => m.ZeroValue, _ => _
                    .IsPositive())
                .For(_model)
                .Validate();

            result.Succeeded.ShouldBeFalse();
        }

        [Fact]
        public void Double_IsPositive_Fails_When_Given_Value_Is_Negative()
        {
            IValitResult result = ValitRules<Model>
                .Create()
                .Ensure(m => m.NegativeValue, _ => _
                    .IsPositive())
                .For(_model)
                .Validate();

            result.Succeeded.ShouldBeFalse();
        }

        [Fact]
        public void Double_IsPositive_Fails_When_Given_Value_Is_NaN()
        {
            IValitResult result = ValitRules<Model>
                .Create()
                .Ensure(m => m.NaN, _ => _
                    .IsPositive())
                .For(_model)
                .Validate();

            result.Succeeded.ShouldBeFalse();
        }

        [Fact]
        public void Double_IsPositive_Succeeds_When_Given_Value_Is_NullablePostive()
        {
            IValitResult result = ValitRules<Model>
                .Create()
                .Ensure(m => m.NullablePositiveValue, _ => _
                    .IsPositive())
                .For(_model)
                .Validate();

            result.Succeeded.ShouldBeTrue();
        }

        [Fact]
        public void Double_IsPositive_Fails_When_Given_Value_Is_NullableZero()
        {
            IValitResult result = ValitRules<Model>
                .Create()
                .Ensure(m => m.NullableZeroValue, _ => _
                    .IsPositive())
                .For(_model)
                .Validate();

            result.Succeeded.ShouldBeFalse();
        }

        [Fact]
        public void Double_IsPositive_Fails_When_Given_Value_Is_NullableNegative()
        {
            IValitResult result = ValitRules<Model>
                .Create()
                .Ensure(m => m.NullableNegativeValue, _ => _
                    .IsPositive())
                .For(_model)
                .Validate();

            result.Succeeded.ShouldBeFalse();
        }

        [Fact]
        public void Double_IsPositive_Fails_When_Given_Value_Is_Null()
        {
            IValitResult result = ValitRules<Model>
                .Create()
                .Ensure(m => m.NullValue, _ => _
                    .IsPositive())
                .For(_model)
                .Validate();

            result.Succeeded.ShouldBeFalse();
        }

        [Fact]
        public void Double_IsPositive_Fails_When_Given_Value_Is_NullableNaN()
        {
            IValitResult result = ValitRules<Model>
                .Create()
                .Ensure(m => m.NullableNaN, _ => _
                    .IsPositive())
                .For(_model)
                .Validate();

            result.Succeeded.ShouldBeFalse();
        }

        #region ARRANGE
        public Double_IsPositive_Tests()
        {
            _model = new Model();
        }

        private readonly Model _model;

        class Model
        {
            public double PositiveValue => 10;
            public double ZeroValue => 0;
            public double NegativeValue => -10;
            public double NaN => double.NaN;
            public double? NullablePositiveValue => 10;
            public double? NullableZeroValue => 0;
            public double? NullableNegativeValue => -10;
            public double? NullValue => null;
            public double? NullableNaN => double.NaN;
        }
        #endregion
    }
}
