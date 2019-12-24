using Shouldly;
using Valit.Extensions;
using Xunit;

namespace Valit.Tests.Extensions
{
    public class DoubleExtensions_IsNearlyEqual_Tests
    {
        private const double DefinedEpsilon = 0.00001f;

        [Theory(DisplayName = "Regular large numbers")]
        [InlineData(1000000d, 1000001d, true)]
        [InlineData(1000001d, 1000000d, true)]
        [InlineData(10000d, 10001d, false)]
        [InlineData(10001d, 10000d, false)]
        public void Double_IsEqual_Returns_Proper_Result_For_BigNumbers(double a, double b, bool expected)
        {
            a.IsEqual(b, DefinedEpsilon).ShouldBe(expected);
        }

        [Theory(DisplayName = "Negative large numbers")]
        [InlineData(-1000000d, -1000001d, true)]
        [InlineData(-1000001d, -1000000d, true)]
        [InlineData(-10000d, -10001d, false)]
        [InlineData(-10001d, -10000d, false)]
        public void Double_IsEqual_Returns_Proper_Results_For_Negative_BigNumbers(double a, double b, bool expected)
        {
            a.IsEqual(b, DefinedEpsilon).ShouldBe(expected);
        }

        [Theory(DisplayName = "Numbers around 1")]
        [InlineData(1.0000001d, 1.0000002d, true)]
        [InlineData(1.0000002d, 1.0000001d, true)]
        [InlineData(1.0002d, 1.0001d, false)]
        [InlineData(1.0001d, 1.0002d, false)]
        public void Double_IsEqual_Returns_Proper_Results_For_Numbers_Around_1(double a, double b, bool expected)
        {
            a.IsEqual(b, DefinedEpsilon).ShouldBe(expected);
        }

        [Theory(DisplayName = "Numbers around -1")]
        [InlineData(-1.000001d, -1.000002d, true)]
        [InlineData(-1.000002d, -1.000001d, true)]
        [InlineData(-1.0001d, -1.0002d, false)]
        [InlineData(-1.0002d, -1.0001d, false)]
        public void Double_IsEqual_Returns_Proper_Results_For_Numbers_Around_Minus1(double a, double b, bool expected)
        {
            a.IsEqual(b, DefinedEpsilon).ShouldBe(expected);
        }

        [Theory(DisplayName = "Numbers between 1 and 0")]
        [InlineData(0.000000001000001d, 0.000000001000002d, true)]
        [InlineData(0.000000001000002d, 0.000000001000001d, true)]
        [InlineData(0.000000000001002d, 0.000000000001001d, false)]
        [InlineData(0.000000000001001d, 0.000000000001002d, false)]
        public void Double_IsEqual_Returns_Proper_Results_For_Numbers_Between_1_and_0(double a, double b, bool expected)
        {
            a.IsEqual(b, DefinedEpsilon).ShouldBe(expected);
        }

        [Theory(DisplayName = "Numbers between -1 and 0")]
        [InlineData(-0.000000001000001d, -0.000000001000002d, true)]
        [InlineData(-0.000000001000002d, -0.000000001000001d, true)]
        [InlineData(-0.000000000001002d, -0.000000000001001d, false)]
        [InlineData(-0.000000000001001d, -0.000000000001002d, false)]
        public void Double_IsEqual_Returns_Proper_Results_For_Numbers_Between_Minus1_and_0(double a, double b, bool expected)
        {
            a.IsEqual(b, DefinedEpsilon).ShouldBe(expected);
        }

        [Theory(DisplayName = "Small differences away from zero")]
        [InlineData(0.3d, 0.30000003d, true)]
        [InlineData(-0.3d, -0.30000003d, true)]
        public void Double_IsEqual_Returns_Proper_Results_For_Small_Differences_Away_From_Zero(double a, double b, bool expected)
        {
            a.IsEqual(b, DefinedEpsilon).ShouldBe(expected);
        }

        [Theory(DisplayName = "Comparisons involving zero")]
        [InlineData(0.0d, 0.0d, DefinedEpsilon, true)]
        [InlineData(0.0d, -0.0d, DefinedEpsilon, true)]
        [InlineData(-0.0d, -0.0d, DefinedEpsilon, true)]
        [InlineData(0.00000001d, 0.0d, DefinedEpsilon, false)]
        [InlineData(0.0d, 0.00000001d, DefinedEpsilon, false)]
        [InlineData(-0.00000001d, 0.0d, DefinedEpsilon, false)]
        [InlineData(0.0d, -0.00000001d, DefinedEpsilon, false)]
        [InlineData(0.0d, 1e-310d, 0.01d, true)]
        [InlineData(1e-310d, 0.0d, 0.01d, true)]
        [InlineData(1e-310d, 0.0d, 0.000001d, false)]
        [InlineData(0.0d, 1e-310d, 0.000001d, false)]
        [InlineData(0.0d, -1e-310d, 0.1d, true)]
        [InlineData(-1e-310d, 0.0d, 0.1d, true)]
        [InlineData(-1e-310d, 0.0d, 0.00000001d, false)]
        [InlineData(0.0d, -1e-310d, 0.00000001d, false)]
        public void Double_IsEqual_Returns_Proper_Results_For_Zero(double a, double b, double epsilon, bool expected)
        {
            a.IsEqual(b, epsilon).ShouldBe(expected);
        }

