![Valit](https://user-images.githubusercontent.com/7096476/30515930-b9b1fec6-9b31-11e7-8569-f0b235645cb2.png)

Valit is **dead simple** validation for .NET Core. No more if-statements all around your code. Write nice and clean **fluent validators** instead! 

![buddy pipeline](https://app.buddy.works/dbarwikowski/valit/pipelines/pipeline/59491/badge.svg?token=953e81953165d3197c4cddb689ba703aa25d1ad60c18fc12aa68a0c0238eb28c "buddy pipeline")

## Basic Usage
Valit offers plenty different validation rules to use, such as:
- **Satisfies()**
- **Required()**
- **IsEqualTo()**
- **IsGreaterThan()**
- **IsLessThan()**
- **MinLength()**
- **MaxLength()**
- **Matches()**
- **MinItems()**
- **MaxItems()**
- **Email()**

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
                .WithStrategy(ValitRulesStrategies.Complete)
                .Ensure(m => m.StringValue, _=>_
                    .Required()
                    .Matches(@"\d+"))
                .Ensure(m => m.Email, _=>_
                    .Email())
                .Ensure(m => m.NumberValue, _=>_
                    .IsGreaterThan(100)
                    .IsLessThan(0))
                .Ensure(m => m.ReferenceValue, _=>_
                    .IsEqualTo(Guid.NewGuid())
                    .Satisfies(p => p != Guid.Empty))
                .Validate();

            if(!result.Succeeded)
            {
                // do something
            }
        }
    }
```

You can also apply set of rules on each element inside the collection:

```cs
    public class Model
    {
        public IEnumerable<string> StringCollection { get; set; }
    }

    public class Test
    {
        public void Validate()
        {
            var model = new Model();

            var result = ValitRules<Model>
                .For(model)
                .WithStrategy(ValitRulesStrategies.Complete)
                .EnsureFor(m => m.StringCollection, _=>_
                    .Required()
                    .Matches(@"\d+"))
                .Validate();

            if(!result.Succeeded)
            {
                // do something
            }
        }
    }
```

## Adding messages
Besides the final result, you can also extend your validation with error messages as follows:

```cs
    public class Model
    {
        public string StringValue { get; set; }
    }

    public class Test
    {
        public void Validate()
        {
            var model = new Model();

            var result = ValitRules<Model>
                .For(model)
                .WithStrategy(ValitRulesStrategies.Complete)
                .Ensure(m => m.StringValue, _=>_
                    .Required()
                    .WithMessage("StringValue is required!"))
                .Validate();

            if(!result.Succeeded)
            {
                foreach(var error in result.Errors)
                    Console.WriteLine(error);
            }
        }
    }
```

## Validation strategies
In some scenarios, you might not need the entire model to be checked because of performance issues or model complexity. Valit offers two different strategies you can aplly:
- **Complete** - validates entire model
- **FailFast** - valides until first error is reached

```cs
    public class Model
    {
        public string StringValue { get; set; }
        public int IntegerValue { get; set; }
    }

    public class Test
    {
        public void Validate()
        {
            var model = new Model();

            var result = ValitRules<Model>
                .For(model)
                .WithStrategy(ValitRulesStrategies.FailFast)
                .Ensure(m => m.StringValue, _=>_
                    .Required()
                    .WithMessage("StringValue is required!"))
                .Ensure(m => m.IntegerValue, _=>_
                    .Required()
                    .WithMessage("This message won't be reached!"))
                .Validate();
        }
    }
```

## Validation conditions
Each validation rule can be combined with plenty different conditions which may affect the final result. To apply new condition use **When()** extensions as follows:

```cs
    public class Model
    {        
        public int IntegerValue => 3;
        public bool BooleanValue { get; set; }
    }

    public class Test
    {
        public void Validate()
        {
            var model = new Model();

            var result = ValitRules<Model>
                .For(model)
                .WithStrategy(ValitRulesStrategies.FailFast)
                .Ensure(m => m.IntegerValue, _=>_
                    .IsLessThan(5)
                    .When(() => model.BooleanValue)
                .Validate();
        }
    }
```

It's worth to mention that you can apply as much **When()** conditions as you want. If so, they will be merged in one condition using **AND (&&) operator**.