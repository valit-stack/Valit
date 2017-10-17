![Valit](https://user-images.githubusercontent.com/7096476/30515930-b9b1fec6-9b31-11e7-8569-f0b235645cb2.png)

Valit is **dead simple** validation for .NET Core. No more if-statements all around your code. Write nice and clean **fluent validators** instead! 

[![Build status](https://ci.appveyor.com/api/projects/status/github/valit-stack/Valit?branch=master&svg=true&passingText=master%20passing&failingText=master%20failing&pendingText=master%20pending)](https://ci.appveyor.com/project/GooRiOn/valit/branch/master)

[![Build status](https://ci.appveyor.com/api/projects/status/github/valit-stack/Valit?branch=develop&svg=true&passingText=master%20passing&failingText=master%20failing&pendingText=master%20pending)](https://ci.appveyor.com/project/GooRiOn/valit/branch/develop)

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
                .Create()
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
                .For(model)
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
                .Create()                
                .Ensure(m => m.StringValue, _=>_
                    .Required()
                    .WithMessage("StringValue is required!"))
                .For(model)
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
                .Create()
                .WithStrategy(ValitRulesStrategies.FailFast)
                .Ensure(m => m.StringValue, _=>_
                    .Required()
                    .WithMessage("StringValue is required!"))
                .Ensure(m => m.IntegerValue, _=>_
                    .Required()
                    .WithMessage("This message won't be reached!"))
                .For(model)
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
                .Create()
                .Ensure(m => m.IntegerValue, _=>_
                    .IsLessThan(5)
                    .When(model => model.BooleanValue)
                .For(model)
                .Validate();
        }
    }
```

It's worth to mention that you can apply as much **When()** conditions as you want. If so, they will be merged in one condition using logical **AND** operation.
