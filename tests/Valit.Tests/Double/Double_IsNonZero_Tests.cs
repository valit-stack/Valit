using Shouldly;
using System;
using Xunit;

namespace Valit.Tests.Double
{
    public class Double_IsNonZero_Tests
    {
        [Fact]
        public void Double_IsNonZero_For_Not_Nullable_Value_Throws_When_Null_Rule_Is_Given()
        {
            var exception = Record.Exception(() => {
                ((IValitRule<Model, double>)null)
                    .IsNonZero();
            });

            exception.ShouldBeOfType(typeof(ValitException));
        }

        [Fact]
        public void Double_IsNonZero_For_Nullable_Value_Throws_When_Null_Rule_Is_Given()
        {
            var exception = Record.Exception(() => {
                ((IValitRule<Model, double?>)null)
                    .IsNonZero();
            });

            exception.ShouldBeOfType(typeof(ValitException));
        }

        public void Double_IsNonZero_Returns_Proper_Results_For_Not_Nullable_Value(bool useZeroValue, bool expected)
        {
            IValitResult result = ValitRules<Model>
                .Create()
                .Ensure(m => useZeroValue ? m.ZeroValue : m.Value, _ => _
                    .IsNonZero())
                .For(_model)
                .Validate();

            Assert.Equal(result.Succeeded, expected);
        }

        [Fact]
        public void Double_IsNonZero_Fails_For_NaN()
        {
            IValitResult result = ValitRules<Model>
                .Create()
                .Ensure(m => m.NaN, _ => _
                    .IsNonZero())
                .For(_model)
                .Validate();

            Assert.Equal(result.Succeeded, false);
        }

        [Fact]
        public void Double_IsNonZero_Fails_For_NullableNaN()
        {
            IValitResult result = ValitRules<Model>
                .Create()
                .Ensure(m => m.NullableNaN, _ => _
                    .IsNonZero())
                .For(_model)
                .Validate();

            Assert.Equal(result.Succeeded, false);
        }

        [Theory]
        [InlineData(false, true)]
        [InlineData(true, false)]
        public void Double_IsNonZero_Returns_Proper_Results_For_Nullable_Value(bool useZeroValue,  bool expected)
        {
            IValitResult result = ValitRules<Model>
                .Create()
                .Ensure(m => useZeroValue? m.NullableZeroValue : m.NullableValue, _=>_
                    .IsNonZero())
                .For(_model)
                .Validate();

            Assert.Equal(result.Succeeded, expected);
        }

        [Fact]
        public void Double_IsNonZero_Fails_For_Null_Value()
        {
            IValitResult result = ValitRules<Model>
                .Create()
                .Ensure(m => m.NullValue, _=>_
                    .IsNonZero())
                .For(_model)
                .Validate();

            Assert.Equal(result.Succeeded, false);
        }

#region ARRANGE
        public Double_IsNonZero_Tests()
        {
            _model = new Model();
        }

        private readonly Model _model;

        class Model
        {
            public double Value => 10;
            public double ZeroValue => 0;
            public double NaN => double.NaN;
            public double? NullableValue => 10;
            public double? NullableZeroValue => 0;
            public double? NullValue => null;
            public double? NullableNaN => double.NaN;
        }
        #endregion
    }
}
