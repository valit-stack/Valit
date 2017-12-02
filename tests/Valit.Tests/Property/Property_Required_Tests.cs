using Shouldly;
using Xunit;

namespace Valit.Tests.Property
{
    public class Property_Required_Tests
    {
        [Fact]
        public void Property_Required_Throws_When_Null_Rule_Is_Given()
        {
            var exception = Record.Exception(() => {
                ((IValitRule<Model, object>)null)
                    .Required();
            });

            exception.ShouldBeOfType(typeof(ValitException));
        }

        [Fact]
        public void Property_Required_Succeeds_For_Not_Null_Property()
        {
            var result = ValitRules<Model>.Create()
                .Ensure(m => m.RefProperty, _ => _
                    .Required())
                .For(_model)
                .Validate();

            result.Succeeded.ShouldBe(true);
        }

        [Fact]
        public void Property_Required_SFails_For_Null_Property()
        {
            var result = ValitRules<Model>.Create()
                .Ensure(m => m.NullRefProperty, _ => _
                    .Required())
                .For(_model)
                .Validate();

            result.Succeeded.ShouldBe(false);
        }

        private Model _model => new Model();

        class Model
        {
            public object RefProperty => new object();
            public object NullRefProperty => null;
        }
    }
}
