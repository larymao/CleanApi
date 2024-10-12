# CleanApi

This is a template for an API using a streamlined verison of [Clean Architecture](https://github.com/jasontaylordev/CleanArchitecture) alongside .NET's [Minimal APIs](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/minimal-apis).

## Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0) - *[required]* 
This solution in built on it, you need to install it before building and running.

- [Docker](https://www.docker.com/products/docker-desktop) - *[optional]* 
If you want to build the Dockerfile you will need to install it.

- [Docker-Compose](https://docs.docker.com/compose/install) - *[optional]* 
If you want to launch this solution quickly via the docker-compose.yml you will need to install it.

## Installation

This is a [.NET template](https://www.nuget.org/packages/CleanApi.Solution.Template) and you can install it using the [dotnet new cli](https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-new). To install the lastest version of the template run the following command.

``` bash
dotnet new install CleanApi.Solution.Template
```

To create a new solution using this template run the following command

```bash
dotnet new cleanapi --name {YOUR_SOLUTION_NAMESPACE}
```

To learn more, run the following command:

```bash
dotnet new cleanapi --help
```

## Features

There are plenty of handy implementations of features throughout this solution, in no particular order here are some that might interest you.

- Authentication using [JWT Token](https://jwt.io/introduction)
- Data Storage using [Postgres](https://github.com/postgres/postgres)
- Data accessing using [EFCore](https://github.com/dotnet/efcore) with [Code First Mode](https://learn.microsoft.com/en-us/ef/core/managing-schemas/migrations)
- Object Mapping using [AutoMapper](https://github.com/AutoMapper/AutoMapper)
- Mediator Pattern using [MediatR](https://github.com/jbogard/MediatR)
- Validation using [FluentValidation](https://github.com/FluentValidation/FluentValidation)
- OpenApi using [Swashbuckle](https://github.com/domaindrivendev/Swashbuckle.AspNetCore)
- Logging using [Serilog](https://github.com/serilog/serilog)
- Testing using [NUnit](https://github.com/nunit/nunit), [Fluent Assertions](https://github.com/fluentassertions/fluentassertions), [Moq](https://github.com/devlooped/moq) & [Respawn](https://github.com/jbogard/Respawn)