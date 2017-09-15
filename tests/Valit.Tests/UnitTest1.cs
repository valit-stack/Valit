using System;
using Valit.Extensions;
using Valit.Rules;
using Xunit;

namespace Valit.Tests
{
    public class UnitTest1
    {
        class Model
        {
            public string a = "123";
            public int b = 123;
        }
        [Fact]
        public void Test1()
        {
            var a = new Model();
            var r = ValitRules<Model>
                .For(a)
                .Ensure(m => m.b, _ => _
                    .IsGreaterThan(100))
                .Validate();
            Assert.Equal(r.Succeeded, true);
        }
    }
}
