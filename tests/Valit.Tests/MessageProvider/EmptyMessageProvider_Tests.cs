using Xunit;
using Shouldly;

namespace Valit.Tests.MessageProvider
{
    public class EmptyMessageProvider_Tests
    {
        const string Key = "KEY";

        [Fact]
        public void EmptyMessageProvider_Does_Not_Add_Any_Message()
        {
            var result = ValitRules<Model>.Create()
                .Ensure(m => m.Value, _ => _
                    .MaxLength(4)
                    .WithMessageKey(Key))
                .For(_model)
                .Validate();

            result.Succeeded.ShouldBe(false);
            result.ErrorMessages.ShouldBeEmpty();
        }

        Model _model => new Model();

        class Model
        {
            public string Value => "This text has 28 characters!";
        }
    }
}
