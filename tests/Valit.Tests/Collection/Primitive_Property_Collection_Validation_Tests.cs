using System;
using System.Collections.Generic;
using System.Linq;
using Shouldly;
using Xunit;

namespace Valit.Tests.Collection
{
    public class Primitive_Property_Collection_Validation_Tests
    {
        
        [Fact]
        public void EnsureFor_Throws_When_Null_RuleFunc_Is_Given()
        {
            var exception = Record.Exception(() => {
                ValitRules<Model>
                    .Create()
                    .EnsureFor(m => m.InvalidValuesCollection, (Func<IValitRule<Model,string>,IValitRule<Model,string>>)null);
            });
            
            exception.ShouldBeOfType(typeof(ValitException));
        }

        [Fact]
        public void Validation_With_Complete_Strategy_Fails_When_Invalid_Collection_Is_Given()
        {
            var result = ValitRules<Model>
                .Create()
                .EnsureFor(m => m.InvalidValuesCollection, _=>_
                    .Required()
                        .WithMessage("One")
                    .Email()
                        .WithMessage("Two"))
                .For(_model)
                .Validate();
            
            Assert.False(result.Succeeded);
            result.ErrorMessages.Where(m => m == "One").Count().ShouldBe(1);
            result.ErrorMessages.Where(m => m == "Two").Count().ShouldBe(3);
        }

        [Fact]
        public void Validation_With_FailFast_Strategy_Fails_When_Invalid_Collection_Is_Given()
        {
            var result = ValitRules<Model>
                .Create()
                .WithStrategy(picker => picker.FailFast)
                .EnsureFor(m => m.InvalidValuesCollection, _=>_
                    .Required()
                        .WithMessage("One")
                    .Email()
                        .WithMessage("Two"))
                .For(_model)
                .Validate();
            
            Assert.False(result.Succeeded);
            result.ErrorMessages.Count().ShouldBe(1);
            result.ErrorMessages.First().ShouldBe("Two");
        }

        [Fact]
        public void Validation_With_Complete_Strategy_Succeeds_When_Valid_Collection_Is_Given()
        {
            var result = ValitRules<Model>
                .Create()
                .EnsureFor(m => m.ValidValuesCollection, _=>_
                    .Required()
                        .WithMessage("One")
                    .Email()
                        .WithMessage("Two"))
                .For(_model)
                .Validate();
            
            Assert.True(result.Succeeded);
        }

        [Fact]
        public void Validation_With_FailFast_Strategy_Succeeds_When_Valid_Collection_Is_Given()
        {
            var result = ValitRules<Model>
                .Create()
                .WithStrategy(picker => picker.FailFast)
                .EnsureFor(m => m.ValidValuesCollection, _=>_
                    .Required()
                        .WithMessage("One")
                    .Email()
                        .WithMessage("Two"))
                .For(_model)
                .Validate();
            
            Assert.True(result.Succeeded);
        }


#region ARRANGE
        private readonly Model _model;

        public Primitive_Property_Collection_Validation_Tests()
        {
            _model = new Model();
        }
        
        class Model
        {
            public IEnumerable<string> InvalidValuesCollection => new List<string>
            {
                "correct.email@test.com",
                "incorrect.email.com",
                null,
                "another@incorrect@email.com"
            };

            public IEnumerable<string> ValidValuesCollection => new List<string>
            {
                "correct.email@test.com",
                "another.correct.email@test.com"
            };
        }
#endregion
    }
}