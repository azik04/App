using Serilog;

namespace App.Middleware
{
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

                var transactionId = Guid.NewGuid().ToString(); // Generate a unique transaction ID for the request
                context.Items["TransactionId"] = transactionId; // Store the transaction ID in the HttpContext for later use
                context.Response.OnStarting(() =>
                {
                    context.Response.Headers["X-Transaction-ID"] = transactionId; // Add the transaction ID to the response headers
                    return Task.CompletedTask;
                });

                var start = DateTime.Now;
                // Pre-processing logic can be added here (e.g., logging, authentication checks)
                await _next(context); // Call the next middleware in the pipeline
                // Post-processing logic can be added here (e.g., response modification, logging)
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
}
