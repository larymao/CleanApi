using Serilog.Context;

namespace CleanApi.Web.Middlewares;

public class SerilogEnrichingMiddleware(
    RequestDelegate next)
{
    readonly RequestDelegate _next = next;

    public async Task Invoke(HttpContext context)
    {
        LogContext.PushProperty("RequestMethod", context.Request.Method);
        LogContext.PushProperty("RequestPath", context.Request.Path);

        await _next(context);
    }
}
