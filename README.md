# ASP.NET Core RC2 with SignalR

Based on template using Semantic UI generated with Yeoman (yo) using generator-aspnet.

Looked at the sample found in the SignalR repository: https://github.com/aspnet/SignalR-Server/tree/master/samples/SignalRSample.Web

**Warning**: SignalR has been officially released and is as of yet subject to change.

## Prerequisites

* Requires .NET SDK RC2 - SDK Preview 1 (or later)
* Visual Studio 2015 with tooling - or just Visual Studio Code 

## Instructions

To run the sample:

    dotnet restore
    dotnet run

Open http://localhost:5000/Test in your web browser.

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
