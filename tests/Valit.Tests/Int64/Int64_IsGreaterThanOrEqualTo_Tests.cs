using Shouldly;
using Xunit;

namespace Valit.Tests.Int64
{
    public class Int64_IsGreaterThanOrEqualTo_Tests
    {
        [Fact]
        public void Int64_IsGreaterThanOrEqualTo_For_Not_Nullable_Values_Throws_When_Null_Rule_Is_Given()
        {
            var exception = Record.Exception(() => {
                ((IValitRule<Model, long>)null)
                    .IsGreaterThanOrEqualTo(1);
            });

            exception.ShouldBeOfType(typeof(ValitException));
        }

        [Fact]
        public void Int64_IsGreaterThanOrEqualTo_For_Not_Nullable_Value_And_Nullable_Value_Throws_When_Null_Rule_Is_Given()
        {
            var exception = Record.Exception(() => {
                ((IValitRule<Model, long>)null)
                    .IsGreaterThanOrEqualTo((long?)1);
            });

            exception.ShouldBeOfType(typeof(ValitException));
        }

        [Fact]
        public void Int64_IsGreaterThanOrEqualTo_For_Nullable_Value_And_Not_Nullable_Value_Throws_When_Null_Rule_Is_Given()
        {
            var exception = Record.Exception(() => {
                ((IValitRule<Model, long?>)null)
                    .IsGreaterThanOrEqualTo(1);
            });

            exception.ShouldBeOfType(typeof(ValitException));
        }

        [Fact]
        public void Int64_IsGreaterThanOrEqualTo_For_Nullable_Values_Throws_When_Null_Rule_Is_Given()
        {
            var exception = Record.Exception(() => {
                ((IValitRule<Model, long?>)null)
                    .IsGreaterThanOrEqualTo((long?)1);
            });

            exception.ShouldBeOfType(typeof(ValitException));
        }


        [Theory]
        [InlineData(9, true)]
        [InlineData(10, true)]
        [InlineData(11, false)]
        public void Int64_IsGreaterThanOrEqualTo_Returns_Proper_Results_For_Not_Nullable_Values(long value,  bool expected)
        {
            IValitResult result = ValitRules<Model>
                .Create()
                .Ensure(m => m.Value, _=>_
                    .IsGreaterThanOrEqualTo(value))
                .For(_model)
                .Validate();

            result.Succeeded.ShouldBe(expected);
        }

        [Theory]
        [InlineData((long) 9, true)]
        [InlineData((long) 10, true)]
        [InlineData((long) 11, false)]
        [InlineData(null, false)]
        public void Int64_IsGreaterThanOrEqualTo_Returns_Proper_Results_For_Not_Nullable_Value_And_Nullable_Value(long? value,  bool expected)
        {
            IValitResult result = ValitRules<Model>
                .Create()
                .Ensure(m => m.Value, _=>_
                    .IsGreaterThanOrEqualTo(value))
                .For(_model)
                .Validate();

            result.Succeeded.ShouldBe(expected);
        }

        [Theory]
        [InlineData(false, 9, true)]
        [InlineData(false, 10, true)]
        [InlineData(false, 11, false)]
        [InlineData(true, 9, false)]
        public void Int64_IsGreaterThanOrEqualTo_Returns_Proper_Results_For_Nullable_Value_And_Not_Nullable_Value(bool useNullValue, long value,  bool expected)
        {
            IValitResult result = ValitRules<Model>
                .Create()
                .Ensure(m => useNullValue? m.NullValue : m.NullableValue, _=>_
                    .IsGreaterThanOrEqualTo(value))
                .For(_model)
                .Validate();

            result.Succeeded.ShouldBe(expected);
        }

        [Theory]
        [InlineData(false, (long) 9, true)]
        [InlineData(false, (long) 10, true)]
        [InlineData(false, (long) 11, false)]
        [InlineData(false, null, false)]
        [InlineData(true, (long) 9, false)]
        [InlineData(true, null, false)]
        public void Int64_IsGreaterThanOrEqualTo_Returns_Proper_Results_For_Nullable_Values(bool useNullValue, long? value,  bool expected)
        {
            IValitResult result = ValitRules<Model>
                .Create()
                .Ensure(m => useNullValue? m.NullValue : m.NullableValue, _=>_
                    .IsGreaterThanOrEqualTo(value))
                .For(_model)
                .Validate();

            result.Succeeded.ShouldBe(expected);
        }

#region ARRANGE
        public Int64_IsGreaterThanOrEqualTo_Tests()
        {
            _model = new Model();
        }

        private readonly Model _model;

        class Model
        {
            public long Value => 10;
            public long? NullableValue => 10;
            public long? NullValue => null;
        }
#endregion
    }
}
