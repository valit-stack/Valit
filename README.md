# Valit

Valit is simple fluent validator for .NET Core

### Usage

```cs
    public class Model
    {
        public string StringValue { get; set; }
        public string Email { get; set; }
        public int NumberValue { get; set; }
        public Guid ReferenceValue { get; set; }
    }

    public class Test
    {
        public void Validate()
        {
            var model = new Model();

            var result = ValitRules<Model>
                .For(model)
                .Ensure(m => m.StringValue, _ => _
                    .Required()
                    .WithMessage($"{nameof(Model.StringValue)} is required")
                    .Matches(@"\d+")
                    .WithMessage($"{nameof(Model.StringValue)} is incorrect"))
                .Ensure(m => m.Email, _ => _
                    .Email()
                    .WithMessage($"{nameof(Model.Email)} is incorrect email"))
                .Ensure(m => m.NumberValue, _ => _
                    .IsGreaterThan(100)
                    .WithMessage($"{nameof(Model.NumberValue)} is not greater than 100")
                    .IsLessThan(0)
                    .WithMessage($"{nameof(Model.NumberValue)} is not less than 100"))
                .Ensure(m => m.ReferenceValue, _ => _
                    .IsEqualTo(Guid.NewGuid())
                    .WithMessage($"{nameof(Model.ReferenceValue)} is incorrect")
                    .Satisifes(p => p != Guid.Empty)
                    .WithMessage($"{nameof(Model.ReferenceValue)} is empty"))
                .Validate();

            if(!result.Succeeded)
            {
                foreach (var error in result.Errors)
                    Console.WriteLine(error);
            }
        }
    }
```