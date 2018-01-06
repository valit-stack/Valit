using Shouldly;
using Xunit;

namespace Valit.Tests.Property
{
    public class Property_WithDefaultMessage_Tests
    {
        [Fact]
        public void DefaultMessage_Is_Added_If_No_ErrorMessage_Is_Given()
        {
            var result = ValitRules<Model>.Create()
                .Ensure(m => m.Value, _ => _
                    .IsNegative())
                .Ensure(m => m.NullValue, _ => _
                    .Required())
                .For(_model)
                .Validate();

            result.ErrorMessages.Length.ShouldBe(2);
        }

        [Fact]
        public void DefaultMessage_Is_Overriten_If_ErrorMessage_Is_Given()
        {
            var result = ValitRules<Model>.Create()
                .Ensure(m => m.Value, _ => _
                    .IsNegative()
                    .WithMessage("1"))
                .Ensure(m => m.NullValue, _ => _
                    .Required()
                    .WithMessage("2"))
                .For(_model)
                .Validate();

            result.ErrorMessages.Length.ShouldBe(2);
            result.ErrorMessages.ShouldContain("1");
            result.ErrorMessages.ShouldContain("2");
        }

        public Property_WithDefaultMessage_Tests()
        {
            _model = new Model();
        }

        private readonly Model _model;

        class Model
        {
            public int Value => 12;
            public object NullValue => null;
        }
    }
}