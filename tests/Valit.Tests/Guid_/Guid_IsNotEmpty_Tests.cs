using System;
using Shouldly;
using Xunit;

namespace Valit.Tests.Guid_
{
    public class Guid_IsNotEmpty_Tests
    {
        [Fact]
        public void Guid_IsNotEmpty_For_Not_Nullable_Values_Throws_When_Null_Rule_Is_Given()
        {
            var exception = Record.Exception(() => {
                ((IValitRule<Model, Guid>)null)
                    .IsNotEmpty();
            });

            exception.ShouldBeOfType(typeof(ValitException));
        }

        [Fact]
        public void Guid_IsNotEmpty_For_Nullable_Value_And_Not_Nullable_Value_Throws_When_Null_Rule_Is_Given()
        {
            var exception = Record.Exception(() => {
                ((IValitRule<Model, Guid?>)null)
                    .IsNotEmpty();
            });

            exception.ShouldBeOfType(typeof(ValitException));
        }

        [Fact]
        public void Guid_IsNotEmpty_Succeeds_For_Value()
        {
            var result = ValitRules<Model>
                .Create()
                .Ensure(m => m.Value, _ => _
                    .IsNotEmpty())
                .For(_model)
                .Validate();

            result.Succeeded.ShouldBe(true);
        }

        [Fact]
        public void Guid_IsNotEmpty_Fails_For_Empty_Value()
        {
            var result = ValitRules<Model>
                .Create()
                .Ensure(m => m.Empty, _ => _
                    .IsNotEmpty())
                .For(_model)
                .Validate();

            result.Succeeded.ShouldBe(false);
        }

        [Fact]
        public void Guid_IsNotEmpty_Succeeds_For_Nullable_Value()
        {
            var result = ValitRules<Model>
                .Create()
                .Ensure(m => m.Value, _ => _
                    .IsNotEmpty())
                .For(_model)
                .Validate();

            result.Succeeded.ShouldBe(true);
        }

        [Fact]
        public void Guid_IsNotEmpty_Fails_For_Nullable_Empty_Value()
        {
            var result = ValitRules<Model>
                .Create()
                .Ensure(m => m.NullableEmpty, _ => _
                    .IsNotEmpty())
                .For(_model)
                .Validate();

            result.Succeeded.ShouldBe(false);
        }

        [Fact]
        public void Guid_IsNotEmpty_Fails_For_Nullable_Null()
        {
            var result = ValitRules<Model>
                .Create()
                .Ensure(m => m.NullValue, _ => _
                    .IsNotEmpty())
                .For(_model)
                .Validate();

            result.Succeeded.ShouldBe(false);
        }

#region ARRANGE
        public Guid_IsNotEmpty_Tests()
        {
            _model = new Model();
        }

        private readonly Model _model;

        class Model
        {
            public Guid Value => System.Guid.Parse("6f72f4ab-c2fc-4fca-b70e-b5ac7eccd054");
            public Guid Empty => Guid.Empty;
            public Guid? NullableValue => System.Guid.Parse("6f72f4ab-c2fc-4fca-b70e-b5ac7eccd054");
            public Guid? NullableEmpty => Guid.Empty;
            public Guid? NullValue => null;
        }
#endregion
    }
}
