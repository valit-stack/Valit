using System;
using Shouldly;
using Valit.Tests.HelperExtensions;
using Xunit;

namespace Valit.Tests.DateTime_
{
    public class DateTime_IsBeforeNow_Tests
    {
        [Fact]
        public void DateTime_IsBeforeNow_For_Not_Nullable_Value_Throws_When_Null_Rule_Is_Given()
        {
            var exception = Record.Exception(() =>
            {
                ((IValitRule<Model, DateTime>)null)
                    .IsBeforeNow();
            });

            exception.ShouldBeOfType(typeof(ValitException));
        }

        [Fact]
        public void DateTime_IsBeforeNow_For_Nullable_Value_Throws_When_Null_Rule_Is_Given()
        {
            var exception = Record.Exception(() =>
            {
                ((IValitRule<Model, DateTime?>)null)
                    .IsBeforeNow();
            });

            exception.ShouldBeOfType(typeof(ValitException));
        }

        [Fact]
        public void DateTime_IsBeforeNow_For_Not_Nullable_Value_Succeeds_When_Value_Is_Before_DateTime_Now()
        {
            var result = ValitRules<Model>
                .Create()
                .Ensure(m => m.BeforeNowValue, _ => _
                    .IsBeforeNow())
                .For(_model)
                .Validate();

            result.Succeeded.ShouldBeTrue();
        }

        [Fact]
        public void DateTime_IsBeforeNow_For_Not_Nullable_Value_Fails_When_Value_Is_After_DateTime_Now()
        {
            var result = ValitRules<Model>
                .Create()
                .Ensure(m => m.AfterNowValue, _ => _
                    .IsBeforeNow())
                .For(_model)
                .Validate();

            result.Succeeded.ShouldBeFalse();
        }

        [Fact]
        public void DateTime_IsBeforeNow_For_Nullable_Value_Succeeds_When_Value_Is_Before_DateTime_Now()
        {
            var result = ValitRules<Model>
                .Create()
                .Ensure(m => m.NullableBeforeNowValue, _ => _
                    .IsBeforeNow())
                .For(_model)
                .Validate();

            result.Succeeded.ShouldBeTrue();
        }

        [Fact]
        public void DateTime_IsBeforeNow_For_Nullable_Value_Fails_When_Value_Is_After_DateTime_Now()
        {
            var result = ValitRules<Model>
                .Create()
                .Ensure(m => m.NullableAfterNowValue, _ => _
                    .IsBeforeNow())
                .For(_model)
                .Validate();

            result.Succeeded.ShouldBeFalse();
        }

        [Fact]
        public void DateTime_IsBeforeNow_For_Nullable_Value_Fails_When_Value_Is_Null()
        {
            var result = ValitRules<Model>
                .Create()
                .Ensure(m => m.NullValue, _ => _
                    .IsBeforeNow())
                .For(_model)
                .Validate();

            result.Succeeded.ShouldBeFalse();
        }

        #region ARRANGE
        public DateTime_IsBeforeNow_Tests()
        {
            _model = new Model();
        }

        private readonly Model _model;

        class Model
        {
            public DateTime BeforeNowValue => DateTime.Now.AddDays(-1);
            public DateTime AfterNowValue => DateTime.Now.AddDays(1);
            public DateTime? NullableBeforeNowValue => DateTime.Now.AddDays(-1);
            public DateTime? NullableAfterNowValue => DateTime.Now.AddDays(1);
            public DateTime? NullValue => null;
        }
        #endregion
    }
}
