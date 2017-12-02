using Xunit;
using Shouldly;
using System;

namespace Valit.Tests.Guid_
{
    public class Guid_IsEqualTo_Tests
    {
        [Fact]
        public void Guid_IsEqualTo_For_Not_Nullable_Values_Throws_When_Null_Rule_Is_Given()
        {
            var exception = Record.Exception(() => {
                ((IValitRule<Model, Guid>)null)
                    .IsEqualTo(Guid.NewGuid());
            });

            exception.ShouldBeOfType(typeof(ValitException));
        }

        [Fact]
        public void Guid_IsEqualTo_For_Not_Nullable_Value_And_Nullable_Value_Throws_When_Null_Rule_Is_Given()
        {
            var exception = Record.Exception(() => {
                ((IValitRule<Model, Guid>)null)
                    .IsEqualTo((Guid?)Guid.NewGuid());
            });

            exception.ShouldBeOfType(typeof(ValitException));
        }

        [Fact]
        public void Guid_IsEqualTo_For_Nullable_Value_And_Not_Nullable_Value_Throws_When_Null_Rule_Is_Given()
        {
            var exception = Record.Exception(() => {
                ((IValitRule<Model, Guid?>)null)
                    .IsEqualTo(Guid.NewGuid());
            });

            exception.ShouldBeOfType(typeof(ValitException));
        }

        [Fact]
        public void Guid_IsEqualTo_For_Nullable_Values_Throws_When_Null_Rule_Is_Given()
        {
            var exception = Record.Exception(() => {
                ((IValitRule<Model, Guid?>)null)
                    .IsEqualTo((Guid?)Guid.NewGuid());
            });

            exception.ShouldBeOfType(typeof(ValitException));
        }

        [Theory]
        [InlineData("6f72f4ab-c2fc-4fca-b70e-b5ac7eccd054", true)]
        [InlineData("7dca6d8e-255c-401c-b701-f18af9b2e191", false)]
        public void Guid_IsEqualTo_Returns_Proper_Result_For_Left_Value(string strValue, bool expected)
        {
            Guid value = Guid.Parse(strValue);

            IValitResult result = ValitRules<Model>
                .Create()
                .Ensure(m => m.Value, _ => _
                    .IsEqualTo(value))
                .For(_model)
                .Validate();

            result.Succeeded.ShouldBe(expected);
        }

        [Theory]
        [InlineData("7dca6d8e-255c-401c-b701-f18af9b2e191", false)]
        [InlineData("6f72f4ab-c2fc-4fca-b70e-b5ac7eccd054", true)]
        [InlineData("5c7ad720-6813-4c45-89c9-c4484bbbc34d", false)]
        public void Guid_IsEqualTo_Returns_Proper_Result_For_Nullable_Left_Value(string strValue, bool expected)
        {
            Guid value = Guid.Parse(strValue);

            var result = ValitRules<Model>
                .Create()
                .Ensure(m => m.NullableValue, _ => _
                    .IsEqualTo(value))
                .For(_model)
                .Validate();

            result.Succeeded.ShouldBe(expected);
        }

        [Theory]
        [InlineData("7dca6d8e-255c-401c-b701-f18af9b2e191", false)]
        [InlineData("6f72f4ab-c2fc-4fca-b70e-b5ac7eccd054", false)]
        [InlineData("5c7ad720-6813-4c45-89c9-c4484bbbc34d", false)]
        public void Guid_IsEqualTo_Returns_Proper_Result_For_Null_Left_Value(string strValue, bool expected)
        {
            Guid value = Guid.Parse(strValue);

            var result = ValitRules<Model>
                .Create()
                .Ensure(m => m.NullValue, _ => _
                    .IsEqualTo(value))
                .For(_model)
                .Validate();

            result.Succeeded.ShouldBe(expected);
        }

        [Theory]
        [InlineData("7dca6d8e-255c-401c-b701-f18af9b2e191", false)]
        [InlineData("6f72f4ab-c2fc-4fca-b70e-b5ac7eccd054", true)]
        [InlineData("5c7ad720-6813-4c45-89c9-c4484bbbc34d", false)]
        [InlineData("", false, true)]
        public void Guid_IsEqualTo_Returns_Proper_Result_For_Nullable_Right_Value(string strValue, bool expected, bool useNull = false)
        {
            Guid? value = useNull ? (Guid?)null : Guid.Parse(strValue);

            var result = ValitRules<Model>
                .Create()
                .Ensure(m => m.Value, _ => _
                    .IsEqualTo(value))
                .For(_model)
                .Validate();

            result.Succeeded.ShouldBe(expected);
        }

        [Theory]
        [InlineData("7dca6d8e-255c-401c-b701-f18af9b2e191", false)]
        [InlineData("6f72f4ab-c2fc-4fca-b70e-b5ac7eccd054", true)]
        [InlineData("5c7ad720-6813-4c45-89c9-c4484bbbc34d", false)]
        [InlineData("", false, true)]
        public void Guid_IsEqualTo_Returns_Proper_Result_For_Nullable_Values(string strValue, bool expected, bool useNull = false)
        {
            Guid? value = useNull ? (Guid?)null : Guid.Parse(strValue);

            var result = ValitRules<Model>
                .Create()
                .Ensure(m => m.NullableValue, _ => _
                    .IsEqualTo(value))
                .For(_model)
                .Validate();

            result.Succeeded.ShouldBe(expected);
        }

#region ARRANGE
        public Guid_IsEqualTo_Tests()
        {
            _model = new Model();

        }

        private readonly Model _model;

        class Model
        {
            public Guid? NullableValue => System.Guid.Parse("6f72f4ab-c2fc-4fca-b70e-b5ac7eccd054");
            public Guid Value => System.Guid.Parse("6f72f4ab-c2fc-4fca-b70e-b5ac7eccd054");
            public Guid? NullValue => null;
        }
#endregion
    }
}
