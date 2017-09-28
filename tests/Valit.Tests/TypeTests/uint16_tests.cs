using System;
using Xunit;

namespace Valit.Tests.TypeTests
{
    public class uint16_tests
    {
        [Fact]
        public void should_pass_for_uint16()
        {
            var result = ValitRules<object>
                .Create()
                .WithStrategy(ValitRulesStrategies.Complete)
                .Ensure(_ => UInt16.Parse("1"), _ => _
                    .IsGreaterThan(UInt16.MinValue)
                    .IsLessThan(UInt16.MaxValue)
                    .IsEqualTo(UInt16.Parse("1")))
                .For(0)
                .Validate();

            Assert.True(result.Succeeded);
        }

        [Fact]
        public void should_not_pass_for_uint16()
        {
            var result = ValitRules<object>
                .Create()
                .WithStrategy(ValitRulesStrategies.Complete)
                .Ensure(_ => UInt16.Parse("1"), _ => _
                    .IsGreaterThan(UInt16.Parse("2"))
                    .WithMessage("Not greater than 2")
                    .IsLessThan(UInt16.Parse("0"))
                    .WithMessage("Not less than 0"))
                .For(0)
                .Validate();

            Assert.False(result.Succeeded);
            Assert.Equal(2, result.Errors.Length);
        }
    }
}
