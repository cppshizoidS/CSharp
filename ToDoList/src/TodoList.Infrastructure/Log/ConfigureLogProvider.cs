using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Serilog;

namespace TodoList.Infrastructure.Log;

public static class ConfigureLogProvider
{
    public static void ConfigureLog(this WebApplicationBuilder builder)
    {
        if (builder.Configuration.GetValue<bool>("UseFileToLog"))
        {
            Serilog.Log.Logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .WriteTo.File(
                    "logs/log-.txt",
                    outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}",
                    rollingInterval: RollingInterval.Day,
                    retainedFileCountLimit: 15)
                .CreateLogger();
        }
        else
        {
            Serilog.Log.Logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .CreateLogger();
        }
        
        builder.Host.UseSerilog();
    }
}