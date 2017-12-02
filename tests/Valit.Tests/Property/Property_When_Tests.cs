using Shouldly;
using Xunit;

namespace Valit.Tests.Property
{
    public class Property_When_Tests
    {
        [Fact]
        public void Property_When_Throws_When_Null_Rule_Is_Given()
        {
            var exception = Record.Exception(() => {
                ((IValitRule<Model, object>)null)
                    .When(_ => true);
            });

            exception.ShouldBeOfType(typeof(ValitException));
        }

        [Fact]
        public void Property_Required_When_Succeeds_When_Predicate_Is_Satisfied_And_Not_Null_Property_Is_Passed()
        {
            var result = ValitRules<Model>.Create()
                .Ensure(m => m.RefProperty, _ => _
                    .Required()
                    .When(m => true))
                .For(_model)
                .Validate();

            result.Succeeded.ShouldBe(true);
        }

        [Fact]
        public void Property_Required_When_Succeeds_When_Predicate_Is_Not_Satisfied_And_Not_Null_Property_Is_Passed()
        {
            var result = ValitRules<Model>.Create()
                .Ensure(m => m.RefProperty, _ => _
                    .Required()
                    .When(m => false))
                .For(_model)
                .Validate();

            result.Succeeded.ShouldBe(true);
        }

        [Fact]
        public void Property_Required_When_Fails_When_Predicate_Is_Satisfied_And_Null_Property_Is_Passed()
        {
            var result = ValitRules<Model>.Create()
                .Ensure(m => m.NullRefProperty, _ => _
                    .Required()
                    .When(m => true))
                .For(_model)
                .Validate();

            result.Succeeded.ShouldBe(false);
        }

        [Fact]
        public void Property_Required_When_Succeeds_When_Predicate_Is_Not_Satisfied_And_Null_Property_Is_Passed()
        {
            var result = ValitRules<Model>.Create()
                .Ensure(m => m.NullRefProperty, _ => _
                    .Required()
                    .When(m => false))
                .For(_model)
                .Validate();

            result.Succeeded.ShouldBe(true);
        }

        [Theory]
        [InlineData(false, false, true)]
        [InlineData(false, true, true)]
        [InlineData(true, false, true)]
        [InlineData(true, true, false)]
        public void Property_When_Returns_ProperResult(bool r1, bool r2, bool expected)
        {
            var result = ValitRules<Model>.Create()
                .Ensure(m => m.NullRefProperty, _ => _
                    .Required()
                    .When(m => r1)
                    .When(m => r2))
                .For(_model)
                .Validate();

            result.Succeeded.ShouldBe(expected);
        }

        private Model _model => new Model();

        class Model
        {
            public object RefProperty => new object();
            public object NullRefProperty => null;
        }
    }
}
