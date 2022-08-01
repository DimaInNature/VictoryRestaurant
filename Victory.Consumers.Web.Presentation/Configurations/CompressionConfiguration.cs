namespace Victory.Consumers.Web.Presentation.Configurations;

public static class CompressionConfiguration
{
    public static void AddCompressionConfiguration(this IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(argument: services);

        services.AddResponseCompression(options => options.EnableForHttps = true);

        services.Configure<BrotliCompressionProviderOptions>(options =>
        {
            options.Level = CompressionLevel.Optimal;
        });
    }
}