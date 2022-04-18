
# Blazor Facile Budget

Second version of the application designed for family budget management, developed with .NET 6 technology and distributable via docker.


## Features

- No server required
- Portable program
- Cross platform
## Tech Stack

**Client:** Blazor, Bootstrap 4.3

**Server:** Blazor, .NET 6

**Database:** SQLite


## Documentation

To perform the scaffolding it is necessary to open the package management console and use the command: **Add-Migration Initial-Migration**

Subsequently, to apply the newly created migration to the database it is necessary to use the command: **Update-Database**

The scaffolding of the database must be performed from the Package Management Console, making sure that the default project (drop-down menu) is **Blazor.FacileBudget.DataAccess**
## Deployment

After launching the publish command

```bash
  dotnet publish -c Release
```

but before publishing via docker, it is necessary to check the presence of the **_framework** folder and the javascript files **service-worker.js** and **service-worker-assets.js** in the **wwwroot** folder.

If these are not present, it is possible to integrate them with a simple copy and paste from the Blazor project directory **Blazor.FacileBudget\Client\bin\Release\net6.0\wwwroot**

If these files are omitted for some reason, the application will not be visible / available while browsing from the browser and the fixed message **loading...** will remain.
## Run Locally

Clone the project

```bash
  git clone https://github.com/AngeloDotNet/Blazor.FacileBudget
```

Go to the project directory

```bash
  cd src
```

Build the project

```bash
  dotnet build
```

Start the server

```bash
  dotnet run
```


## Contributing

Contributions are always welcome!

## Badges

[![GitHub build and test](https://github.com/AngeloDotNet/Blazor.FacileBudget/actions/workflows/github_build_and_test.yml/badge.svg)](https://github.com/AngeloDotNet/Blazor.FacileBudget/actions/workflows/github_build_and_test.yml)


## Authors

- [@Angelo Pirola](https://www.github.com/AngeloDotNet)


## License

[![MIT License](https://img.shields.io/apm/l/atomic-design-ui.svg?)](https://github.com/tterb/atomic-design-ui/blob/master/LICENSEs)
