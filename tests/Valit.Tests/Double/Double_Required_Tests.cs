using Shouldly;
using System;
using Xunit;

namespace Valit.Tests.Double
{
    public class Double_Required_Tests
    {

        [Fact]
        public void Double_Required_For_Nullable_Value_Throws_When_Null_Rule_Is_Given()
        {
            var exception = Record.Exception(() =>
            {
                ((IValitRule<Model, double?>)null)
                    .Required();
            });

            exception.ShouldBeOfType(typeof(ValitException));
        }

        [Fact]
        public void Double_Required_Succeeds_For_NullableValue()
        {
            IValitResult result = ValitRules<Model>
                .Create()
                .Ensure(m => m.NullableValue, _ => _
                    .Required())
                .For(_model)
                .Validate();

            result.Succeeded.ShouldBeTrue();
        }

        [Fact]
        public void Double_Required_Fails_For_NullValue()
        {
            IValitResult result = ValitRules<Model>
                .Create()
                .Ensure(m => m.NullValue, _ => _
                    .Required())
                .For(_model)
                .Validate();

            result.Succeeded.ShouldBeFalse();
        }

        [Fact]
        public void Double_Required_Succeeds_For_NullableNaN()
        {
            IValitResult result = ValitRules<Model>
                .Create()
                .Ensure(m => m.NullableNaN, _ => _
                    .Required())
                .For(_model)
                .Validate();

            result.Succeeded.ShouldBeTrue();
        }

        #region ARRANGE
        public Double_Required_Tests()
        {
            _model = new Model();
        }

        private readonly Model _model;

        class Model
        {
            public double? NullableValue => 10;
            public double? NullValue => null;
            public double? NullableNaN => double.NaN;
        }
        #endregion
    }
}
