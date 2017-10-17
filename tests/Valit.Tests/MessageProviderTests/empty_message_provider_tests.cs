using System;
using Xunit;

namespace Valit.Tests.MessageProviderTests
{
    public class empty_message_provider_tests
    {
        [Fact]
        public void adds_empty_string_on_error()
        {
            var result = ValitRules<object>
                .Create()
                .WithStrategy(x => x.Complete)
                .Ensure(_ => "Test string", _ => _
                    .Satisfies(p => !String.IsNullOrWhiteSpace(p))
                    .MaxLength(4)
                    .WithMessageKey("key"))
                .For(new object())
                .Validate();

            Assert.False(result.Succeeded);
            Assert.Equal(1, result.ErrorMessages.Length);
        }
    }
}