﻿namespace Victory.Presentation.Web.Configurations;

public static class LoggingConfiguration
{
    public static void UseLoggingConfiguration(this IServiceCollection services, ConfigureHostBuilder hostBuilder)
    {
        hostBuilder.UseSerilog();

        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Override(source: "Microsoft", minimumLevel: LogEventLevel.Information)
            .WriteTo.File(path: "Logs/WebAppLog-.txt", rollingInterval: RollingInterval.Day)
            .WriteTo.Console()
            .CreateLogger();

        services.AddHttpContextAccessor();

        services.AddTransient(serviceType: typeof(IPipelineBehavior<,>), implementationType: typeof(LoggingBehavior<,>));
    }
}