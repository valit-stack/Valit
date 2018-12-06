using Shouldly;
using Valit.Extensions;
using Xunit;

namespace Valit.Tests.Extensions
{
    public class FloatExtensions_IsNearlyEqual_Tests
    {
        private const float DefinedEpsilon = 0.00001f;

        [Theory(DisplayName = "Regular large numbers")]
        [InlineData(1000000f, 1000001f, true)]
        [InlineData(1000001f, 1000000f, true)]
        [InlineData(10000f, 10001f, false)]
        [InlineData(10001f, 10000f, false)]
        public void Float_IsEqual_Returns_Proper_Result_For_BigNumbers(float a, float b, bool expected)
        {
            a.IsEqual(b, DefinedEpsilon).ShouldBe(expected);
        }

        [Theory(DisplayName = "Negative large numbers")]
        [InlineData(-1000000f, -1000001f, true)]
        [InlineData(-1000001f, -1000000f, true)]
        [InlineData(-10000f, -10001f, false)]
        [InlineData(-10001f, -10000f, false)]
        public void Float_IsEqual_Returns_Proper_Results_For_Negative_BigNumbers(float a, float b, bool expected)
        {
            a.IsEqual(b, DefinedEpsilon).ShouldBe(expected);
        }

        [Theory(DisplayName = "Numbers around 1")]
        [InlineData(1.0000001f, 1.0000002f, true)]
        [InlineData(1.0000002f, 1.0000001f, true)]
        [InlineData(1.0002f, 1.0001f, false)]
        [InlineData(1.0001f, 1.0002f, false)]
        public void Float_IsEqual_Returns_Proper_Results_For_Numbers_Around_1(float a, float b, bool expected)
        {
            a.IsEqual(b, DefinedEpsilon).ShouldBe(expected);
        }

        [Theory(DisplayName = "Numbers around -1")]
        [InlineData(-1.000001f, -1.000002f, true)]
        [InlineData(-1.000002f, -1.000001f, true)]
        [InlineData(-1.0001f, -1.0002f, false)]
        [InlineData(-1.0002f, -1.0001f, false)]
        public void Float_IsEqual_Returns_Proper_Results_For_Numbers_Around_Minus1(float a, float b, bool expected)
        {
            a.IsEqual(b, DefinedEpsilon).ShouldBe(expected);
        }

        [Theory(DisplayName = "Numbers between 1 and 0")]
        [InlineData(0.000000001000001f, 0.000000001000002f, true)]
        [InlineData(0.000000001000002f, 0.000000001000001f, true)]
        [InlineData(0.000000000001002f, 0.000000000001001f, false)]
        [InlineData(0.000000000001001f, 0.000000000001002f, false)]
        public void Float_IsEqual_Returns_Proper_Results_For_Numbers_Between_1_and_0(float a, float b, bool expected)
        {
            a.IsEqual(b, DefinedEpsilon).ShouldBe(expected);
        }

        [Theory(DisplayName = "Numbers between -1 and 0")]
        [InlineData(-0.000000001000001f, -0.000000001000002f, true)]
        [InlineData(-0.000000001000002f, -0.000000001000001f, true)]
        [InlineData(-0.000000000001002f, -0.000000000001001f, false)]
        [InlineData(-0.000000000001001f, -0.000000000001002f, false)]
        public void Float_IsEqual_Returns_Proper_Results_For_Numbers_Between_Minus1_and_0(float a, float b, bool expected)
        {
            a.IsEqual(b, DefinedEpsilon).ShouldBe(expected);
        }

        [Theory(DisplayName = "Small differences away from zero")]
        [InlineData(0.3f, 0.30000003f, true)]
        [InlineData(-0.3f, -0.30000003f, true)]
        public void Float_IsEqual_Returns_Proper_Results_For_Small_Differences_Away_From_Zero(float a, float b, bool expected)
        {
            a.IsEqual(b, DefinedEpsilon).ShouldBe(expected);
        }

        [Theory(DisplayName = "Comparisons involving zero")]
        [InlineData(0.0f, 0.0f, DefinedEpsilon, true)]
        [InlineData(0.0f, -0.0f, DefinedEpsilon, true)]
        [InlineData(-0.0f, -0.0f, DefinedEpsilon, true)]
        [InlineData(0.00000001f, 0.0f, DefinedEpsilon, false)]
        [InlineData(0.0f, 0.00000001f, DefinedEpsilon, false)]
        [InlineData(-0.00000001f, 0.0f, DefinedEpsilon, false)]
        [InlineData(0.0f, -0.00000001f, DefinedEpsilon, false)]
        [InlineData(0.0f, 1e-40f, 0.01f, true)]
        [InlineData(1e-40f, 0.0f, 0.01f, true)]
        [InlineData(1e-40f, 0.0f, 0.000001f, false)]
        [InlineData(0.0f, 1e-40f, 0.000001f, false)]
        [InlineData(0.0f, -1e-40f, 0.1f, true)]
        [InlineData(-1e-40f, 0.0f, 0.1f, true)]
        [InlineData(-1e-40f, 0.0f, 0.00000001f, false)]
        [InlineData(0.0f, -1e-40f, 0.00000001f, false)]
        public void Float_IsEqual_Returns_Proper_Results_For_Zero(float a, float b, float epsilon, bool expected)
        {
            a.IsEqual(b, epsilon).ShouldBe(expected);
        }

