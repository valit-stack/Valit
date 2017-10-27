using Shouldly;
using System;
using Xunit;

namespace Valit.Tests.Float
{
    public class Float_IsNumber_Tests
    {
        [Fact]
        public void Float_IsNumber_For_Not_Nullable_Value_Throws_When_Null_Rule_Is_Given()
        {
            var exception = Record.Exception(() => {
                ((IValitRule<Model, float>)null)
                    .IsNumber();
            });

            exception.ShouldBeOfType(typeof(ValitException));
        }

        [Fact]
        public void Float_IsNumber_For_Nullable_Value_Throws_When_Null_Rule_Is_Given()
        {
            var exception = Record.Exception(() => {
                ((IValitRule<Model, float?>)null)
                    .IsNumber();
            });

            exception.ShouldBeOfType(typeof(ValitException));
        }


        [Fact]
        public void Float_IsNumber_Succeeds_When_Value_Is_Given()
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
        public void Float_IsNumber_Fails_When_NaN_Is_Given()
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
        public void Float_IsNumber_Succeeds_When_NullableValue_Is_Given()
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
        public void Float_IsNumber_Fails_When_Null_Is_Given()
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
        public void Float_IsNumber_Fails_When_NullableNaN_Is_Given()
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
        public Float_IsNumber_Tests()
        {
            _model = new Model();
        }

        private readonly Model _model;

        class Model
        {
            public float Value => 0;
            public float NaN => Single.NaN;
            public float? NullableValue => 0;
            public float? NullValue => null;
            public float? NullableNaN => Single.NaN;
        }
#endregion
    }
}
