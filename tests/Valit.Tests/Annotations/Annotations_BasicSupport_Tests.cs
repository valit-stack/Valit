
using System.ComponentModel.DataAnnotations;
using Xunit;

namespace Valit.Tests.Annotations
{
    public class Annotations_BasicSupport_Tests
    {
        [Fact]
        public void Annotations_Required()
        {
            {
                var model = new Model();

                IValitResult result = ValitRules.CreateFor(model)
                  .Ensure(m => m.NullableField, _ => _
                      .WithAnnotations())
                  .Validate();

                Assert.False(result.Succeeded);
            }

            {
                var model = new Model { NullableField = 7 };    

                IValitResult result = ValitRules.CreateFor(model)
                .Ensure(m => m.NullableField, _ => _
                    .WithAnnotations())
                .Validate();

                Assert.True(result.Succeeded);
            }

            {
                var model = new Model { StringProperty = "12345678901234567" };

                IValitResult result = ValitRules.CreateFor(model)
                .Ensure(m => m.StringProperty, _ => _
                    .WithAnnotations())
                .Validate();

                Assert.False(result.Succeeded);
            }
        }

        class Model
        {
            [Required]
            public int? NullableField;

            [StringLength(15, MinimumLength = 10)]
            public string StringProperty { get; set; } = "1234567890123";
        }
    }
}
