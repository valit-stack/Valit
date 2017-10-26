using Shouldly;
using System;
using Xunit;

namespace Valit.Tests.Float
{
    public class Float_Required_Tests
    {

        [Fact]
        public void Float_Required_For_Nullable_Value_Throws_When_Null_Rule_Is_Given()
        {
            var exception = Record.Exception(() => {
                ((IValitRule<Model, float?>)null)
                    .Required();
            });
            
            exception.ShouldBeOfType(typeof(ValitException));
        }

        [Fact]
        public void Float_Required_Succeeds_For_NullableValue()
        {
            IValitResult result = ValitRules<Model>
                .Create()
                .Ensure(m => m.NullableValue, _ => _
                    .Required())
                .For(_model)
                .Validate();

            Assert.Equal(result.Succeeded, true);
        }

        [Fact]
        public void Float_Required_Fails_For_NullValue()
        {
            IValitResult result = ValitRules<Model>
                .Create()
                .Ensure(m => m.NullValue, _ => _
                    .Required())
                .For(_model)
                .Validate();

            Assert.Equal(result.Succeeded, false);
        }

        [Fact]
        public void Float_Required_Succeeds_For_NullableNaN()
        {
            IValitResult result = ValitRules<Model>
                .Create()
                .Ensure(m => m.NullableNaN, _ => _
                    .Required())
                .For(_model)
                .Validate();

            Assert.Equal(result.Succeeded, true);
        }

        #region ARRANGE
        public Float_Required_Tests()
        {
            _model = new Model();
        }

        private readonly Model _model;

        class Model
        {
            public float? NullableValue => 10;
            public float? NullValue => null;
            public float? NullableNaN => Single.NaN;
        }
#endregion
    }
}