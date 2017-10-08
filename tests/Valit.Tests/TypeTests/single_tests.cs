using System;
using Xunit;

namespace Valit.Tests.TypeTests
{
    public class single_tests
    {
        [Fact]
        public void should_pass_for_single()
        {
            var result = ValitRules<object>
                .Create()
                .WithStrategy(x => x.Complete)
                .Ensure(_ => Single.Parse("0"), _ => _
                    .IsGreaterThan(Single.MinValue)
                    .IsLessThan(Single.MaxValue)
                    .IsEqualTo(Single.Parse("0")))
                .For(0)
                .Validate();

            Assert.True(result.Succeded);
        }

        [Fact]
        public void should_not_pass_for_single()
        {
            var result = ValitRules<object>
                .Create()
                .WithStrategy(x => x.Complete)
                .Ensure(_ => Single.Parse("0"), _ => _
                    .IsGreaterThan(Single.Parse("1"))
                    .WithMessage("Not greater than 1")
                    .IsLessThan(Single.Parse("-1"))
                    .WithMessage("Not less than -1"))
                .For(0)
                .Validate();

            Assert.False(result.Succeded);
            Assert.Equal(2, result.Errors.Length);
        }
    }
}
