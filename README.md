![Valit](https://avatars1.githubusercontent.com/u/32653478?s=200&v=4)

Valit is **dead simple** validation for .NET Core. No more if-statements all around your code. Write nice and clean **fluent validators** instead! 

|   | master  | develop  |
|---|--------|----------|
|AppVeyor|[![Build status](https://ci.appveyor.com/api/projects/status/github/valit-stack/Valit?branch=master&svg=true&passingText=master%20passing&failingText=master%20failing&pendingText=master%20pending)](https://ci.appveyor.com/project/GooRiOn/valit/branch/master)|[![Build status](https://ci.appveyor.com/api/projects/status/github/valit-stack/Valit?branch=develop&svg=true&passingText=develop%20passing&failingText=develop%20failing&pendingText=develop%20pending)](https://ci.appveyor.com/project/GooRiOn/valit/branch/develop)|
|Codecov|[![codecov](https://codecov.io/gh/valit-stack/valit/branch/master/graph/badge.svg)](https://codecov.io/gh/valit-stack/valit/branch/master)|[![codecov](https://codecov.io/gh/valit-stack/valit/branch/develop/graph/badge.svg)](https://codecov.io/gh/valit-stack/valit/branch/develop)|

![NuGet](https://img.shields.io/nuget/v/Valit.svg)


# Installation
Valit is available on [NuGet](https://www.nuget.org/packages/Valit/).

### Package manager
```bash
Install-Package Valit -Version 0.2.0
```

### .NET CLI
```bash
dotnet add package Valit --version 0.2.0
```

# Getting started
In order to create a validator you need to go through few steps. It's worth mentioning that not all of them are mandatory. The steps are: 

- creating new instance of validator using ``Create()`` static method.
- choosing [validation strategy](http://valitdocs.readthedocs.io/en/latest/strategies/index.html) using ``WithStrategy()`` method **(not required)**.
- selecting property using ``Ensure()`` method and defining rules for it. 
- Extending rules with [custom errors](http://valitdocs.readthedocs.io/en/latest/validation-errors/index.html) (such as messages or error codes), [tags and conditions](http://valitdocs.readthedocs.io/en/latest/validation-rules/index.html). **(not required)**.
- applying created rules to an object using ``For()`` method.

Having the validator created, simply invoke ``Validate()`` method which will produce the result with all the data.

Let's try it out with very practical example. Imagine that you're task is to validate model sent from registration page of your app. The example object might look as follows:

```cs

    public class RegisterModel
    {
        public string Email { get; set; }        
        public string Password { get; set; }
        public ushort Age { get; set ;}
    }
```

These are the validation criteria:

- ``Email`` is required and needs to be a proper email address
- ``Password`` is required and needs to be at least 10 characters long
- ``Age`` must be greater than 16


This is how you can handle such scenario using Valit:
  
```cs

        void ValidateModel(RegisterModel model)
        {
            var result = ValitRules<RegisterModel>
                .Create()
                .Ensure(m => m.Email, _=>_
                    .Required()
                    .Email())
                .Ensure(m => m.Password, _=>_ 
                    .Required()
                    .MinLength(10))
                .Ensure(m => m.Age, _=>_
                    .IsGreaterThan(16))
                .For(model)
                .Validate();

            if(result.Succeeded)
            {
                // do something on success
            }
            else 
            {
                // do something on failure
            }
        }
```

Pretty cool, right? Of course, the above example was fairly simple but trust us. From now on, even complicated validation criterias won't scare you anymore ;)

# Documentation
If you're looking for documentation, you can find it [here](http://valitdocs.readthedocs.io/en/latest/index.html).

# Contributing
Want to help us develop Valit? Awesome! Here you can find [contributor guide](https://github.com/valit-stack/Valit/blob/develop/CONTRIBUTING.md) ;)
