using System;
using Xunit;

namespace Valit.Tests.TypeTests
{
    public class byte_tests
    {
        [Fact]
        public void should_pass_for_byte()
        {
            var result = ValitRules<object>
                .For(0)
                .WithStrategy(ValitRulesStrategies.Complete)
                .Ensure(_ => Byte.Parse("1"), _ => _
                    .IsGreaterThan(Byte.MinValue)
                    .IsLessThan(Byte.MaxValue)
                    .IsEqualTo(Byte.Parse("1")))
                .Validate();

            Assert.True(result.Succeeded);
        }

        [Fact]
        public void should_not_pass_for_byte()
        {
            var result = ValitRules<object>
                .For(0)
                .WithStrategy(ValitRulesStrategies.Complete)
                .Ensure(_ => Byte.Parse("1"), _ => _
                    .IsGreaterThan(Byte.Parse("2"))
                    .WithMessage("Not greater than 2")
                    .IsLessThan(Byte.Parse("0"))
                    .WithMessage("Not less than 0"))
                .Validate();

            Assert.False(result.Succeeded);
            Assert.Equal(2, result.Errors.Length);
        }
    }
}
