using Shouldly;
using System;
using Xunit;

namespace Valit.Tests.Double
{
    public class Double_IsNaN_Tests
    {
        [Fact]
        public void Double_IsNaN_For_Not_Nullable_Value_Throws_When_Null_Rule_Is_Given()
        {
            var exception = Record.Exception(() =>
            {
                ((IValitRule<Model, double>)null)
                    .IsNaN();
            });

            exception.ShouldBeOfType(typeof(ValitException));
        }

        [Fact]
        public void Double_IsNaN_For_Nullable_Value_Throws_When_Null_Rule_Is_Given()
        {
            var exception = Record.Exception(() =>
            {
                ((IValitRule<Model, double?>)null)
                    .IsNaN();
            });

            exception.ShouldBeOfType(typeof(ValitException));
        }


        [Fact]
        public void Double_IsNaN_Fails_When_Value_Is_Given()
        {
            IValitResult result = ValitRules<Model>
                .Create()
                .Ensure(m => m.Value, _ => _
                    .IsNaN())
                .For(_model)
                .Validate();

            result.Succeeded.ShouldBeFalse();
        }

        [Fact]
        public void Double_IsNaN_Succeeds_When_NaN_Is_Given()
        {
            IValitResult result = ValitRules<Model>
                .Create()
                .Ensure(m => m.NaN, _ => _
                    .IsNaN())
                .For(_model)
                .Validate();

            result.Succeeded.ShouldBeTrue();
        }

        [Fact]
        public void Double_IsNaN_False_When_NullableValue_Is_Given()
        {
            IValitResult result = ValitRules<Model>
                .Create()
                .Ensure(m => m.NullableValue, _ => _
                    .IsNaN())
                .For(_model)
                .Validate();

            result.Succeeded.ShouldBeFalse();
        }

        [Fact]
        public void Double_IsNaN_Fails_When_Null_Is_Given()
        {
            IValitResult result = ValitRules<Model>
                .Create()
                .Ensure(m => m.NullValue, _ => _
                    .IsNaN())
                .For(_model)
                .Validate();

            result.Succeeded.ShouldBeFalse();
        }

        [Fact]
        public void Double_IsNaN_Fails_When_NullableNaN_Is_Given()
        {
            IValitResult result = ValitRules<Model>
                .Create()
                .Ensure(m => m.NullableNaN, _ => _
                    .IsNaN())
                .For(_model)
                .Validate();

            result.Succeeded.ShouldBeTrue();
        }

        #region ARRANGE
        public Double_IsNaN_Tests()
        {
            _model = new Model();
        }

        private readonly Model _model;

        class Model
        {
            public double Value => 0;
            public double NaN => double.NaN;
            public double? NullableValue => 0;
            public double? NullValue => null;
            public double? NullableNaN => double.NaN;
        }
        #endregion
    }
}
