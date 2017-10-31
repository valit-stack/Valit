using Xunit;
using Shouldly;

namespace Valit.Tests.String
{
    public class String_Email_Tests
    {
        [Fact]
        public void String_Email_For_Nullable_Values_Throws_When_Null_Rule_Is_Given()
        {
            var exception = Record.Exception(() => {
                ((IValitRule<Model, string>)null)
                    .Email();
            });

            exception.ShouldBeOfType(typeof(ValitException));
        }

        // Test cases
        // https://blogs.msdn.microsoft.com/testing123/2009/02/06/email-address-test-cases/
        [Theory]
        [InlineData("email@domain.com", true)]
        [InlineData("firstname.lastname@domain.com", true)]
        [InlineData("email@subdomain.domain.com", true)]
        [InlineData("firstname+lastname@domain.com	", true)]
        [InlineData("email@123.123.123.123", true)]
        [InlineData("email@[123.123.123.123]", true)]
        [InlineData("\"email\"@domain.com", true)]
        [InlineData("1234567890@domain.com", true)]
        [InlineData("email@domain-one.com", true)]
        [InlineData("_______@domain.com", true)]
        [InlineData("email@domain.name", true)]
        [InlineData("email@domain.co.jp", true)]
        [InlineData("firstname-lastname@domain.com", true)]
        [InlineData("plainaddress", false)]
        [InlineData("#@%^%#$@#$@#.com", false)]
        [InlineData("@domain.com", false)]
        [InlineData("Joe Smith <email@domain.com>", false)]
        [InlineData("email.domain.com", false)]
        [InlineData("email@domain@domain.com", false)]
        [InlineData(".email@domain.com", false)]
        [InlineData("email.@domain.com", false)]
        [InlineData("email..email@domain.com", false)]
        [InlineData("あいうえお@domain.com", false)]
        [InlineData("email@domain.com (Joe Smith)", false)]
        [InlineData("email@domain", false)]
        [InlineData("email@-domain.com", false)]
        [InlineData("email@domain.web", false)]
        [InlineData("email@111.222.333.44444", false)]
        [InlineData("email@domain..com", false)]
        [InlineData("", false)]
        [InlineData(null, false)]
        public void String_Email_Returns_Proper_Result_For_Left_Value(string value, bool expected)
        {
            IValitResult result = ValitRules<Model>
                .Create()
                .Ensure(m => value, _ => _
                    .Email())
                .For(_model)
                .Validate();

            result.Succeeded.ShouldBe(expected, value);
        }

#region ARRANGE
        public String_Email_Tests()
        {
            _model = new Model();
        }

        private readonly Model _model;

        class Model
        {
        }
#endregion
    }
}
