using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Valit.Tests.Strategies
{
    public class Complete
    {
        [Fact]
        public void Complete_Strategy_Checks_All_Ensure()
        {
            var result = ValitRules<Model>.Create()
                .WithStrategy(_ => _.Complete)
                .Ensure(m => m.Age, _ => _
                    .IsPositive()
                    .WithMessage(M1))
                .Ensure(m => m.FirstName, _ => _
                    .Required()
                    .WithMessage(M2)
                    .MinLength(3)
                    .WithMessage(M3))
                .Ensure(m => m.LastName, _ => _
                    .Required()
                    .WithMessage(M4)
                    .MinLength(5)
                    .WithMessage(M5))
                .Ensure(m => m.Email, _ => _
                    .Required()
                    .WithMessage(M6)
                    .Email()
                    .WithMessage(M7))
                .For(_model)
                .Validate();

            result.Succeeded.ShouldBe(false);
            result.ErrorMessages.Count().ShouldBe(6);
            result.ErrorMessages.ShouldContain(M1);
            result.ErrorMessages.ShouldContain(M3);
            result.ErrorMessages.ShouldContain(M4);
            result.ErrorMessages.ShouldContain(M5);
            result.ErrorMessages.ShouldContain(M7);
        }

#region ARRANGE

        const string M1 = "Our framework doesn't support future born babies";
        const string M2 = "Name is required";
        const string M3 = "Name shorter than 3 are not supported";
        const string M4 = "Lastname is required";
        const string M5 = "Lastname shorter than 3 are not supported";
        const string M6 = "Email is required";
        const string M7 = "Invalid email";

        Model _model => new Model();

        class Model
        {
            public int Age => -1;
            public string FirstName => "";
            public string LastName => null;
            public string Email => "a@a";
        }
#endregion
    }
}
