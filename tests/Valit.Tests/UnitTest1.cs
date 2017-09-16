using System;
using System.Collections.Generic;
using Valit.Enums;
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
            public List<int> c = new List<int> {1,2,3};
        }

        [Fact]
        public void Test1()
        {
            var a = new Model();
            var r = ValitRules<Model>
                .For(a)
                .WithStrategy(ValitRulesStrategies.Complete)
                .Ensure(m => a.c, _ => _
                    .MinItems(2))
                .Validate();
            Assert.Equal(r.Succeeded, true);
        }
    }
}
