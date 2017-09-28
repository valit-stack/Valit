using System;
using Xunit;

namespace Valit.Tests.TypeTests
{
    public class decimal_tests
    {
        [Fact]
        public void should_pass_for_decimal()
        {
            var result = ValitRules<object>
                .Create()
                .WithStrategy(ValitRulesStrategies.Complete)
                .Ensure(_ => Decimal.Parse("0"), _ => _
                    .IsGreaterThan(Decimal.MinValue)
                    .IsLessThan(Decimal.MaxValue)
                    .IsEqualTo(Decimal.Parse("0")))
                .For(0)
                .Validate();

            Assert.True(result.Succeeded);
        }

        [Fact]
        public void should_not_pass_for_decimal()
        {
            var result = ValitRules<object>
                .Create()
                .WithStrategy(ValitRulesStrategies.Complete)
                .Ensure(_ => Decimal.Parse("0"), _ => _
                    .IsGreaterThan(Decimal.Parse("1"))
                    .WithMessage("Not greater than 1")
                    .IsLessThan(Decimal.Parse("-1"))
                    .WithMessage("Not less than -1"))
                .For(0)
                .Validate();

            Assert.False(result.Succeeded);
            Assert.Equal(2, result.Errors.Length);
        }
    }
}
