# SavePage

SavePage is a RESTful APIs client in C# applications for screenshot any website using SavePage.io

If you like this project please give a star and a cup of coffee =)

[!["Buy Me A Coffee"](https://www.buymeacoffee.com/assets/img/custom_images/orange_img.png)](https://www.buymeacoffee.com/nurzhanme)

## Installation

[![NuGet Badge](https://buildstats.info/nuget/SavePage)](https://www.nuget.org/packages/SavePage/)

To install SavePage, you can use the NuGet package manager in Visual Studio. Simply search for "SavePage" and click "Install".

Alternatively, you can install SavePage using the command line:

```
Install-Package SavePage
```

## Getting Started

Firstly obtain valid SavePage API key.

### Without using dependency injection:

```c#
var apiClient = new SavePageClient(new SavePageOptions()
{
    ApiKey = Environment.GetEnvironmentVariable("MY_API_KEY")
});
```

### Using dependency injection:

In your secrets.json or other settings.json

```json
"SavePageOptions": {
  //"ApiKey": "Your api key goes here",
  //"ApiBaseAddress": "Your api base address goes here"
},
```

#### Program.cs

```c#
serviceCollection.AddSavePageClient();
```

or using Environment Variable

```c#
serviceCollection.AddSavePageClient(settings => { settings.ApiKey = Environment.GetEnvironmentVariable("MY_API_KEY"); });
```

NOTE: do NOT put your API key directly to your source code.

After injecting your service you will be able to get it from service provider

```c#
var apiClient = serviceProvider.GetRequiredService<SavePageClient>();
```

or injecting in the constructor of your class

```c#
public class MyService
{
    private readonly SavePageClient _apiClient;

    public MyService(SavePageClient apiClient)
    {
        _apiClient = apiClient;
    }
}
```

## Logging and Exception handling

For diagnostic there are `DelegatingHandler`-s such as `LoggingHandler` and `ExceptionHandler`. You can always extend them