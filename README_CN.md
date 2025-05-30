# CleanApi

[![Build](https://github.com/larymao/CleanApi/actions/workflows/build.yml/badge.svg)](https://github.com/larymao/CleanApi/actions/workflows/build.yml)
[![codecov](https://codecov.io/gh/larymao/CleanApi/graph/badge.svg?token=6EEWCTPJK3)](https://codecov.io/gh/larymao/CleanApi)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://github.com/larymao/cleanapi/blob/master/LICENSE) 
[![Nuget](https://img.shields.io/nuget/v/CleanApi.Solution.Template?color=0b7cbd)](https://www.nuget.org/packages/CleanApi.Solution.Template)

[🌟 English](README.md) | [🌏 中文](README_CN.md)

这是一个结合精简版的 [Clean Architecture](https://github.com/jasontaylordev/CleanArchitecture) 和 .NET [Minimal APIs](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/minimal-apis) 而成的 API 模板 。

## 先决条件

- [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0) - *[必需]* 
本解决方案基于此构建，使用前需要先安装它。

- [Docker](https://www.docker.com/products/docker-desktop) - *[可选]* 
如果你想构建 Dockerfile，则需要安装它。

- [Docker-Compose](https://docs.docker.com/compose/install) - *[可选]* 
如果你想通过 docker-compose.yml 快速启动此解决方案，则需要安装它。

## 安装

这是一个 [.NET 模板](https://www.nuget.org/packages/CleanApi.Solution.Template)，你可以使用 [dotnet new cli](https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-new) 进行安装。

### 选项 1：从 NuGet 安装（推荐）

``` bash
dotnet new install CleanApi.Solution.Template
```

### 选项 2：从源代码安装

```bash
# 1. 克隆此仓库
git clone https://github.com/larymao/CleanApi.git cleanapi

# 2. 进入仓库根目录
cd cleanapi

# 3. 安装模板
dotnet new install .
```

## 使用说明

要使用此模板创建新的解决方案，请运行以下命令之一：

```bash
# 带 git 的新解决方案
dotnet new cleanapi --allow-scripts yes --name {YOUR_SOLUTION_NAMESPACE}

# 不带 git 的新解决方案
dotnet new cleanapi --git false --name {YOUR_SOLUTION_NAMESPACE}
```

然后，你可以根据自己的业务需求修改 `docker-compose.yml`、`src/Web/Dockerfile` 和 `src/Web/Configs/*.json` 的内容。可能需要修改的内容如下：

- *docker-compose.yml 中的 postgres 配置*
- *配置文件中的 postgres 连接字符串*
- *dockerfile 标签*

要了解更多关于从此模板创建新解决方案的信息，请运行以下命令：

```bash
dotnet new cleanapi --help
```

### 数据库

本模板仅适用于 [PostgreSQL](https://www.postgresql.org)，集成了多项数据库自动化特性：

- **自动创建数据库**：首次运行时，如果数据库不存在将自动创建
- **自动迁移**：应用程序启动时会自动应用所有待处理的迁移
- **代码优先模式**：采用 Entity Framework Core 的代码优先模式管理数据库架构

当你需要修改数据库架构时，可以使用提供的脚本创建新的迁移：

```bash
./scripts/add_migration.sh SampleMigrationName
```

## 卸载

要卸载模板，请运行以下命令：

```bash
dotnet new uninstall CleanApi.Solution.Template
```

*或者*

如果你是从源代码安装的模板，请进入仓库根目录，然后运行以下命令：

```bash
dotnet new uninstall .
```

## 功能

这个解决方案中实现了许多实用功能，以下是一些可能对你有用的功能（无特定顺序）：

- 使用 [JWT 令牌](https://jwt.io/introduction)进行身份验证
- 使用 [Postgres](https://github.com/postgres/postgres) 进行数据存储
- 使用 [EFCore](https://github.com/dotnet/efcore) 进行数据访问，采用[代码优先模式](https://learn.microsoft.com/en-us/ef/core/managing-schemas/migrations)
- 使用 [AutoMapper](https://github.com/AutoMapper/AutoMapper) 进行对象映射
- 使用 [MediatR](https://github.com/jbogard/MediatR) 实现中介者模式
- 使用 [FluentValidation](https://github.com/FluentValidation/FluentValidation) 进行验证
- 使用 [NSwag](https://github.com/RicoSuter/NSwag) 实现 OpenApi
- 使用 [Serilog](https://github.com/serilog/serilog) 进行日志记录
- 使用 [NUnit](https://github.com/nunit/nunit)、[Fluent Assertions](https://github.com/fluentassertions/fluentassertions)、[Moq](https://github.com/devlooped/moq) 和 [Respawn](https://github.com/jbogard/Respawn) 进行测试
