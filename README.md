# Blazor FacileBudget

Second version of the application designed for family budget management, developed with .NET 5 technology, Blazor WebAssembly, Entity Framework Core, SQLite database and distributable via docker

## Project creation

The project was created using the Visual Studio 2022 GUI and the **additional information** was configured as follows

![image](https://user-images.githubusercontent.com/49655304/154846570-41bc9cfe-7607-42a4-b28a-bee188506cbf.png)

## Structure of the project

```
●-- Blazor.FacileBudget.Server
|
●-- Blazor.FacileBudget.Client
|
●-- Blazor.FacileBudget.Shared
```

### Additional Libraries

```
●-- Blazor.FacileBudget.Components
|
●-- Blazor.FacileBudget.DataAccess
|
●-- Blazor.FacileBudget.Models
```

### Additional Packages

```
●-- BlazorKit.Spinners
|
●-- MudBlazor
```

## Scaffolding Database

To perform the scaffolding it is necessary to open the package management console and use the command: **Add-Migration Initial-Migration**

Subsequently, to apply the newly created migration to the database it is necessary to use the command: **Update-Database**

The scaffolding of the database must be performed from the Package Management Console, making sure that the default project (drop-down menu) is **Blazor.FacileBudget.DataAccess**

## Deploy via docker

After launching the publish command **dotnet publish -c Release**

Before publishing via docker, it is necessary to check the presence of the **_framework** folder and the javascript files **service-worker.js** and **service-worker-assets.js** in the **wwwroot** folder.

If these are not present, it is possible to integrate them with a simple copy and paste from the Blazor project directory: **Blazor.FacileBudget\Client\bin\Release\net5.0\wwwroot**

If these files are omitted for some reason, the application will not be visible / available while browsing from the browser and the fixed message **loading...** will remain.

## License

[![MIT License](https://img.shields.io/apm/l/atomic-design-ui.svg?)](https://github.com/tterb/atomic-design-ui/blob/master/LICENSEs)

## Badges

[![GitHub build and test](https://github.com/AngeloDotNet/Blazor.FacileBudget/actions/workflows/github_build_and_test.yml/badge.svg)](https://github.com/AngeloDotNet/Blazor.FacileBudget/actions/workflows/github_build_and_test.yml)
