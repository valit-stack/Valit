using Shouldly;
using System;
using Xunit;

namespace Valit.Tests.Float
{
    public class Float_IsNaN_Tests
    {
        [Fact]
        public void Float_IsNaN_For_Not_Nullable_Value_Throws_When_Null_Rule_Is_Given()
        {
            var exception = Record.Exception(() => {
                ((IValitRule<Model, float>)null)
                    .IsNaN();
            });

            exception.ShouldBeOfType(typeof(ValitException));
        }

        [Fact]
        public void Float_IsNaN_For_Nullable_Value_Throws_When_Null_Rule_Is_Given()
        {
            var exception = Record.Exception(() => {
                ((IValitRule<Model, float?>)null)
                    .IsNaN();
            });

            exception.ShouldBeOfType(typeof(ValitException));
        }


        [Fact]
        public void Float_IsNaN_Fails_When_Value_Is_Given()
        {
            IValitResult result = ValitRules<Model>
                .Create()
                .Ensure(m => m.Value, _ => _
                    .IsNaN())
                .For(_model)
                .Validate();

            Assert.Equal(result.Succeeded, false);
        }

        [Fact]
        public void Float_IsNaN_Succeeds_When_NaN_Is_Given()
        {
            IValitResult result = ValitRules<Model>
                .Create()
                .Ensure(m => m.NaN, _ => _
                    .IsNaN())
                .For(_model)
                .Validate();

            Assert.Equal(result.Succeeded, true);
        }

        [Fact]
        public void Float_IsNaN_False_When_NullableValue_Is_Given()
        {
            IValitResult result = ValitRules<Model>
                .Create()
                .Ensure(m => m.NullableValue, _ => _
                    .IsNaN())
                .For(_model)
                .Validate();

            Assert.Equal(result.Succeeded, false);
        }

        [Fact]
        public void Float_IsNaN_Fails_When_Null_Is_Given()
        {
            IValitResult result = ValitRules<Model>
                .Create()
                .Ensure(m => m.NullValue, _ => _
                    .IsNaN())
                .For(_model)
                .Validate();

            Assert.Equal(result.Succeeded, false);
        }

        [Fact]
        public void Float_IsNaN_Fails_When_NullableNaN_Is_Given()
        {
            IValitResult result = ValitRules<Model>
                .Create()
                .Ensure(m => m.NullableNaN, _ => _
                    .IsNaN())
                .For(_model)
                .Validate();

            Assert.Equal(result.Succeeded, true);
        }

        #region ARRANGE
        public Float_IsNaN_Tests()
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
