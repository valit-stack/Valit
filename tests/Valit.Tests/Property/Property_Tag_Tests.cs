using Xunit;
using Shouldly;
using System.Linq;

namespace Valit.Tests.Property
{
    public class Property_Tag_Tests
    {

        [Fact]
        public void Property_Tag_Throws_When_Null_Rule_Is_Given()
        {
            var exception = Record.Exception(() => {
                ((IValitRule<Model, object>)null)
                    .Tag("");
            });

            exception.ShouldBeOfType(typeof(ValitException));
        }

        [Fact]
        public void Property_Tag_Throws_When_Null_Tags_Set_Is_Given()
        {
            var exception = Record.Exception(() => {
                ValitRules<Model>
                    .Create()
                    .Ensure(m => m.Value1, _=>_
                        .Tag(null))
                    .For(_model)
                    .Validate();
            });

            exception.ShouldBeOfType(typeof(ValitException));
        }


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
        [InlineData(new [] { "Tag1" }, true)]
        [InlineData(new [] { "Tag2" }, true)]
        [InlineData(new [] { "Tag1", "Tag2" }, true)]
        [InlineData(new [] { "Tag1", "Tag3" }, false)]
        [InlineData(new [] { "Tag2", "Tag3" }, false)]
        [InlineData(new [] { "Tag3" }, false)]
        public void ValitRules_Validate_With_Params_Should_Return_Proper_Result_Based_On_Given_Tags_Set(string[] tags, bool expected)
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
                .Validate(tags);

            Assert.Equal(result.Succeeded, expected);
        }

        [Theory]
        [InlineData(new [] { "Tag1" }, true)]
        [InlineData(new [] { "Tag2" }, true)]
        [InlineData(new [] { "Tag1", "Tag2" }, true)]
        [InlineData(new [] { "Tag1", "Tag3" }, false)]
        [InlineData(new [] { "Tag2", "Tag3" }, false)]
        [InlineData(new [] { "Tag3" }, false)]
        public void ValitRules_Validate_With_Predicate_Should_Return_Proper_Result_Based_On_Given_Tags_Set(string[] tags, bool expected)
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
                .Validate(r => r.Tags.Intersect(tags).Any());

            Assert.Equal(result.Succeeded, expected);
        }

        [Fact]
        public void ValitRules_Create_Should_Properly_Add_Given_Rules()
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

            var newRules = ValitRules<Model>
                .Create(rules)
                .GetAllRules();

            newRules.Count().ShouldBe(3);
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
