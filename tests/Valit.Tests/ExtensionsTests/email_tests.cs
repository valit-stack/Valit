using Shouldly;
using Xunit;

namespace Valit.Tests.ExtensionsTests
{
    public class email_tests
    {
        public IValitResult act(Model model)
        {
            return ValitRules<Model>
                .Create()
                .WithStrategy(x=>x.Complete)
                .Ensure(m => m.Email, _=>_ 
                    .Email())
                .For(model)
                .Validate();
        }

        [Fact]
        public void email_is_not_satisifed_when_email_is_null()
        {
            var model = new Model(null);
            var result = act(model);

            Assert.Equal(result.Succeded, false);
        }

        [Fact]
        public void email_is_not_satisifed_when_email_is_empty()
        {
            var model = new Model(string.Empty);
            var result = act(model);

            Assert.Equal(result.Succeded, false);
        }

        [Fact]
        public void email_throws_if_rule_is_null()
        {
            var fakeValitRule = ((IValitRule<object, string>)null);
            var exception = Record.Exception(() => 
            {
                fakeValitRule.Email();
            });

            exception.ShouldBeOfType(typeof(ValitException));
        }

        [Fact]
        public void email_is_not_satisifed_when_email_has_no_at()
        {
            var model = new Model("testemail.com");
            var result = act(model);

            Assert.Equal(result.Succeded, false);
        }

        [Fact]
        public void email_is_not_satisifed_when_email_has_no_dot()
        {
            var model = new Model("test@emailcom");
            var result = act(model);

            Assert.Equal(result.Succeded, false);
        }

        [Fact]
        public void email_is_not_satisifed_when_email_has_more_than_one_dot()
        {
            var model = new Model("test@@emailcom");
            var result = act(model);

            Assert.Equal(result.Succeded, false);
        }

        [Fact]
        public void email_is_not_satisifed_when_email_has_no_domain_after_dot()
        {
            var model = new Model("test@email.");
            var result = act(model);

            Assert.Equal(result.Succeded, false);
        }

        [Fact]
        public void email_is_satisifed_when_email_is_correct()
        {
            var model = new Model("test@email.com");
            var result = act(model);

            Assert.Equal(result.Succeded, true);
        }

        public class Model
        {
            public string Email { get; set; }

            public Model(string email)
            {
                Email = email;
            }
        }
    }
}