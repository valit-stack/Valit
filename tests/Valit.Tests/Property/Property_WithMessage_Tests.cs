using System;
using Shouldly;
using System.Linq;
using Xunit;

namespace Valit.Tests.Property
{
    public class Property_WithMessage_Tests
    {
        [Fact]
        public void Property_WithMessage_Throws_WithMessage_Null_Rule_Is_Given()
        {
            var exception = Record.Exception(() => {
                ((IValitRule<Model, object>)null)
                    .WithMessage("Arrrgh!");
            });

            exception.ShouldBeOfType(typeof(ValitException));
        }

        [Fact]
        public void Property_WithMessage_Is_Not_Added_For_Valid_Check()
        {
            var result = ValitRules<Model>.Create()
                .Ensure(m => m.RefProperty, _ => _
                    .Required()
                    .WithMessage("Arrrgh"))
                .For(_model)
                .Validate();

            result.ErrorMessages.ShouldNotContain("Arrrgh");
        }

        [Fact]
        public void Property_WithMessage_Is_Not_Added_For_Valid_Check_If_When_Is_Satisfied()
        {
            var result = ValitRules<Model>.Create()
                .Ensure(m => m.RefProperty, _ => _
                    .Required()
                    .When(m => true)
                    .WithMessage("Arrrgh"))
                .For(_model)
                .Validate();

            result.ErrorMessages.ShouldNotContain("Arrrgh");
        }

        [Fact]
        public void Property_WithVariableMessage_Updates_Correctly()
        {
            string msg = "Message 1";
            Func<string> msgFunc = () => msg;
            var rule = ValitRules<Model>.Create()
                .Ensure(m => m.NullRefProperty, _ => _
                    .Required()
                    .WithMessage(msgFunc))
                .For(_model);
            var result = rule.Validate();

            result.ErrorMessages.ShouldContain(msg);

            msg = "New message";
            result = rule.Validate();
            result.ErrorMessages.ShouldContain(msg);
        }

        [Fact]
        public void Property_WithMessage_Is_Not_Added_For_Valid_Check_If_When_Is_Not_Satisfied()
        {
            var result = ValitRules<Model>.Create()
                .Ensure(m => m.RefProperty, _ => _
                    .Required()
                    .When(m => false)
                    .WithMessage("Arrrgh"))
                .For(_model)
                .Validate();

            result.ErrorMessages.ShouldNotContain("Arrrgh");
        }

        [Fact]
        public void Property_WithMessage_Is_Added_For_Not_Valid_Check()
        {
            var result = ValitRules<Model>.Create()
                .Ensure(m => m.NullRefProperty, _ => _
                    .Required()
                    .WithMessage("Arrrgh"))
                .For(_model)
                .Validate();

            result.ErrorMessages.ShouldContain("Arrrgh");
        }

        [Fact]
        public void Property_WithMessage_Is_Added_For_Not_Valid_Check_If_When_Is_Satisfied()
        {
            var result = ValitRules<Model>.Create()
                .Ensure(m => m.NullRefProperty, _ => _
                    .Required()
                    .When(m => true)
                    .WithMessage("Arrrgh"))
                .For(_model)
                .Validate();

            result.ErrorMessages.ShouldContain("Arrrgh");
        }

        [Fact]
        public void Property_WithMessage_Is_Not_Added_For_Not_Valid_Check_If_When_Is_Not_Satisfied()
        {
            var result = ValitRules<Model>.Create()
                .Ensure(m => m.NullRefProperty, _ => _
                    .Required()
                    .When(m => false)
                    .WithMessage("Arrrgh"))
                .For(_model)
                .Validate();

            result.ErrorMessages.ShouldNotContain("Arrrgh");
        }

        [Fact]
        public void Property_WithMessage_Returns_ProperResult()
        {
            var result = ValitRules<Model>.Create()
                .Ensure(m => m.NullRefProperty, _ => _
                    .Required()
                    .WithMessage("M1")
                    .WithMessage("M2"))
                .For(_model)
                .Validate();

            result.ErrorMessages.Count().ShouldBe(2);
        }

        private Model _model => new Model();

        class Model
        {
            public object RefProperty => new object();
            public object NullRefProperty => null;
        }
    }
}
