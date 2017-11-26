using System;
using Shouldly;
using Xunit;

namespace Valit.Tests.Boolean
{
  public class Boolean_IsTrue_Tests
  {
    [Fact]
    public void Boolean_IsTrue_For_Not_Nullable_Value_Throws_When_Null_Rule_Is_Given()
    {
      var exception = Record.Exception(() =>
      {
        ((IValitRule<Model, bool>)null)
            .IsTrue();
      });

      exception.ShouldBeOfType(typeof(ValitException));
    }

    [Fact]
    public void Boolean_IsTrue_For_Nullable_Value_Throws_When_Null_Rule_Is_Given()
    {
      var exception = Record.Exception(() =>
      {
        ((IValitRule<Model, bool?>)null)
            .IsTrue();
      });

      exception.ShouldBeOfType(typeof(ValitException));
    }

    [Theory]
    [InlineData(true, true)]
    [InlineData(false, false)]
    public void Boolean_IsTrue_Returns_Proper_Results_For_Not_Nullable_Values(bool useTrueValue, bool expected)
    {
      IValitResult result = ValitRules<Model>
          .Create()
          .Ensure(m => useTrueValue ? m.TrueValue : m.FalseValue, _ => _
              .IsTrue())
          .For(_model)
          .Validate();

      Assert.Equal(result.Succeeded, expected);
    }

    [Theory]
    [InlineData(true, true)]
    [InlineData(false, false)]
    public void Boolean_IsTrue_Returns_Proper_Results_For_Nullable_Values(bool useTrueValue, bool expected)
    {
      IValitResult result = ValitRules<Model>
          .Create()
          .Ensure(m => useTrueValue ? m.NullableTrueValue : m.NullableFalseValue, _ => _
              .IsTrue())
          .For(_model)
          .Validate();

      Assert.Equal(result.Succeeded, expected);
    }

    [Fact]
    public void Boolean_IsTrue_Fails_For_Null_Value()
    {
      IValitResult result = ValitRules<Model>
          .Create()
          .Ensure(m => m.NullValue, _ => _
              .IsTrue())
          .For(_model)
          .Validate();

      Assert.Equal(result.Succeeded, false);
    }


    #region ARRANGE
    public Boolean_IsTrue_Tests()
    {
      _model = new Model();
    }

    private readonly Model _model;

    class Model
    {
      public bool TrueValue => true;
      public bool FalseValue => false;
      public bool? NullableTrueValue => true;
      public bool? NullableFalseValue => false;
      public bool? NullValue => null;
    }
    #endregion
  }
}