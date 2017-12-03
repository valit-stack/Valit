using System;
using Shouldly;
using Xunit;

namespace Valit.Tests.Guid_
{
    public class Guid_Required_Tests
    {
        [Fact]
        public void Guid_Required_Throws_When_Null_Rule_Is_Given()
        {
            var exception = Record.Exception(() => {
                ((IValitRule<Model, Guid?>)null)
                    .Required();
            });

            exception.ShouldBeOfType(typeof(ValitException));
        }

        [Fact]
        public void Guid_Required_Succeeds_For_Nullable_Value()
        {
            var result = ValitRules<Model>
                .Create()
                .Ensure(m => m.NullableValue, _ => _
                    .Required())
                .For(_model)
                .Validate();

            result.Succeeded.ShouldBe(true);
        }

        [Fact]
        public void Guid_Required_Fails_For_Nullable_Null()
        {
            var result = ValitRules<Model>
                .Create()
                .Ensure(m => m.NullValue, _ => _
                    .Required())
                .For(_model)
                .Validate();

            result.Succeeded.ShouldBe(false);
        }

#region ARRANGE
        public Guid_Required_Tests()
        {
            _model = new Model();
        }

        private readonly Model _model;

        class Model
        {
            public Guid? NullableValue => System.Guid.Parse("6f72f4ab-c2fc-4fca-b70e-b5ac7eccd054");
            public Guid? NullValue => null;
        }
#endregion
    }
}
