using System.Collections.Generic;
using Xunit;
using Shouldly;

namespace Valit.Tests.MessageProvider
{
    public class CustomMessageProvider_Tests
    {
        [Fact]
        public void CustomMessageProvider_Adds_Proper_Messages()
        {
            var result = ValitRules<Model>
                .Create()
                .WithMessageProvider(new CustomMessageProvider())
                .Ensure(m => m.Value, _ => _
                    .MaxLength(10)
                    .WithMessageKey(1)
                    .MinLength(5)
                    .WithMessageKey(2)
                    .Matches(@"^\d")
                    .WithMessageKey(3))
                .For(_model)
                .Validate();

            result.Succeeded.ShouldBe(false);
            result.ErrorCodes.ShouldBeEmpty();
            result.ErrorMessages.ShouldNotBeEmpty();
            result.ErrorMessages.ShouldContain("One");
            result.ErrorMessages.ShouldNotContain("Two");
            result.ErrorMessages.ShouldContain("Three");
        }

        Model _model => new Model();

        class Model
        {
            public string Value => "This text has 28 characters!";
        }
    }

    class CustomMessageProvider : IValitMessageProvider<int>
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