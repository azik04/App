using Serilog;
using Serilog.Events;
using System.Net;

namespace App.Configurations;

public static class SerilogConfiguration
{
    public static void AddSerilog(this WebApplicationBuilder builder)
    {
        Log.Logger = new LoggerConfiguration()
            .Enrich.FromLogContext()
            .Enrich.WithProperty("ServerName", Dns.GetHostName())
            .MinimumLevel.Information()
            .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
            .MinimumLevel.Override("System", LogEventLevel.Warning)
            .MinimumLevel.Override("Microsoft.EntityFrameworkCore", LogEventLevel.Warning)
            .WriteTo.File(
                path: builder.Configuration["Serilog:Path"],
                rollingInterval: Enum.Parse<RollingInterval>(builder.Configuration["Serilog:RollingInterval"]),
                outputTemplate: builder.Configuration["Serilog:OutputTemplate"]
            )
            .CreateLogger();
    }
}