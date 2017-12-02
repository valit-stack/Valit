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


        [Fact]
        public void String_Required_Fails_For_Null_Value()
        {            
            IValitResult result = ValitRules<Model>
                .Create()
                .Ensure(m => m.NullValue, _=>_
                    .Required())
                .For(_model)
                .Validate();

            Assert.False(result.Succeeded);
        }

        [Fact]
        public void String_Required_Fails_For_Empty_Value()
        {            
            IValitResult result = ValitRules<Model>
                .Create()
                .Ensure(m => m.NullValue, _=>_
                    .Required())
                .For(_model)
                .Validate();

            Assert.False(result.Succeeded);
        }

        [Fact]
        public void String_Required_Succeeds_For_Not_Empty_Value()
        {            
            IValitResult result = ValitRules<Model>
                .Create()
                .Ensure(m => m.Value, _=>_
                    .Required())
                .For(_model)
                .Validate();

            Assert.True(result.Succeeded);
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