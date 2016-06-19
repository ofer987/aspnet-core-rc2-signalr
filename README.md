# ASP.NET Core RC2 with SignalR

Full template for ASP.NET Core app with SignalR.

Based on template using Semantic UI generated with Yeoman (yo) using generator-aspnet.

Learned from sample found in the SignalR repository: https://github.com/aspnet/SignalR-Server/tree/master/samples/SignalRSample.Web

**Warning**: SignalR has been officially released and is as of yet subject to change.

## Prerequisites

Get .NET SDK RC2 - SDK Preview 1 (or later): https://www.microsoft.com/net

As for IDE there are two alternatives:

1. Visual Studio 2015 with updated tooling (Windows only)
2. Visual Studio Code (X-plat)

Xamarin Studio/MonoDevlop will eventually support .NET Core.

## Instructions

To run the sample:

    dotnet restore
    dotnet run

Open http://localhost:5000/Test in your web browser.

If you are registered and signed in and clicking the "Poke" button then the text above it will change.

### Database

Create the database using migrations (default: SQLite)

    dotnet ef migrations add InitialMigration
    dotnet ef database update

## Notes

Since the latest "stable" build of SignalR server has a bug with resolving hubs, the project references a package from a third-party source providing a fix.

More on the fix here: https://stackoverflow.com/questions/37475825/upgrading-to-rc2-with-signalr-3-0-results-in-invalidoperationexception-progre

### Reference the SignalR server fix
Add this to NuGet.config:

```
<add key="Code Comb" value="https://www.myget.org/F/codecomb-rc2/api/v3/index.json" />
```

Add this dependency to package.json:

```
"Microsoft.AspNetCore.SignalR.Server": "0.1.0-rc2-final",
```

## Tests

To run tests, navigate to src/WebApplication.Tests and run this command:

```dotnet test```

## Use SignalR in an app

It is easy to use SignalR in an app.

The .NET client is part of the "Microsoft.AspNet.SignalR.Client" package on NuGet.

This code is the direct equivalent to JavaScript code in this project. 

```CSharp
var connection = new HubConnection("http://localhost:5000");
IHubProxy test = connection.CreateHubProxy("Test");
test.On<string>("Test", (data) =>
{
    Dispatcher.Invoke(() =>
    {
        label.Content = data;
    });
});
connection.Start().Wait();
```
