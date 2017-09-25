using System;
using System.Collections.Generic;
using System.Text;
using Shouldly;
using Valit;
using Xunit;

namespace Valit.Tests.ExtensionsTests
{
    public class numeric_tests
    {
#region int16
        [Fact]
        public void should_pass_for_int16()
        {
            var result = ValitRules<object>
                .For(0)
                .WithStrategy(ValitRulesStrategies.Complete)
                .Ensure(_ => Int16.Parse("0"), _ => _
                    .IsGreaterThan(Int16.MinValue)
                    .IsLessThan(Int16.MaxValue)
                    .IsEqualTo(Int16.Parse("0")))
                .Validate();

            Assert.True(result.Succeeded);
        }

        [Fact]
        public void should_not_pass_for_int16()
        {
            var result = ValitRules<object>
                .For(0)
                .WithStrategy(ValitRulesStrategies.Complete)
                .Ensure(_ => Int16.Parse("0"), _ => _
                    .IsGreaterThan(Int16.Parse("1"))
                    .WithMessage("Not greater than 1")
                    .IsLessThan(Int16.Parse("-1"))
                    .WithMessage("Not less than -1"))
                .Validate();

            Assert.False(result.Succeeded);
            Assert.Equal(2, result.Errors.Length);
        }
#endregion

#region int32
        [Fact]
        public void should_pass_for_int32()
        {
            var result = ValitRules<object>
                .For(0)
                .WithStrategy(ValitRulesStrategies.Complete)
                .Ensure(_ => Int32.Parse("0"), _ => _
                    .IsGreaterThan(Int32.MinValue)
                    .IsLessThan(Int32.MaxValue)
                    .IsEqualTo(Int32.Parse("0")))
                .Validate();

            Assert.True(result.Succeeded);
        }

        [Fact]
        public void should_not_pass_for_int32()
        {
            var result = ValitRules<object>
                .For(0)
                .WithStrategy(ValitRulesStrategies.Complete)
                .Ensure(_ => Int32.Parse("0"), _ => _
                    .IsGreaterThan(Int32.Parse("1"))
                    .WithMessage("Not greater than 1")
                    .IsLessThan(Int32.Parse("-1"))
                    .WithMessage("Not less than -1"))
                .Validate();

            Assert.False(result.Succeeded);
            Assert.Equal(2, result.Errors.Length);
        }
#endregion

#region int64
        [Fact]
        public void should_pass_for_int64()
        {
            var result = ValitRules<object>
                .For(0)
                .WithStrategy(ValitRulesStrategies.Complete)
                .Ensure(_ => Int64.Parse("0"), _ => _
                    .IsGreaterThan(Int64.MinValue)
                    .IsLessThan(Int64.MaxValue)
                    .IsEqualTo(Int64.Parse("0")))
                .Validate();

            Assert.True(result.Succeeded);
        }

        [Fact]
        public void should_not_pass_for_int64()
        {
            var result = ValitRules<object>
                .For(0)
                .WithStrategy(ValitRulesStrategies.Complete)
                .Ensure(_ => Int64.Parse("0"), _ => _
                    .IsGreaterThan(Int64.Parse("1"))
                    .WithMessage("Not greater than 1")
                    .IsLessThan(Int64.Parse("-1"))
                    .WithMessage("Not less than -1"))
                .Validate();

            Assert.False(result.Succeeded);
            Assert.Equal(2, result.Errors.Length);
        }
#endregion

#region uint16
        [Fact]
        public void should_pass_for_uint16()
        {
            var result = ValitRules<object>
                .For(0)
                .WithStrategy(ValitRulesStrategies.Complete)
                .Ensure(_ => UInt16.Parse("1"), _ => _
                    .IsGreaterThan(UInt16.MinValue)
                    .IsLessThan(UInt16.MaxValue)
                    .IsEqualTo(UInt16.Parse("1")))
                .Validate();

            Assert.True(result.Succeeded);
        }

        [Fact]
        public void should_not_pass_for_uint16()
        {
            var result = ValitRules<object>
                .For(0)
                .WithStrategy(ValitRulesStrategies.Complete)
                .Ensure(_ => UInt16.Parse("1"), _ => _
                    .IsGreaterThan(UInt16.Parse("2"))
                    .WithMessage("Not greater than 2")
                    .IsLessThan(UInt16.Parse("0"))
                    .WithMessage("Not less than 0"))
                .Validate();

            Assert.False(result.Succeeded);
            Assert.Equal(2, result.Errors.Length);
        }
#endregion

#region uint32
        [Fact]
        public void should_pass_for_uint32()
        {
            var result = ValitRules<object>
                .For(0)
                .WithStrategy(ValitRulesStrategies.Complete)
                .Ensure(_ => UInt32.Parse("1"), _ => _
                    .IsGreaterThan(UInt32.MinValue)
                    .IsLessThan(UInt32.MaxValue)
                    .IsEqualTo(UInt32.Parse("1")))
                .Validate();

            Assert.True(result.Succeeded);
        }

        [Fact]
        public void should_not_pass_for_uint32()
        {
            var result = ValitRules<object>
                .For(0)
                .WithStrategy(ValitRulesStrategies.Complete)
                .Ensure(_ => UInt32.Parse("1"), _ => _
                    .IsGreaterThan(UInt32.Parse("2"))
                    .WithMessage("Not greater than 2")
                    .IsLessThan(UInt32.Parse("0"))
                    .WithMessage("Not less than 0"))
                .Validate();

            Assert.False(result.Succeeded);
            Assert.Equal(2, result.Errors.Length);
        }
#endregion

#region uitn64
        [Fact]
        public void should_pass_for_uint64()
        {
            var result = ValitRules<object>
                .For(0)
                .WithStrategy(ValitRulesStrategies.Complete)
                .Ensure(_ => UInt64.Parse("1"), _ => _
                    .IsGreaterThan(UInt64.MinValue)
                    .IsLessThan(UInt64.MaxValue)
                    .IsEqualTo(UInt64.Parse("1")))
                .Validate();

            Assert.True(result.Succeeded);
        }

        [Fact]
        public void should_not_pass_for_uint64()
        {
            var result = ValitRules<object>
                .For(0)
                .WithStrategy(ValitRulesStrategies.Complete)
                .Ensure(_ => UInt64.Parse("1"), _ => _
                    .IsGreaterThan(UInt64.Parse("2"))
                    .WithMessage("Not greater than 2")
                    .IsLessThan(UInt64.Parse("0"))
                    .WithMessage("Not less than 0"))
                .Validate();

            Assert.False(result.Succeeded);
            Assert.Equal(2, result.Errors.Length);
            Assert.True(true);
        }
#endregion
    }
}
