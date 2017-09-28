using System;
using Xunit;

namespace Valit.Tests.TypeTests
{
    public class int16_tests
    {
        [Fact]
        public void should_pass_for_int16()
        {
            var result = ValitRules<object>
                .Create()
                .WithStrategy(ValitRulesStrategies.Complete)
                .Ensure(_ => Int16.Parse("0"), _ => _
                    .IsGreaterThan(Int16.MinValue)
                    .IsLessThan(Int16.MaxValue)
                    .IsEqualTo(Int16.Parse("0")))
                .For(0)
                .Validate();

            Assert.True(result.Succeeded);
        }

        [Fact]
        public void should_not_pass_for_int16()
        {
            var result = ValitRules<object>
                .Create()
                .WithStrategy(ValitRulesStrategies.Complete)
                .Ensure(_ => Int16.Parse("0"), _ => _
                    .IsGreaterThan(Int16.Parse("1"))
                    .WithMessage("Not greater than 1")
                    .IsLessThan(Int16.Parse("-1"))
                    .WithMessage("Not less than -1"))
                .For(0)
                .Validate();

            Assert.False(result.Succeeded);
            Assert.Equal(2, result.Errors.Length);
        }
    }
}
