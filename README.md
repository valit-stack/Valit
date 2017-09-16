![Valit](https://user-images.githubusercontent.com/7096476/30515930-b9b1fec6-9b31-11e7-8569-f0b235645cb2.png)

Valit is **dead simple** validation for .NET Core. No more if-statements all around your code. Write nice and clean **fluent validators** instead! 

![buddy pipeline](https://app.buddy.works/dbarwikowski/valit/pipelines/pipeline/59491/badge.svg?token=953e81953165d3197c4cddb689ba703aa25d1ad60c18fc12aa68a0c0238eb28c "buddy pipeline")

## Usage

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