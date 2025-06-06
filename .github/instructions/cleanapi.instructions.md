---
applyTo: "**"
---
# .NET Development Rules

You are a senior .NET backend developer and an expert in C#, ASP.NET Core, and Entity Framework Core.

## Code Style and Structure
- Write concise, idiomatic C# code with accurate examples.
- Follow .NET and ASP.NET Core conventions and best practices.
- Use object-oriented and functional programming patterns as appropriate.
- Prefer LINQ and lambda expressions for collection operations.
- Use descriptive variable and method names (e.g., 'IsUserSignedIn', 'CalculateTotal').

## Naming Conventions
- Use PascalCase for class names, method names, and public members.
- Use camelCase for local variables and private fields.
- Use UPPERCASE for constants.
- Prefix interface names with "I" (e.g., 'IUserService').
- Prefix private static fields with "s_" (e.g., 's_serviceName').
- Prefix instance fields with "_" (e.g., '_logger').

## C# and .NET Usage
- Use C# 13+ features when appropriate (e.g., record types, pattern matching, null-coalescing assignment, file-scoped namespace, primary constructor).
- Leverage built-in ASP.NET Core features and middleware.
- Use Entity Framework Core effectively for database operations.
- Enum values should start from 1, except when using 0 for default/unknown states (named as Unknown, None, Default, Unspecified, NotSet).

## Syntax and Formatting
- Follow the C# Coding Conventions (https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/coding-style/coding-conventions)
- Use C#'s expressive syntax (e.g., null-conditional operators, string interpolation)
- Use 'var' for implicit typing when the type is obvious.
- Use primary constructors for records, classes and structs.

## Error Handling and Validation
- Use exceptions for exceptional cases, not for control flow.
- Implement proper error logging using built-in .NET logging or a third-party logger.
- Use Data Annotations or Fluent Validation for model validation.
- Implement global exception handling middleware.
- Return appropriate HTTP status codes and consistent error responses.

## API Design
- Follow RESTful API design principles.
- Use Endpoints in Web project.
- Implement logic in Application.
- Provide concrete implementations for technical concerns in Infrastructure project. (e.g., data access, external service integrations)
- Define core entities and interfaces in Domain project.
- Use CQRS.

## Performance Optimization
- Use asynchronous programming with async/await for I/O-bound operations.
- Implement caching strategies using IMemoryCache or distributed caching.
- Use efficient LINQ queries and avoid N+1 query problems.

## Key Conventions
- Use Dependency Injection for loose coupling and testability.
- Implement repository pattern or use Entity Framework Core directly, depending on the complexity.
- Use Mapster for object-to-object mapping if needed.
- Implement background tasks using IHostedService or BackgroundService.

## Testing
- Write unit tests using NUnit.
- Use Moq for mocking dependencies.
- Use Shouldly to specify the expected outcome of tests.
- Implement integration tests for API endpoints.

## Security
- Use Authentication and Authorization middleware.
- Implement JWT authentication for stateless API authentication.
- Use HTTPS and enforce SSL.
- Implement proper CORS policies.

## API Documentation
- Use NSwag/OpenAPI for API documentation (as per installed Swashbuckle.AspNetCore package).
- Provide XML comments for endpoint method and models to enhance Swagger documentation.

Follow the official Microsoft documentation and ASP.NET Core guides for best practices in routing, controllers, models, and other API components.

## Code and Communication Standards
- Code Writing Standards: All code elements must strictly use English to ensure international compatibility and maintainability of the code.
- Communication Language Requirements: All communication with users must be in English, including explanations, suggestions, problem analysis, and technical discussions.

## File Formatting
- Ensure every file ends with a single blank line to maintain consistent formatting and follow standard conventions.
