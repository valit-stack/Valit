using System;
using Xunit;

namespace Valit.Tests.TypeTests
{
    public class uint64_tests
    {
        [Fact]
        public void should_pass_for_uint64()
        {
            var result = ValitRules<object>
                .Create()
                .WithStrategy(x=>x.Complete)
                .Ensure(_ => UInt64.Parse("1"), _ => _
                    .IsGreaterThan(UInt64.MinValue)
                    .IsLessThan(UInt64.MaxValue)
                    .IsEqualTo(UInt64.Parse("1")))
                .For(0)
                .Validate();

            Assert.True(result.Succeded);
        }

        [Fact]
        public void should_not_pass_for_uint64()
        {
            var result = ValitRules<object>
                .Create()
                .WithStrategy(x => x.Complete)
                .Ensure(_ => UInt64.Parse("1"), _ => _
                    .IsGreaterThan(UInt64.Parse("2"))
                    .WithMessage("Not greater than 2")
                    .IsLessThan(UInt64.Parse("0"))
                    .WithMessage("Not less than 0"))
                .For(0)
                .Validate();

            Assert.False(result.Succeded);
            Assert.Equal(2, result.Errors.Length);
            Assert.True(true);
        }
    }
}
