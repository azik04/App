using Serilog;

namespace App.Middleware;

public class BaseMiddleware 
{
    private readonly RequestDelegate _next;

    public BaseMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {

            var transactionId = Guid.NewGuid().ToString();
            context.Items["TransactionId"] = transactionId; 
            context.Response.OnStarting(() =>
            {
                context.Response.Headers["X-Transaction-ID"] = transactionId;
                return Task.CompletedTask;
            });

            var start = DateTime.Now;

            await _next(context);

            var duration = DateTime.Now - start;
            var statusCode = context.Response.StatusCode;

            if (statusCode >= 200 && statusCode < 300)
            {
                Log.Information("Success: {Method} {Path} -> {StatusCode} in {Duration}ms | TransactionId: {TransactionId}",
                    context.Request.Method,
                    context.Request.Path,
                    statusCode,
                    duration.TotalMilliseconds,
                    transactionId);
            }
            else if (statusCode >= 400 && statusCode < 500)
            {
                Log.Warning("Client error: {Method} {Path} -> {StatusCode} | TransactionId: {TransactionId}",
                    context.Request.Method,
                    context.Request.Path,
                    statusCode,
                    transactionId);
            }
            else
            {
                Log.Error("Server error: {Method} {Path} -> {StatusCode} | TransactionId: {TransactionId}",
                    context.Request.Method,
                    context.Request.Path,
                    statusCode,
                    transactionId);
            }
        }
        catch(Exception ex) {
            Log.Error(ex, "An error occurred while processing the request.");
            throw;
        }
    }
}