        [Theory(DisplayName = "Comparisons involving extreme values (overflow potential)")]
        [InlineData(double.MaxValue, double.MaxValue, true)]
        [InlineData(double.MaxValue, -double.MaxValue, false)]
        [InlineData(-double.MaxValue, double.MaxValue, false)]
        [InlineData(double.MaxValue, double.MaxValue / 2, false)]
        [InlineData(double.MaxValue, -double.MaxValue / 2, false)]
        [InlineData(-double.MaxValue, double.MaxValue / 2, false)]
        public void Double_IsEqual_Returns_Proper_Results_For_Extreme_Values(double a, double b, bool expected)
        {
            a.IsEqual(b, DefinedEpsilon).ShouldBe(expected);
        }

        [Theory(DisplayName = "Comparisons involving infinities")]
        [InlineData(double.PositiveInfinity, double.PositiveInfinity, true)]
        [InlineData(double.NegativeInfinity, double.NegativeInfinity, true)]
        [InlineData(double.NegativeInfinity, double.PositiveInfinity, false)]
        [InlineData(double.PositiveInfinity, double.MaxValue, false)]
        [InlineData(double.NegativeInfinity, -double.MaxValue, false)]
        public void Double_IsEqual_Returns_Proper_Results_For_Infinities(double a, double b, bool expected)
        {
            a.IsEqual(b, DefinedEpsilon).ShouldBe(expected);
        }

        [Theory(DisplayName = "Comparisons involving NaN values")]
        [InlineData(double.NaN, double.NaN, false)]
        [InlineData(double.NaN, 0.0d, false)]
        [InlineData(-0.0d, double.NaN, false)]
        [InlineData(double.NaN, -0.0d, false)]
        [InlineData(0.0d, double.NaN, false)]
        [InlineData(double.NaN, double.PositiveInfinity, false)]
        [InlineData(double.PositiveInfinity, double.NaN, false)]
        [InlineData(double.NaN, double.NegativeInfinity, false)]
        [InlineData(double.NegativeInfinity, double.NaN, false)]
        [InlineData(double.NaN, double.MaxValue, false)]
        [InlineData(double.MaxValue, double.NaN, false)]
        [InlineData(double.NaN, -double.MaxValue, false)]
        [InlineData(-double.MaxValue, double.NaN, false)]
        [InlineData(double.NaN, double.Epsilon, false)]
        [InlineData(double.Epsilon, double.NaN, false)]
        [InlineData(double.NaN, -double.Epsilon, false)]
        [InlineData(-double.Epsilon, double.NaN, false)]
        public void Double_IsEqual_Returns_Proper_Results_For_NaN_Values(double a, double b, bool expected)
        {
            a.IsEqual(b, DefinedEpsilon).ShouldBe(expected);
        }

        [Theory(DisplayName = "Comparisons of numbers on opposite sides of 0")]
        [InlineData(1.000000001d, -1.0d, false)]
        [InlineData(-1.0d, 1.000000001d, false)]
        [InlineData(-1.000000001d, 1.0d, false)]
        [InlineData(1.0d, -1.000000001d, false)]
        [InlineData(10 * double.Epsilon, 10 * -double.Epsilon, true)]
        public void Double_IsEqual_Returns_Proper_Results_For_Number_On_Opposite_Sides_Of_Zero(double a, double b, bool expected)
        {
            a.IsEqual(b, DefinedEpsilon).ShouldBe(expected);
        }

        [Theory(DisplayName = "Comparisons of numbers very close to zero")]
        [InlineData(double.Epsilon, double.Epsilon, true)]
        [InlineData(double.Epsilon, -double.Epsilon, true)]
        [InlineData(-double.Epsilon, double.Epsilon, true)]
        [InlineData(double.Epsilon, 0, true)]
        [InlineData(0, double.Epsilon, true)]
        [InlineData(-double.Epsilon, 0, true)]
        [InlineData(0, -double.Epsilon, true)]
        [InlineData(0.000000001d, -double.Epsilon, false)]
        [InlineData(0.000000001d, double.Epsilon, false)]
        [InlineData(double.Epsilon, 0.000000001d, false)]
        [InlineData(-double.Epsilon, 0.000000001d, false)]
        public void Double_IsEqual_Returns_Proper_Results_For_Number_Very_Close_To_Zero(double a, double b, bool expected)
        {
            a.IsEqual(b, DefinedEpsilon).ShouldBe(expected);
        }
    }
}
