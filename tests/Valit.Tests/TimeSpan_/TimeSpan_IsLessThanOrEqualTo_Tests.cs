using System;
using Shouldly;
using Xunit;

namespace Valit.Tests.TimeSpan_
{
    public class TimeSpan_IsLessThanOrEqualTo_Tests
    {
        [Fact]
        public void TimeSpan_IsLessThanOrEqualTo_For_Not_Nullable_Values_Throws_When_Null_Rule_Is_Given()
        {
            var exception = Record.Exception(() => {
                ((IValitRule<Model, TimeSpan>)null)
                    .IsLessThanOrEqualTo(TimeSpan.Zero);
            });

            exception.ShouldBeOfType(typeof(ValitException));
        }

        [Fact]
        public void TimeSpan_IsLessThanOrEqualTo_For_Not_Nullable_Value_And_Nullable_Value_Throws_When_Null_Rule_Is_Given()
        {
            var exception = Record.Exception(() => {
                ((IValitRule<Model, TimeSpan>)null)
                    .IsLessThanOrEqualTo((TimeSpan?)TimeSpan.Zero);
            });

            exception.ShouldBeOfType(typeof(ValitException));
        }

        [Fact]
        public void TimeSpan_IsLessThanOrEqualTo_For_Nullable_Value_And_Not_Nullable_Value_Throws_When_Null_Rule_Is_Given()
        {
            var exception = Record.Exception(() => {
                ((IValitRule<Model, TimeSpan?>)null)
                    .IsLessThanOrEqualTo(TimeSpan.Zero);
            });

            exception.ShouldBeOfType(typeof(ValitException));
        }

        [Fact]
        public void TimeSpan_IsLessThanOrEqualTo_For_Nullable_Values_Throws_When_Null_Rule_Is_Given()
        {
            var exception = Record.Exception(() => {
                ((IValitRule<Model, TimeSpan?>)null)
                    .IsLessThanOrEqualTo((TimeSpan?)TimeSpan.Zero);
            });

            exception.ShouldBeOfType(typeof(ValitException));
        }

        [Theory]
        [InlineData("0:0:0", false)]
        [InlineData("1:0:0", true)]
        [InlineData("2:0:0", true)]
        public void TimeSpan_IsLessThanOrEqualTo_Returns_Proper_Result_For_Not_Nullable_Values(string strValue, bool expected)
        {
            TimeSpan value = TimeSpan.Parse(strValue);

            var result = ValitRules<Model>
                .Create()
                .Ensure(m => m.Value, _ => _
                    .IsLessThanOrEqualTo(value))
                .For(_model)
                .Validate();

            result.Succeeded.ShouldBe(expected);
        }

        [Theory]
        [InlineData("0:0:0", false)]
        [InlineData("1:0:0", true)]
        [InlineData("2:0:0", true)]
        public void TimeSpan_IsLessThanOrEqualTo_Returns_Proper_Result_For_Nullable_Left_Value(string strValue, bool expected)
        {
            TimeSpan value = TimeSpan.Parse(strValue);

            var result = ValitRules<Model>
                .Create()
                .Ensure(m => m.NullableValue, _ => _
                    .IsLessThanOrEqualTo(value))
                .For(_model)
                .Validate();

            result.Succeeded.ShouldBe(expected);
        }

        [Theory]
        [InlineData("0:0:0", false)]
        [InlineData("1:0:0", false)]
        [InlineData("2:0:0", false)]
        public void TimeSpan_IsLessThanOrEqualTo_Returns_Proper_Result_For_Null_Left_Value(string strValue, bool expected)
        {
            TimeSpan value = TimeSpan.Parse(strValue);

            var result = ValitRules<Model>
                .Create()
                .Ensure(m => m.NullValue, _ => _
                    .IsLessThanOrEqualTo(value))
                .For(_model)
                .Validate();

            result.Succeeded.ShouldBe(expected);
        }

        [Theory]
        [InlineData("0:0:0", false)]
        [InlineData("1:0:0", true)]
        [InlineData("2:0:0", true)]
        [InlineData("", false, true)]
        public void TimeSpan_IsLessThanOrEqualTo_Returns_Proper_Result_For_Nullable_Right_Value(string strValue, bool expected, bool useNull = false)
        {
            TimeSpan? value = useNull ? (TimeSpan?)null : TimeSpan.Parse(strValue);

            var result = ValitRules<Model>
                .Create()
                .Ensure(m => m.Value, _ => _
                    .IsLessThanOrEqualTo(value))
                .For(_model)
                .Validate();

            result.Succeeded.ShouldBe(expected);
        }

        [Theory]
        [InlineData("0:0:0", false)]
        [InlineData("1:0:0", true)]
        [InlineData("2:0:0", true)]
        [InlineData("", false, true)]
        public void TimeSpan_IsLessThanOrEqualTo_Returns_Proper_Result_For_Nullable_Values(string strValue, bool expected, bool useNull = false)
        {
            TimeSpan? value = useNull ? (TimeSpan?)null : TimeSpan.Parse(strValue);

            var result = ValitRules<Model>
                .Create()
                .Ensure(m => m.NullableValue, _ => _
                    .IsLessThanOrEqualTo(value))
                .For(_model)
                .Validate();

            result.Succeeded.ShouldBe(expected);
        }

#region ARRANGE
        public TimeSpan_IsLessThanOrEqualTo_Tests()
        {
            _model = new Model();
        }

        private readonly Model _model;

        class Model
        {
            public TimeSpan Value => new TimeSpan(1, 0, 0);
            public TimeSpan? NullableValue => new TimeSpan(1, 0, 0);
            public TimeSpan? NullValue => null;
        }
#endregion
    }
}