        [Theory(DisplayName = "Comparisons involving extreme values (overflow potential)")]
        [InlineData(float.MaxValue, float.MaxValue, true)]
        [InlineData(float.MaxValue, -float.MaxValue, false)]
        [InlineData(-float.MaxValue, float.MaxValue, false)]
        [InlineData(float.MaxValue, float.MaxValue / 2, false)]
        [InlineData(float.MaxValue, -float.MaxValue / 2, false)]
        [InlineData(-float.MaxValue, float.MaxValue / 2, false)]
        public void Float_IsEqual_Returns_Proper_Results_For_Extreme_Values(float a, float b, bool expected)
        {
            a.IsEqual(b, DefinedEpsilon).ShouldBe(expected);
        }

        [Theory(DisplayName = "Comparisons involving infinities")]
        [InlineData(float.PositiveInfinity, float.PositiveInfinity, true)]
        [InlineData(float.NegativeInfinity, float.NegativeInfinity, true)]
        [InlineData(float.NegativeInfinity, float.PositiveInfinity, false)]
        [InlineData(float.PositiveInfinity, float.MaxValue, false)]
        [InlineData(float.NegativeInfinity, -float.MaxValue, false)]
        public void Float_IsEqual_Returns_Proper_Results_For_Infinities(float a, float b, bool expected)
        {
            a.IsEqual(b, DefinedEpsilon).ShouldBe(expected);
        }

        [Theory(DisplayName = "Comparisons involving NaN values")]
        [InlineData(float.NaN, float.NaN, false)]
        [InlineData(float.NaN, 0.0f, false)]
        [InlineData(-0.0f, float.NaN, false)]
        [InlineData(float.NaN, -0.0f, false)]
        [InlineData(0.0f, float.NaN, false)]
        [InlineData(float.NaN, float.PositiveInfinity, false)]
        [InlineData(float.PositiveInfinity, float.NaN, false)]
        [InlineData(float.NaN, float.NegativeInfinity, false)]
        [InlineData(float.NegativeInfinity, float.NaN, false)]
        [InlineData(float.NaN, float.MaxValue, false)]
        [InlineData(float.MaxValue, float.NaN, false)]
        [InlineData(float.NaN, -float.MaxValue, false)]
        [InlineData(-float.MaxValue, float.NaN, false)]
        [InlineData(float.NaN, float.Epsilon, false)]
        [InlineData(float.Epsilon, float.NaN, false)]
        [InlineData(float.NaN, -float.Epsilon, false)]
        [InlineData(-float.Epsilon, float.NaN, false)]
        public void Float_IsEqual_Returns_Proper_Results_For_NaN_Values(float a, float b, bool expected)
        {
            a.IsEqual(b, DefinedEpsilon).ShouldBe(expected);
        }

        [Theory(DisplayName = "Comparisons of numbers on opposite sides of 0")]
        [InlineData(1.000000001f, -1.0f, false)]
        [InlineData(-1.0f, 1.000000001f, false)]
        [InlineData(-1.000000001f, 1.0f, false)]
        [InlineData(1.0f, -1.000000001f, false)]
        [InlineData(10 * float.Epsilon, 10 * -float.Epsilon, true)]
        [InlineData(10000 * float.Epsilon, 10000 * -float.Epsilon, false)]
        public void Float_IsEqual_Returns_Proper_Results_For_Number_On_Opposite_Sides_Of_Zero(float a, float b, bool expected)
        {
            a.IsEqual(b, DefinedEpsilon).ShouldBe(expected);
        }

        [Theory(DisplayName = "Comparisons of numbers very close to zero")]
        [InlineData(float.Epsilon, float.Epsilon, true)]
        [InlineData(float.Epsilon, -float.Epsilon, true)]
        [InlineData(-float.Epsilon, float.Epsilon, true)]
        [InlineData(float.Epsilon, 0, true)]
        [InlineData(0, float.Epsilon, true)]
        [InlineData(-float.Epsilon, 0, true)]
        [InlineData(0, -float.Epsilon, true)]
        [InlineData(0.000000001f, -float.Epsilon, false)]
        [InlineData(0.000000001f, float.Epsilon, false)]
        [InlineData(float.Epsilon, 0.000000001f, false)]
        [InlineData(-float.Epsilon, 0.000000001f, false)]
        public void Float_IsEqual_Returns_Proper_Results_For_Number_Very_Close_To_Zero(float a, float b, bool expected)
        {
            a.IsEqual(b, DefinedEpsilon).ShouldBe(expected);
        }
    }
}
