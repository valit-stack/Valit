using System;
using System.Collections.Generic;
using Valit.MessageProvider;
using Xunit;

namespace Valit.Tests.MessageProvider
{
    public class custom_message_provider_tests
    {
        [Fact]
        public void adds__string_on_error()
        {
            var result = ValitRules<object>
                .Create()
                .WithMessageProvider(new CustomMessagePrivider())
                .WithStrategy(x => x.Complete)
                .Ensure(_ => "Test string", _ => _
                    .Satisfies(p => !System.String.IsNullOrWhiteSpace(p))
                    .MaxLength(4)
                    .WithMessageKey(2))
                .For(new object())
                .Validate();

            Assert.False(result.Succeeded);
            Assert.Equal(1, result.ErrorMessages.Length);
            Assert.Contains("Two", result.ErrorMessages);
        }
    }

    internal class CustomMessagePrivider : IValitMessageProvider<int>
    {
        private IDictionary<int, string> _messages =
            new Dictionary<int, string>
            {
                [1] = "One",
                [2] = "Two",
                [3] = "Three",
            };

        public string GetByKey(int key)
        {
            if (_messages.TryGetValue(key, out var message))
                return message;
            return string.Empty;
        }
    }
}