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
                .Ensure(m => m.NullValue, _=>_
                    .Required()
                    .Tag("Tag2"))
                .GetAllRules();

            rules.Count().ShouldBe(3);
        }

        [Fact]
        public void ValitRules_GetTaggedRules_Returns_Correct_Number_Of_Rules()
        {
            var rules = ValitRules<Model>
                .Create()
                .Ensure(m => m.Value1, _=>_
                    .Email()
                    .Tag("Tag1"))
                .Ensure(m => m.Value2, _=>_
                    .Email())
                .Ensure(m => m.NullValue, _=>_
                    .Required()
                    .Tag("Tag2"))
                .GetTaggedRules();

            rules.Count().ShouldBe(2);
        }

        [Fact]
        public void ValitRules_GetUntaggedRules_Returns_Correct_Number_Of_Rules()
        {
            var rules = ValitRules<Model>
                .Create()
                .Ensure(m => m.Value1, _=>_
                    .Email()
                    .Tag("Tag1"))
                .Ensure(m => m.Value2, _=>_
                    .Email())
                .Ensure(m => m.NullValue, _=>_
                    .Required()
                    .Tag("Tag2"))
                .GetUntaggedRules();

            rules.Count().ShouldBe(1);
        }

        [Theory]
        [InlineData("Tag1", true)]
        [InlineData("Tag2", true)]      
        [InlineData("Tag3", false)]      
        public void ValitRules_Validate_With_Params_Should_Return_Proper_Result_Based_On_Given_Tags_Set(string tag, bool expected)
        {
            var result = ValitRules<Model>
                .Create()
                .Ensure(m => m.Value1, _=>_
                    .Required()
                    .Tag("Tag1"))
                .Ensure(m => m.Value2, _=>_
                    .Required()
                    .Tag("Tag2"))
                .Ensure(m => m.NullValue, _=>_
                    .Required()
                    .Tag("Tag3"))
                .For(_model)
                .Validate(new []{ tag });

            Assert.Equal(result.Succeeded, expected);
        }


        private Model _model => new Model();

        class Model
        {
            public string Value1 => "Text";
            public string Value2 => "Text";
            public string NullValue => null;
            
        }
    }
}