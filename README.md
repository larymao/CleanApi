# CleanApi

[![Build](https://github.com/larymao/CleanApi/actions/workflows/build.yml/badge.svg)](https://github.com/larymao/CleanApi/actions/workflows/build.yml)
[![codecov](https://codecov.io/gh/larymao/CleanApi/graph/badge.svg?token=6EEWCTPJK3)](https://codecov.io/gh/larymao/CleanApi)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://github.com/larymao/cleanapi/blob/master/LICENSE) 
[![Nuget](https://img.shields.io/nuget/v/CleanApi.Solution.Template?color=0b7cbd)](https://www.nuget.org/packages/CleanApi.Solution.Template)
[![Ask DeepWiki](https://deepwiki.com/badge.svg)](https://deepwiki.com/larymao/CleanApi)

[🌟 English](https://github.com/larymao/CleanApi/blob/main/README.md) | [🌏 中文](https://github.com/larymao/CleanApi/blob/main/README_CN.md)

This is a template for an API using a streamlined verison of [Clean Architecture](https://github.com/jasontaylordev/CleanArchitecture) alongside .NET's [Minimal APIs](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/minimal-apis).

## Prerequisites

- [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0) - *[required]* 
This solution in built on it, you need to install it before building and running.

- [Docker](https://www.docker.com/products/docker-desktop) - *[optional]* 
If you want to build the Dockerfile you will need to install it.

- [Docker-Compose](https://docs.docker.com/compose/install) - *[optional]* 
If you want to launch this solution quickly via the docker-compose.yml you will need to install it.

## Installation

This is a [.NET template](https://www.nuget.org/packages/CleanApi.Solution.Template) and you can install it using the [dotnet new cli](https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-new). 

### Option 1: Install from NuGet (Recommended)

``` bash
dotnet new install CleanApi.Solution.Template
```

### Option 2: Install from source

```bash
# 1. clone this repository
git clone https://github.com/larymao/CleanApi.git cleanapi

# 2. navigate to the repository root
cd cleanapi

# 3. install the template
dotnet new install .
```

## Usage

To scaffold a new solution with this template, execute one of the following commands:

```bash
# new solution with git initialized
dotnet new cleanapi --allow-scripts yes --name {YOUR_SOLUTION_NAMESPACE}

# new solution without git
dotnet new cleanapi --git false --name {YOUR_SOLUTION_NAMESPACE}
```

And then you could modify contents of `docker-compose.yml`, `src/Web/Dockerfile` and `src/Web/Configs/*.json` to suit your own business. Things you may wanna to modify are as follows:

- *postgres configs in docker-compose.yml*
- *postgres connection string in config files*
- *dockerfile labels*

### Scripts

This template comes with several built-in commands to help you manage your project. You can run these commands using `make`:

```bash
# Restore project dependencies
make restore

# Build the project
make build

# Run all tests
make test

# Clean build outputs and test results
make clean

# Publish the application
make publish

# Run the application with watch mode (hot reload)
make watch

# Run the application
make run

# Add a new database migration
make migration name=YourMigrationName
```

These commands are designed to work consistently across Windows (WSL), macOS, and Linux environments. Before using them, make sure you have the following prerequisites:

- GNU Make installed
- .NET SDK installed
- Entity Framework Core tools installed (`dotnet tool install --global dotnet-ef`)


### Database

This template is designed to work exclusively with [PostgreSQL](https://www.postgresql.org). The database integration offers several automated features:

- **Auto Database Creation**: The database is automatically created on first run if it doesn't exist
- **Auto Migration**: All pending migrations are automatically applied during application startup
- **Code-First Approach**: Uses Entity Framework Core's code-first pattern for database schema management

When you need to make changes to your database schema, you can create a new migration using the provided script:

```bash
make migration name=YourMigrationName
```

## Uninstallation

To uninstall the template run the following command:

```bash
dotnet new uninstall CleanApi.Solution.Template
```

*OR*

If you installed this template from source code, enter the root directory of this repo, and run the following command:

```bash
dotnet new uninstall .
```

## Features

There are plenty of handy implementations of features throughout this solution, in no particular order here are some that might interest you.

- Authentication using [JWT Token](https://jwt.io/introduction)
- Data Storage using [Postgres](https://github.com/postgres/postgres)
- Data accessing using [EFCore](https://github.com/dotnet/efcore) with [Code First Mode](https://learn.microsoft.com/en-us/ef/core/managing-schemas/migrations)
- Object Mapping using [Mapster](https://github.com/MapsterMapper/Mapster)
- Mediator Pattern using [Mediator](https://github.com/martinothamar/Mediator)
- Validation using [FluentValidation](https://github.com/FluentValidation/FluentValidation)
- OpenApi using [NSwag](https://github.com/RicoSuter/NSwag)
- Logging using [Serilog](https://github.com/serilog/serilog)
- Testing using [NUnit](https://github.com/nunit/nunit), [Fluent Assertions](https://github.com/fluentassertions/fluentassertions), [Moq](https://github.com/devlooped/moq) & [Respawn](https://github.com/jbogard/Respawn)
