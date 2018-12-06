using Shouldly;
using Valit.Extensions;
using Xunit;

namespace Valit.Tests.Extensions
{
    public class FloatExtensions_Tests
    {
        [Theory]
        [InlineData(0f, 0f, 0f, true)]
        [InlineData(0f, 0f, float.Epsilon, true)]
        [InlineData(0f, float.Epsilon, 0f, false)]
        [InlineData(.1f, .11f, 0f, false)]
        [InlineData(.01f, .011f, .1f, true)]
        public void IsEqual_Returns_Proper_Results(float a, float b, float epsilon, bool expected)
        {
            a.IsEqual(b, epsilon).ShouldBe(expected);
        }

        [Theory]
        [InlineData(0f, 0f, 0f, false)]
        [InlineData(0f, 0f, float.Epsilon, false)]
        [InlineData(0f, .1f, 0f, true)]
        [InlineData(0f, .1f, float.Epsilon, true)]
        [InlineData(.01f, .011f, .1f, false)]
        public void IsNotEqual_Returns_Proper_Results(float a, float b, float epsilon, bool expected)
        {
            a.IsNotEqual(b, epsilon).ShouldBe(expected);
        }

        [Theory]
        [InlineData(0f, 0f, 0f, false)]
        [InlineData(0f, 0f, float.Epsilon, false)]
        [InlineData(.1f, 0.11f, 0f, false)]
        [InlineData(.1f, 0.11f, float.Epsilon, false)]
        [InlineData(.11f, 0.1f, 0f, true)]
        [InlineData(.11f, 0.1f, float.Epsilon, true)]
        public void IsGreaterThan_Returns_Proper_Results(float a, float b, float epsilon, bool expected)
        {
            a.IsGreaterThan(b, epsilon).ShouldBe(expected);
        }

        [Theory]
        [InlineData(0f, 0f, 0f, true)]
        [InlineData(0f, 0f, float.Epsilon, true)]
        [InlineData(.1f, 0f, 0f, true)]
        [InlineData(.1f, .100001f, .01f, true)]
        [InlineData(-.1f, 0f, 0f, false)]
        public void IsGreaterOrEqualThan_Returns_Proper_Results(float a, float b, float epsilon, bool expected)
        {
            a.IsGreaterOrEqualThan(b, epsilon).ShouldBe(expected);
        }

        [Theory]
        [InlineData(0f, 0f, 0f, false)]
        [InlineData(0f, 0f, float.Epsilon, false)]
        [InlineData(.1f, .2f, 0f, true)]
        [InlineData(.1f, .2f, float.Epsilon, true)]
        [InlineData(-.01f, 0f, 0f, true)]
        public void IsLessThan_Returns_Proper_Results(float a, float b, float epsilon, bool expected)
        {
            a.IsLessThan(b, epsilon).ShouldBe(expected);
        }

        [Theory]
        [InlineData(0f, 0f, 0f, true)]
        [InlineData(0f, 0f, float.Epsilon, true)]
        [InlineData(.1f, .11f, 0f, true)]
        [InlineData(.1f, .11f, float.Epsilon, true)]
        [InlineData(-.01f, 0f, 0f, true)]
        public void IsLessOrEqualThan_Returns_Proper_Results(float a, float b, float epsilon, bool expected)
        {
            a.IsLessOrEqualThan(b, epsilon).ShouldBe(expected);
        }
    }
}
