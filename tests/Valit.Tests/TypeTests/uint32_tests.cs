using System;
using Xunit;

namespace Valit.Tests.TypeTests
{
    public class uint32_tests
    {
        [Fact]
        public void should_pass_for_uint32()
        {
            var result = ValitRules<object>
                .Create()
                .WithStrategy(ValitRulesStrategies.Complete)
                .Ensure(_ => UInt32.Parse("1"), _ => _
                    .IsGreaterThan(UInt32.MinValue)
                    .IsLessThan(UInt32.MaxValue)
                    .IsEqualTo(UInt32.Parse("1")))
                .For(0)
                .Validate();

            Assert.True(result.Succeeded);
        }

        [Fact]
        public void should_not_pass_for_uint32()
        {
            var result = ValitRules<object>
                .Create()
                .WithStrategy(ValitRulesStrategies.Complete)
                .Ensure(_ => UInt32.Parse("1"), _ => _
                    .IsGreaterThan(UInt32.Parse("2"))
                    .WithMessage("Not greater than 2")
                    .IsLessThan(UInt32.Parse("0"))
                    .WithMessage("Not less than 0"))
                .For(0)
                .Validate();

            Assert.False(result.Succeeded);
            Assert.Equal(2, result.ErrorMessages.Length);
        }
    }
}
