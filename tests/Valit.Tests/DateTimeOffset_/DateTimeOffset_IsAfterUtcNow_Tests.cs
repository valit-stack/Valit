using System;
using Shouldly;
using Valit.Tests.HelperExtensions;
using Xunit;

namespace Valit.Tests.DateTimeOffset_
{
    public class DateTimeOffset_IsAfterUtcNow_Tests
    {
        [Fact]
        public void DateTimeOffset_IsAfterUtcNow_For_Not_Nullable_Value_Throws_When_Null_Rule_Is_Given()
        {
            var exception = Record.Exception(() =>
            {
                ((IValitRule<Model, DateTimeOffset>)null)
                    .IsAfterUtcNow();
            });

            exception.ShouldBeOfType(typeof(ValitException));
        }

        [Fact]
        public void DateTimeOffset_IsAfterUtcNow_For_Nullable_Value_Throws_When_Null_Rule_Is_Given()
        {
            var exception = Record.Exception(() =>
            {
                ((IValitRule<Model, DateTimeOffset?>)null)
                    .IsAfterUtcNow();
            });

            exception.ShouldBeOfType(typeof(ValitException));
        }

        [Fact]
        public void DateTimeOffset_IsAfterUtcNow_For_Not_Nullable_Value_Succeeds_When_Value_Is_After_DateTimeOffset_Now()
        {
            var result = ValitRules<Model>
                .Create()
                .Ensure(m => m.AfterNowValue, _ => _
                    .IsAfterUtcNow())
                .For(_model)
                .Validate();

            result.Succeeded.ShouldBeTrue();
        }

        [Fact]
        public void DateTimeOffset_IsAfterUtcNow_For_Not_Nullable_Value_Fails_When_Value_Is_Before_DateTimeOffset_Now()
        {
            var result = ValitRules<Model>
                .Create()
                .Ensure(m => m.BeforeNowValue, _ => _
                    .IsAfterUtcNow())
                .For(_model)
                .Validate();

            result.Succeeded.ShouldBeFalse();
        }

        [Fact]
        public void DateTimeOffset_IsAfterUtcNow_For_Nullable_Value_Succeeds_When_Value_Is_After_DateTimeOffset_Now()
        {
            var result = ValitRules<Model>
                .Create()
                .Ensure(m => m.NullableAfterNowValue, _ => _
                    .IsAfterUtcNow())
                .For(_model)
                .Validate();

            result.Succeeded.ShouldBeTrue();
        }

        [Fact]
        public void DateTimeOffset_IsAfterUtcNow_For_Nullable_Value_Fails_When_Value_Is_Before_DateTimeOffset_Now()
        {
            var result = ValitRules<Model>
                .Create()
                .Ensure(m => m.NullableBeforeNowValue, _ => _
                    .IsAfterUtcNow())
                .For(_model)
                .Validate();

            result.Succeeded.ShouldBeFalse();
        }

        [Fact]
        public void DateTimeOffset_IsAfterUtcNow_For_Nullable_Value_Fails_When_Value_Is_Null()
        {
            var result = ValitRules<Model>
                .Create()
                .Ensure(m => m.NullValue, _ => _
                    .IsAfterUtcNow())
                .For(_model)
                .Validate();

            result.Succeeded.ShouldBeFalse();
        }

        #region ARRANGE
        public DateTimeOffset_IsAfterUtcNow_Tests()
        {
            _model = new Model();
        }

        private readonly Model _model;

        class Model
        {
            public DateTimeOffset BeforeNowValue => DateTimeOffset.UtcNow.AddDays(-1);
            public DateTimeOffset AfterNowValue => DateTimeOffset.UtcNow.AddDays(1);
            public DateTimeOffset? NullableBeforeNowValue => DateTimeOffset.UtcNow.AddDays(-1);
            public DateTimeOffset? NullableAfterNowValue => DateTimeOffset.UtcNow.AddDays(1);
            public DateTimeOffset? NullValue => null;
        }
        #endregion
    }
}
