using Shouldly;
using Xunit;

namespace Valit.Tests.String
{
    public class String_Required_Tests
    {

        [Fact]
        public void String_Required_For_Nullable_Value_Throws_When_Null_Rule_Is_Given()
        {
            var exception = Record.Exception(() => {
                ((IValitRule<Model, string>)null)
                    .Required();
            });
            
            exception.ShouldBeOfType(typeof(ValitException));
        }


        [Theory]
        [InlineData(false, true)]
        [InlineData(true, false)] 
        public void Int64_Required_Returns_Proper_Results_For_Nullable_Value(bool useNullValue,  bool expected)
        {            
            IValitResult result = ValitRules<Model>
                .Create()
                .Ensure(m => useNullValue? m.NullValue : m.Value, _=>_
                    .Required())
                .For(_model)
                .Validate();

            Assert.Equal(result.Succeeded, expected);
        }

#region ARRANGE
        public String_Required_Tests()
        {
            _model = new Model();
        }

        private readonly Model _model;

        class Model
        {
            public string EmptyValue => string.Empty;
            public string Value => "text";
            public string NullValue => null;
        }
#endregion  
    }
}