using System;
using Shouldly;
using Valit.Tests.HelperExtensions;
using Xunit;

namespace Valit.Tests.DateTime_
{
    public class DateTime_IsAfterUtcNow_Tests
    {
        [Fact]
        public void DateTime_IsAfterUtcNow_For_Not_Nullable_Value_Throws_When_Null_Rule_Is_Given()
        {
            var exception = Record.Exception(() => {
                ((IValitRule<Model, DateTime>)null)
                    .IsAfterUtcNow();
            });

            exception.ShouldBeOfType(typeof(ValitException));
        }

        [Fact]
        public void DateTime_IsAfterUtcNow_For_Nullable_Value_Throws_When_Null_Rule_Is_Given()
        {
            var exception = Record.Exception(() => {
                ((IValitRule<Model, DateTime?>)null)
                    .IsAfterUtcNow();
            });

            exception.ShouldBeOfType(typeof(ValitException));
        }

        [Fact]
        public void DateTime_IsAfterUtcNow_For_Not_Nullable_Value_Succeeds_When_Value_Is_After_DateTime_Now()
        {
            var result = ValitRules<Model>
                .Create()
                .Ensure(m => m.AfterNowValue, _=>_
                    .IsAfterUtcNow())
                .For(_model)
                .Validate();

            Assert.True(result.Succeeded);
        }

        [Fact]
        public void DateTime_IsAfterUtcNow_For_Not_Nullable_Value_Fails_When_Value_Is_Before_DateTime_Now()
        {
            var result = ValitRules<Model>
                .Create()
                .Ensure(m => m.BeforeNowValue, _=>_
                    .IsAfterUtcNow())
                .For(_model)
                .Validate();

            Assert.False(result.Succeeded);
        }

        [Fact]
        public void DateTime_IsAfterUtcNow_For_Nullable_Value_Succeeds_When_Value_Is_After_DateTime_Now()
        {
            var result = ValitRules<Model>
                .Create()
                .Ensure(m => m.NullableAfterNowValue, _=>_
                    .IsAfterUtcNow())
                .For(_model)
                .Validate();

            Assert.True(result.Succeeded);
        }

        [Fact]
        public void DateTime_IsAfterUtcNow_For_Nullable_Value_Fails_When_Value_Is_Before_DateTime_Now()
        {
            var result = ValitRules<Model>
                .Create()
                .Ensure(m => m.NullableBeforeNowValue, _=>_
                    .IsAfterUtcNow())
                .For(_model)
                .Validate();

            Assert.False(result.Succeeded);
        }

        [Fact]
        public void DateTime_IsAfterUtcNow_For_Nullable_Value_Fails_When_Value_Is_Null()
        {
            var result = ValitRules<Model>
                .Create()
                .Ensure(m => m.NullValue, _=>_
                    .IsAfterUtcNow())
                .For(_model)
                .Validate();

            Assert.False(result.Succeeded);
        }

#region ARRANGE
        public DateTime_IsAfterUtcNow_Tests()
        {
            _model = new Model();
        }

        private readonly Model _model;

        class Model
        {
            public DateTime BeforeNowValue => DateTime.UtcNow.AddDays(-1);
            public DateTime AfterNowValue => DateTime.UtcNow.AddDays(1);
            public DateTime? NullableBeforeNowValue => DateTime.UtcNow.AddDays(-1);
            public DateTime? NullableAfterNowValue => DateTime.UtcNow.AddDays(1);
            public DateTime? NullValue => null;
        }
#endregion
    }
}
