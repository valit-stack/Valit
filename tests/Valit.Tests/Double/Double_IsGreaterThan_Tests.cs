using Shouldly;
using System;
using Xunit;

namespace Valit.Tests.Double
{
    public class Double_IsGreaterThan_Tests
    {
        [Fact]
        public void Double_IsGreaterThan_For_Not_Nullable_Values_Throws_When_Null_Rule_Is_Given()
        {
            var exception = Record.Exception(() => {
                ((IValitRule<Model, double>)null)
                    .IsGreaterThan(1);
            });

            exception.ShouldBeOfType(typeof(ValitException));
        }

        [Fact]
        public void Double_IsGreaterThan_For_Not_Nullable_Value_And_Nullable_Value_Throws_When_Null_Rule_Is_Given()
        {
            var exception = Record.Exception(() => {
                ((IValitRule<Model, double>)null)
                    .IsGreaterThan((double?)1);
            });

            exception.ShouldBeOfType(typeof(ValitException));
        }

        [Fact]
        public void Double_IsGreaterThan_For_Nullable_Value_And_Not_Nullable_Value_Throws_When_Null_Rule_Is_Given()
        {
            var exception = Record.Exception(() => {
                ((IValitRule<Model, double?>)null)
                    .IsGreaterThan(1);
            });

            exception.ShouldBeOfType(typeof(ValitException));
        }

        [Fact]
        public void Double_IsGreaterThan_For_Nullable_Values_Throws_When_Null_Rule_Is_Given()
        {
            var exception = Record.Exception(() => {
                ((IValitRule<Model, double?>)null)
                    .IsGreaterThan((double?)1);
            });

            exception.ShouldBeOfType(typeof(ValitException));
        }

        [Theory]
        [InlineData(9, false)]
        [InlineData(double.NaN, false)]
        public void Double_IsGreaterThan_Returns_Proper_Results_For_NaN_And_Value(double value, bool expected)
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
        [InlineData(double.NaN, false)]
        public void Double_IsGreaterThan_Returns_Proper_Results_For_NaN_And_NullableValue(double? value, bool expected)
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
        [InlineData(double.NaN, false)]
        public void Double_IsGreaterThan_Returns_Proper_Results_For_NullableNaN_And_Value(double value, bool expected)
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
        [InlineData(double.NaN, false)]
        public void Double_IsGreaterThan_Returns_Proper_Results_For_NullableNaN_And_NullableValue(double? value, bool expected)
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
        [InlineData(double.NaN, false)]
        public void Double_IsGreaterThan_Returns_Proper_Results_For_Not_Nullable_Values(double value, bool expected)
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
        [InlineData((double)9, true)]
        [InlineData((double)10, false)]
        [InlineData((double)11, false)]
        [InlineData(double.NaN, false)]
        [InlineData(null, false)]
        public void Double_IsGreaterThan_Returns_Proper_Results_For_Not_Nullable_Value_And_Nullable_Value(double? value, bool expected)
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
        [InlineData(false, double.NaN, false)]
        [InlineData(true, double.NaN, false)]
        public void Double_IsGreaterThan_Returns_Proper_Results_For_Nullable_Value_And_Not_Nullable_Value(bool useNullValue, double value, bool expected)
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
        [InlineData(false, (double)9, true)]
        [InlineData(false, (double)10, false)]
        [InlineData(false, (double)11, false)]
        [InlineData(false, double.NaN, false)]
        [InlineData(false, null, false)]
        [InlineData(true, (double)10, false)]
        [InlineData(true, double.NaN, false)]
        [InlineData(true, null, false)]
        public void Double_IsGreaterThan_Returns_Proper_Results_For_Nullable_Values(bool useNullValue, double? value, bool expected)
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
        [InlineData(9.999d, 0.000001d, true)]
        [InlineData(9.999d, 0.01d, false)]
        [InlineData(10d, double.Epsilon, false)]
        [InlineData(10.0001d, 0.01d, false)]
        [InlineData(10.0001d, 0.000001d, false)]
        public void Double_IsGreaterThan_Returns_Proper_Results_For_GivenEpsilon_Value(double b, double epsilon, bool expected)
        {
            IValitResult result = ValitRules<Model>
                                    .Create()
                                    .Ensure(m => m.Value, _ => _.IsGreaterThan(b, epsilon))
                                    .For(_model)
                                    .Validate();

            result.Succeeded.ShouldBe(expected);
        }

        #region ARRANGE
        public Double_IsGreaterThan_Tests()
        {
            _model = new Model();
        }

        private readonly Model _model;

        class Model
        {
            public double Value => 10;
            public double Epsilon => double.Epsilon;
            public double NaN => double.NaN;
            public double? NullableValue => 10;
            public double? NullValue => null;
            public double? NullableNaN => double.NaN;
        }
        #endregion
    }
}
