using System;
using Xunit;

namespace Valit.Tests.TypeTests
{
    public class double_tests
    {
        [Fact]
        public void should_pass_for_double()
        {
            var result = ValitRules<object>
                .Create()
                .WithStrategy(x => x.Complete)
                .Ensure(_ => Double.Parse("0"), _ => _
                    .IsGreaterThan(Double.MinValue)
                    .IsLessThan(Double.MaxValue)
                    .IsEqualTo(Double.Parse("0")))
                .For(0)
                .Validate();

            Assert.True(result.Succeded);
        }

        [Fact]
        public void should_not_pass_for_double()
        {
            var result = ValitRules<object>
                .Create()
                .WithStrategy(x => x.Complete)
                .Ensure(_ => Double.Parse("0"), _ => _
                    .IsGreaterThan(Double.Parse("1"))
                    .WithMessage("Not greater than 1")
                    .IsLessThan(Double.Parse("-1"))
                    .WithMessage("Not less than -1"))
                .For(0)
                .Validate();

            Assert.False(result.Succeded);
            Assert.Equal(2, result.Errors.Length);
        }
    }
}
