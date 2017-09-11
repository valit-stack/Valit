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
                .Ensure(m => m.StringValue, _=>_
                    .Required()
                    .WithMessage("This is my error message")
                    .Matches(@"\d+")
                    .WithMessage("This is my error message")
                .Ensure(m => m.Email, _=>_
                    .Email()
                    .WithMessage("This is my error message"))
                .Ensure(m => m.NumberValue, _=>_
                    .IsGreaterThan(100)
                    .WithMessage("This is my error message")
                    .IsLessThan(0)
                    .WithMessage("This is my error message"))
                .Ensure(m => m.ReferenceValue, _=>_
                    .IsEqualTo(Guid.NewGuid())
                    .WithMessage"This is my error message")
                    .Satisifes(p => p != Guid.Empty)
                    .WithMessage("This is my error message"))
                .Validate();

            if(!result.Succeeded)
            {
                foreach (var error in result.Errors)
                    Console.WriteLine(error);
            }
        }
    }
```