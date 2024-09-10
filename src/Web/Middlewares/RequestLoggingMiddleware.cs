using System.Diagnostics;
using Serilog;

namespace CleanApi.Web.Middlewares;

public class RequestLoggingMiddleware(
    RequestDelegate next)
{
    readonly RequestDelegate _next = next;

    public async Task Invoke(HttpContext context)
    {
        var watch = Stopwatch.StartNew();

        // Log the request
        Log.Information("Request starting: {Method} {Url}", context.Request.Method, context.Request.Path);

        await _next(context);

        // Log the response
        Log.Information("Request finished: {Method} {Url} - {StatusCode} in {Elapsed}ms", context.Request.Method, context.Request.Path, context.Response.StatusCode, watch.Elapsed.TotalMilliseconds.ToString("n0"));

    }
}
