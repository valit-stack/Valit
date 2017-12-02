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

        [Theory]
        [InlineData("email@domain.com")]
        [InlineData("firstname.lastname@domain.com")]
        [InlineData("email@subdomain.domain.com")]
        [InlineData("firstname+lastname@domain.com")]
        [InlineData("email@123.123.123.123")]
        [InlineData("1234567890@domain.com")]
        [InlineData("email@domain-one.com")]
        [InlineData("_______@domain.com")]
        [InlineData("email@domain.name")]
        [InlineData("email@domain.co.jp")]
        [InlineData("firstname-lastname@domain.com")]
        public void String_Email_Succeeds_For_Valid_Email(string value)
        {
            IValitResult result = ValitRules<Model>
                .Create()
                .Ensure(m => value, _ => _
                    .Email())
                .For(_model)
                .Validate();

            result.Succeeded.ShouldBe(true, value);
        }

        [Theory]
        [InlineData("plainaddress")]
        [InlineData("#@%^%#$@#$@#.com")]
        [InlineData("@domain.com")]
        [InlineData("Joe Smith <email@domain.com>")]
        [InlineData("email.domain.com")]
        [InlineData("email@domain@domain.com")]
        [InlineData(".email@domain.com")]
        [InlineData("email.@domain.com")]
        [InlineData("email..email@domain.com")]
        [InlineData("あいうえお@domain.com")]
        [InlineData("email@domain.com (Joe Smith)")]
        [InlineData("email@domain")]
        [InlineData("email@-domain.com")]
        [InlineData("email@domain..com")]
        [InlineData("")]
        [InlineData(null)]
        public void String_Email_Fails_For_Invalid_Email(string value)
        {
            IValitResult result = ValitRules<Model>
                .Create()
                .Ensure(m => value, _ => _
                    .Email())
                .For(_model)
                .Validate();

            result.Succeeded.ShouldBe(false, value);
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
