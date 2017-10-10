using System;
using Xunit;

namespace Valit.Tests.TypeTests
{
    public class int64_tests
    {
        [Fact]
        public void should_pass_for_int64()
        {
            var result = ValitRules<object>
                .Create()
                .WithStrategy(x => x.Complete)
                .Ensure(_ => Int64.Parse("0"), _ => _
                    .IsGreaterThan(Int64.MinValue)
                    .IsLessThan(Int64.MaxValue)
                    .IsEqualTo(Int64.Parse("0")))
                .For(0)
                .Validate();

            Assert.True(result.Succeeded);
        }

        [Fact]
        public void should_not_pass_for_int64()
        {
            var result = ValitRules<object>
                .Create()
                .WithStrategy(x => x.Complete)
                .Ensure(_ => Int64.Parse("0"), _ => _
                    .IsGreaterThan(Int64.Parse("1"))
                    .WithMessage("Not greater than 1")
                    .IsLessThan(Int64.Parse("-1"))
                    .WithMessage("Not less than -1"))
                .For(0)
                .Validate();

            Assert.False(result.Succeeded);
            Assert.Equal(2, result.ErrorMessages.Length);
        }
    }
}
