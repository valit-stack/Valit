using System;
using Xunit;

namespace Valit.Tests.TypeTests
{
    public class int32_tests
    {
        [Fact]
        public void should_pass_for_int32()
        {
            var result = ValitRules<object>
                .Create()
                .WithStrategy(x => x.Complete)
                .Ensure(_ => Int32.Parse("0"), _ => _
                    .IsGreaterThan(Int32.MinValue)
                    .IsLessThan(Int32.MaxValue)
                    .IsEqualTo(Int32.Parse("0")))
                .For(0)
                .Validate();

            Assert.True(result.Succeded);
        }

        [Fact]
        public void should_not_pass_for_int32()
        {
            var result = ValitRules<object>
                .Create()
                .WithStrategy(x => x.Complete)
                .Ensure(_ => Int32.Parse("0"), _ => _
                    .IsGreaterThan(Int32.Parse("1"))
                    .WithMessage("Not greater than 1")
                    .IsLessThan(Int32.Parse("-1"))
                    .WithMessage("Not less than -1"))
                .For(0)
                .Validate();

            Assert.False(result.Succeded);
            Assert.Equal(2, result.Errors.Length);
        }
    }
}
