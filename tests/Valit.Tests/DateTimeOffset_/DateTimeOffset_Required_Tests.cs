using System;
using Shouldly;
using Valit.Tests.HelperExtensions;
using Xunit;

namespace Valit.Tests.DateTimeOffset_
{
    public class DateTimeOffset_Required_Tests
    {
        [Fact]
        public void DateTimeOffset_Required_For_Nullable_Value_Throws_When_Null_Rule_Is_Given()
        {
            var exception = Record.Exception(() => {
                ((IValitRule<Model, short?>)null)
                    .Required();
            });

            exception.ShouldBeOfType(typeof(ValitException));
        }


        [Theory]
        [InlineData(false, true)]
        [InlineData(true, false)]
        public void DateTimeOffset_Required_Returns_Proper_Results_For_Nullable_Value(bool useNullValue,  bool expected)
        {
            IValitResult result = ValitRules<Model>
                .Create()
                .Ensure(m => useNullValue? m.NullValue : m.NullableValue, _=>_
                    .Required())
                .For(_model)
                .Validate();

            result.Succeeded.ShouldBe(expected);
        }

#region ARRANGE
        public DateTimeOffset_Required_Tests()
        {
            _model = new Model();
        }

        private readonly Model _model;

        class Model
        {
            public DateTimeOffset? NullableValue => DateTimeOffset.Now;
            public DateTimeOffset? NullValue => null;
        }
#endregion
    }
}
