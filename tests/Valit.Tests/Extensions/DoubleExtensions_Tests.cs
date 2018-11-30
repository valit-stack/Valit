using Shouldly;
using Valit.Extensions;
using Xunit;

namespace Valit.Tests.Extensions
{
    public class DoubleExtensions_Tests
    {
        [Theory]
        [InlineData(0d, 0d, 0d, true)]
        [InlineData(0d, 0d, double.Epsilon, true)]
        [InlineData(0d, double.Epsilon, 0d, false)]
        [InlineData(.1d, .11d, 0d, false)]
        [InlineData(.01d, .011d, .1d, true)]
        public void IsEqualTo_Returns_Proper_Results(double a, double b, double epsilon, bool expected)
        {
            a.IsEqual(b, epsilon).ShouldBe(expected);
        }

        [Theory]
        [InlineData(0d, 0d, 0d, false)]
        [InlineData(0d, 0d, double.Epsilon, false)]
        [InlineData(0d, .1d, 0d, true)]
        [InlineData(0d, .1d, double.Epsilon, true)]
        [InlineData(.01d, .011d, .1d, false)]
        public void IsNotEqual_Returns_Proper_Results(double a, double b, double epsilon, bool expected)
        {
            a.IsNotEqual(b, epsilon).ShouldBe(expected);
        }

        [Theory]
        [InlineData(0d, 0d, 0d, false)]
        [InlineData(0d, 0d, double.Epsilon, false)]
        [InlineData(.1d, 0.11d, 0d, false)]
        [InlineData(.1d, 0.11d, double.Epsilon, false)]
        [InlineData(.11d, 0.1d, 0d, true)]
        [InlineData(.11d, 0.1d, double.Epsilon, true)]
        public void IsGreaterThan_Returns_Proper_Results(double a, double b, double epsilon, bool expected)
        {
            a.IsGreaterThan(b, epsilon).ShouldBe(expected);
        }

        [Theory]
        [InlineData(0d, 0d, 0d, true)]
        [InlineData(0d, 0d, double.Epsilon, true)]
        [InlineData(.1d, 0d, 0d, true)]
        [InlineData(.1d, .100001d, .01d, true)]
        [InlineData(-.1d, 0d, 0d, false)]
        public void IsGreaterOrEqualThan_Returns_Proper_Results(double a, double b, double epsilon, bool expected)
        {
            a.IsGreaterOrEqualThan(b, epsilon).ShouldBe(expected);
        }

        [Theory]
        [InlineData(0d, 0d, 0d, false)]
        [InlineData(0d, 0d, double.Epsilon, false)]
        [InlineData(.1d, .2d, 0d, true)]
        [InlineData(.1d, .2d, double.Epsilon, true)]
        [InlineData(-.01d, 0d, 0d, true)]
        public void IsLessThan_Returns_Proper_Results(double a, double b, double epsilon, bool expected)
        {
            a.IsLessThan(b, epsilon).ShouldBe(expected);
        }

        [Theory]
        [InlineData(0d, 0d, 0d, true)]
        [InlineData(0d, 0d, double.Epsilon, true)]
        [InlineData(.1d, .11d, 0d, true)]
        [InlineData(.1d, .11d, double.Epsilon, true)]
        [InlineData(-.01d, 0d, 0d, true)]
        public void IsLessOrEqualThan_Returns_Proper_Results(double a, double b, double epsilon, bool expected)
        {
            a.IsLessOrEqualThan(b, epsilon).ShouldBe(expected);
        }
    }
}
