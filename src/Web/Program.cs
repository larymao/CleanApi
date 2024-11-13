using CleanApi.Infrastructure.Data;
using CleanApi.Web.Middlewares;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Load configurations.
builder.Configuration
    .SetBasePath(Path.Combine(builder.Environment.ContentRootPath, "Configs"))
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    .AddJsonFile("appsettings.Logging.json", optional: true, reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true);

builder.Host.UseSerilog((context, config) => config.ReadFrom.Configuration(context.Configuration));

// Add services to the container.
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddWebServices();

var app = builder.Build();
await app.InitialiseDatabaseAsync();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseMiddleware<SerilogEnrichingMiddleware>();
app.UseMiddleware<RequestLoggingMiddleware>();

app.UseHealthChecks("/health");
app.UseHttpsRedirection();
app.UseStaticFiles();

if (app.Environment.IsDevelopment())
{
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/api/specification.json", "CleanApi");
    });
}

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.UseExceptionHandler(options => { });

app.Map("/", () => Results.Redirect("/swagger"));

app.MapEndpoints();

app.Run();

public partial class Program { }
