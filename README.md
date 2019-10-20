# Easy Model Validator in C-Sharp

This article will explain a cool way of validating a model or any object by using 
the Validation attributes 
To validate a Model in MVC you make use of 
[Model Validation Attributes](https://docs.microsoft.com/en-us/aspnet/core/mvc/models/validation?view=aspnetcore-3.0)
like this

```c#
class ContactModel
{
[Required, RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
    @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
    @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$",
ErrorMessage = "Email Format Error")]

public string Email { get; set; }

[Required] public string Name { get; set; }

}

```

and then you will validate it like this

```c#
public class ContactController : Controller
    {
        [HttpPost]
        public async IActionResult AddContact(ConatctModel model)
        {
            if (!ModelState.IsValid){
               // throw new Exception("Model Failed") 
            }

            //The model is valid 
            //do your logic here
        }
    }
```

but what if you want to use the ContactModel class in your own logic and not 
in the MVC Controller but still you may need to validate the model before usage 
or maybe you have a normal POCO class and you want to validate that in clean
way in a scenario like this 


```c#
public class ContactHelper
    {
        public void ContactHandler(ContactModel model)
        {
            if (!model.IsValid){
               // throw new Exception("Model Failed") 
            }

            //The model is valid 
            //do your logic here
        }
    }
```

this was the motivation to create the EasyModelValidatorExtension which can help
you validate any object by simply adding the validation attributes in that object

```c#
 public static class EasyModelValidatorExtension
     {
        public static bool IsValid<T>(this T model)
        {
            try
            {
                var vc = new ValidationContext(model, null, null);
                var result = Validator.TryValidateObject(model, vc, null, true);
                return result;
            }
            catch (Exception e)
            {
                throw new ModelValidationException("Model Validation has Failed", e);
        }
     }
}
```

you can add this extension in your project or simply use [EasyModelValidator](https://www.nuget.org/packages/EasyModelValidator/) Nuget 

```
dotnet add package EasyModelValidator
OR 
Install-Package EasyModelValidator

```

you can find the Source code [here](https://github.com/alicommit-malp/com.appelinda.nuget.easyModelValidation)

Happy coding :)



