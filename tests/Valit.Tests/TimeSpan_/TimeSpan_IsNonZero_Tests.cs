using System;
using Shouldly;
using Xunit;

namespace Valit.Tests.TimeSpan_
{
    public class TimeSpan_IsNonZero_Tests
    {
        [Fact]
        public void TimeSpan_IsNonZero_For_Not_Nullable_Values_Throws_When_Null_Rule_Is_Given()
        {
            var exception = Record.Exception(() => {
                ((IValitRule<Model, TimeSpan>)null)
                    .IsNonZero();
            });

            exception.ShouldBeOfType(typeof(ValitException));
        }

        [Fact]
        public void TimeSpan_IsNonZero_For_Nullable_Value_And_Not_Nullable_Value_Throws_When_Null_Rule_Is_Given()
        {
            var exception = Record.Exception(() => {
                ((IValitRule<Model, TimeSpan?>)null)
                    .IsNonZero();
            });

            exception.ShouldBeOfType(typeof(ValitException));
        }

        [Fact]
        public void TimeSpan_IsNonZero_Succeeds_For_Value()
        {
            var result = ValitRules<Model>
                .Create()
                .Ensure(m => m.Value, _ => _
                    .IsNonZero())
                .For(_model)
                .Validate();

            result.Succeeded.ShouldBe(true);
        }

        [Fact]
        public void TimeSpan_IsNonZero_Fails_For_Zero_Value()
        {
            var result = ValitRules<Model>
                .Create()
                .Ensure(m => m.Zero, _ => _
                    .IsNonZero())
                .For(_model)
                .Validate();

            result.Succeeded.ShouldBe(false);
        }

        [Fact]
        public void TimeSpan_IsNonZero_Succeeds_For_Nullable_Value()
        {
            var result = ValitRules<Model>
                .Create()
                .Ensure(m => m.Value, _ => _
                    .IsNonZero())
                .For(_model)
                .Validate();

            result.Succeeded.ShouldBe(true);
        }

        [Fact]
        public void TimeSpan_IsNonZero_Fails_For_Nullable_Zero_Value()
        {
            var result = ValitRules<Model>
                .Create()
                .Ensure(m => m.Zero, _ => _
                    .IsNonZero())
                .For(_model)
                .Validate();

            result.Succeeded.ShouldBe(false);
        }

        [Fact]
        public void TimeSpan_IsNonZero_Fails_For_Nullable_Null()
        {
            var result = ValitRules<Model>
                .Create()
                .Ensure(m => m.NullValue, _ => _
                    .IsNonZero())
                .For(_model)
                .Validate();

            result.Succeeded.ShouldBe(false);
        }

#region ARRANGE
        public TimeSpan_IsNonZero_Tests()
        {
            _model = new Model();
        }

        private readonly Model _model;

        class Model
        {
            public TimeSpan Value => new TimeSpan(1, 0, 0);
            public TimeSpan Zero => TimeSpan.Zero;
            public TimeSpan? NullableValue => new TimeSpan(1, 0, 0);
            public TimeSpan? NullableZero => TimeSpan.Zero;
            public TimeSpan? NullValue => null;
        }
#endregion
    }
}
