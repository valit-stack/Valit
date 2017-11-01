using Xunit;
using Shouldly;
using System.Linq;

namespace Valit.Tests.Property
{
    public class Property_Tag_Tests
    {
        
        [Fact]
        public void ValitRules_GetAllRules_Returns_Correct_Number_Of_Rules()
        {
            var rules = ValitRules<Model>
                .Create()
                .Ensure(m => m.Value1, _=>_
                    .Email()
                    .Tag("Tag1"))
                .Ensure(m => m.Value2, _=>_
                    .Email())
                .Ensure(m => m.Value2, _=>_
                    .Required()
                    .Tag("Tag2"))
                .GetAllRules();

            rules.Count().ShouldBe(3);
        }


        private Model _model => new Model();

        class Model
        {
            public string Value1 => string.Empty;
            public string Value2 => string.Empty;
            public string Value3 => string.Empty;
        }
    }
}