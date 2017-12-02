using Shouldly;
using System;
using Xunit;

namespace Valit.Tests.Double
{
    public class Double_IsNumber_Tests
    {
        [Fact]
        public void Double_IsNumber_For_Not_Nullable_Value_Throws_When_Null_Rule_Is_Given()
        {
            var exception = Record.Exception(() => {
                ((IValitRule<Model, double>)null)
                    .IsNumber();
            });

            exception.ShouldBeOfType(typeof(ValitException));
        }

        [Fact]
        public void Double_IsNumber_For_Nullable_Value_Throws_When_Null_Rule_Is_Given()
        {
            var exception = Record.Exception(() => {
                ((IValitRule<Model, double?>)null)
                    .IsNumber();
            });

            exception.ShouldBeOfType(typeof(ValitException));
        }


        [Fact]
        public void Double_IsNumber_Succeeds_When_Value_Is_Given()
        {
            IValitResult result = ValitRules<Model>
                .Create()
                .Ensure(m => m.Value, _ => _
                    .IsNumber())
                .For(_model)
                .Validate();

            Assert.Equal(result.Succeeded, true);
        }

        [Fact]
        public void Double_IsNumber_Fails_When_NaN_Is_Given()
        {
            IValitResult result = ValitRules<Model>
                .Create()
                .Ensure(m => m.NaN, _ => _
                    .IsNumber())
                .For(_model)
                .Validate();

            Assert.Equal(result.Succeeded, false);
        }

        [Fact]
        public void Double_IsNumber_Succeeds_When_NullableValue_Is_Given()
        {
            IValitResult result = ValitRules<Model>
                .Create()
                .Ensure(m => m.NullableValue, _ => _
                    .IsNumber())
                .For(_model)
                .Validate();

            Assert.Equal(result.Succeeded, true);
        }

        [Fact]
        public void Double_IsNumber_Fails_When_Null_Is_Given()
        {
            IValitResult result = ValitRules<Model>
                .Create()
                .Ensure(m => m.NullValue, _ => _
                    .IsNumber())
                .For(_model)
                .Validate();

            Assert.Equal(result.Succeeded, false);
        }

        [Fact]
        public void Double_IsNumber_Fails_When_NullableNaN_Is_Given()
        {
            IValitResult result = ValitRules<Model>
                .Create()
                .Ensure(m => m.NullableNaN, _ => _
                    .IsNumber())
                .For(_model)
                .Validate();

            Assert.Equal(result.Succeeded, false);
        }

        #region ARRANGE
        public Double_IsNumber_Tests()
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
