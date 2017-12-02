using System.Collections.Generic;
using Shouldly;
using Xunit;

namespace Valit.Tests.Enumerable
{
    public class Enumerable_MinItems_Tests
    {
        [Fact]
        public void Enumerable_MinItems_Throws_When_Null_Rule_Is_Given()
        {
            var exception = Record.Exception(() => {
                ((IValitRule<Model, IEnumerable<int>>)null)
                    .MinItems(1);
            });

            exception.ShouldBeOfType(typeof(ValitException));
        }

        [Fact]
        public void Enumerable_MinItems_Succeeds_If_ExpectedItemsNumber_Is_Less_Than_Number_Of_Items_In_Collection()
        {
            var result = ValitRules<Model>
                .Create()
                .Ensure(m => m.Collection, _=>_
                    .MinItems(1))
                .For(_model)
                .Validate();

            Assert.True(result.Succeeded);
        }

        [Fact]
        public void Enumerable_MinItems_Succeeds_If_ExpectedItemsNumber_Is_Equal_To_Number_Of_Items_In_Collection()
        {
            var result = ValitRules<Model>
                .Create()
                .Ensure(m => m.Collection, _=>_
                    .MinItems(3))
                .For(_model)
                .Validate();

            Assert.True(result.Succeeded);
        }

        [Fact]
        public void Enumerable_MinItems_Fails_If_ExpectedItemsNumber_Is_Greater_Than_Number_Of_Items_In_Collection()
        {
            var result = ValitRules<Model>
                .Create()
                .Ensure(m => m.Collection, _=>_
                    .MinItems(5))
                .For(_model)
                .Validate();

            Assert.False(result.Succeeded);
        }

        [Fact]
        public void Enumerable_MaxItems_Fails_If_Null_Collection_Is_Given()
        {
            var result = ValitRules<Model>
                .Create()
                .Ensure(m => m.NullCollection, _=>_
                    .MinItems(1))
                .For(_model)
                .Validate();

            Assert.False(result.Succeeded);
        }


#region ARRANGE
        public Enumerable_MinItems_Tests()
        {
            _model = new Model();
        }

        private readonly Model _model;

        class Model
        {
            public IEnumerable<int> Collection => new List<int> { 1, 2, 3 };
            public IEnumerable<int> NullCollection => null;
        }
#endregion
    }
}
