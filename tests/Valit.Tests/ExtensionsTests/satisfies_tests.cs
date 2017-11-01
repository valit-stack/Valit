using System;
using Shouldly;
using Valit;
using Xunit;

namespace Valit.Tests.ExtensionsTests
{
    public class satisfies_tests
    {
        [Fact]
        public void valitResult_is_succeed_if_all_satisifes_are_satisfied()
        {
            var result = ValitRules<Model>
                .Create()
                .WithStrategy(x => x.Complete)
                .Ensure(model => model.StringValue, _=>_
                    .Satisfies(p => !System.String.IsNullOrWhiteSpace(p)).MinLength(4))
                .Ensure(model => model.GuidValue, _=>_ 
                    .Satisfies(p => p != Guid.Empty))
                .Ensure(model => model.IntegerValue, _=>_
                    .Satisfies(p => p > 0))
                .Ensure(model => model.BooleanValue, _=>_
                    .Satisfies(p => p))
                .For(_model)
                .Validate();
            
            Assert.Equal(result.Succeeded, true);
        }

        [Fact]
        public void valitResult_is_false_if_at_least_one_satisfies_is_false()
        {
            var result = ValitRules<Model>
                .Create()
                .WithStrategy(x => x.Complete)
                .Ensure(model => model.StringValue, _=>_
                    .Satisfies(p => !System.String.IsNullOrWhiteSpace(p)))
                .Ensure(model => model.GuidValue, _=>_ 
                    .Satisfies(p => p != Guid.Empty))
                .Ensure(model => model.IntegerValue, _=>_
                    .Satisfies(p => p > 0))
                .Ensure(model => model.BooleanValue, _=>_
                    .Satisfies(p => p == false))
                .For(_model)
                .Validate();
            
            Assert.Equal(result.Succeeded, false);
        }

        [Fact]
        public void satisifes_throws_if_rule_is_null()
        {
            var fakeValitRule = ((IValitRule<object, bool>)null);
            var exception = Record.Exception(() => 
            {
                fakeValitRule.Satisfies(p => p);
            });

            exception.ShouldBeOfType(typeof(ValitException));
        }

        [Fact]
        public void satisifes_throws_if_predicate_is_null()
        {
            var exception = Record.Exception(() => 
            {
                ValitRules<Model>
                .Create()
                .WithStrategy(x=>x.Complete)
                .Ensure(model => model.StringValue, _=>_
                    .Satisfies(null))
                .For(_model)
                .Validate();
            });

            exception.ShouldBeOfType(typeof(ValitException));
        }

        public satisfies_tests()
        {
            _model = new Model
            {
                StringValue = "Test string",
                GuidValue = Guid.NewGuid(),
                IntegerValue = 123,
                BooleanValue = true
            };
        }

        private readonly Model _model;

        private class Model
        {
            public string StringValue { get; set; }
            public Guid GuidValue { get; set; }
            public int IntegerValue { get; set;}
            public bool BooleanValue { get; set; }
        }
    }
}