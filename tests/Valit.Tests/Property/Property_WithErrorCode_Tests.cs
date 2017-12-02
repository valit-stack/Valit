using Shouldly;
using System.Linq;
using Xunit;

namespace Valit.Tests.Property
{
    public class Property_WithErrorCode_Tests
    {
        [Fact]
        public void Property_WithErrorCode_Throws_WithErrorCode_Null_Rule_Is_Given()
        {
            var exception = Record.Exception(() => {
                ((IValitRule<Model, object>)null)
                    .WithErrorCode(1);
            });

            exception.ShouldBeOfType(typeof(ValitException));
        }

        [Fact]
        public void Property_WithErrorCode_Is_Not_Added_For_Valid_Check()
        {
            var result = ValitRules<Model>.Create()
                .Ensure(m => m.RefProperty, _ => _
                    .Required()
                    .WithErrorCode(1))
                .For(_model)
                .Validate();

            result.ErrorCodes.ShouldNotContain(1);
        }

        [Fact]
        public void Property_WithErrorCode_Is_Not_Added_For_Valid_Check_If_When_Is_Satisfied()
        {
            var result = ValitRules<Model>.Create()
                .Ensure(m => m.RefProperty, _ => _
                    .Required()
                    .When(m => true)
                    .WithErrorCode(1))
                .For(_model)
                .Validate();

            result.ErrorCodes.ShouldNotContain(1);
        }

        [Fact]
        public void Property_WithErrorCode_Is_Not_Added_For_Valid_Check_If_When_Is_Not_Satisfied()
        {
            var result = ValitRules<Model>.Create()
                .Ensure(m => m.RefProperty, _ => _
                    .Required()
                    .When(m => false)
                    .WithErrorCode(1))
                .For(_model)
                .Validate();

            result.ErrorCodes.ShouldNotContain(1);
        }

        [Fact]
        public void Property_WithErrorCode_Is_Added_For_Not_Valid_Check()
        {
            var result = ValitRules<Model>.Create()
                .Ensure(m => m.NullRefProperty, _ => _
                    .Required()
                    .WithErrorCode(1))
                .For(_model)
                .Validate();

            result.ErrorCodes.ShouldContain(1);
        }

        [Fact]
        public void Property_WithErrorCode_Is_Added_For_Not_Valid_Check_If_When_Is_Satisfied()
        {
            var result = ValitRules<Model>.Create()
                .Ensure(m => m.NullRefProperty, _ => _
                    .Required()
                    .When(m => true)
                    .WithErrorCode(1))
                .For(_model)
                .Validate();

            result.ErrorCodes.ShouldContain(1);
        }

        [Fact]
        public void Property_WithErrorCode_Is_Not_Added_For_Not_Valid_Check_If_When_Is_Not_Satisfied()
        {
            var result = ValitRules<Model>.Create()
                .Ensure(m => m.NullRefProperty, _ => _
                    .Required()
                    .When(m => false)
                    .WithErrorCode(1))
                .For(_model)
                .Validate();

            result.ErrorCodes.ShouldNotContain(1);
        }

        [Fact]
        public void Property_WithErrorCode_Returns_ProperResult()
        {
            var result = ValitRules<Model>.Create()
                .Ensure(m => m.NullRefProperty, _ => _
                    .Required()
                    .WithErrorCode(1)
                    .WithErrorCode(2))
                .For(_model)
                .Validate();

            result.ErrorCodes.Count().ShouldBe(2);
        }

        private Model _model => new Model();

        class Model
        {
            public object RefProperty => new object();
            public object NullRefProperty => null;
        }
    }
}
