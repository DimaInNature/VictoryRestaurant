namespace Victory.Presentation.Web.Configurations;

public static class CompressionConfiguration
{
    public static void AddCompressionConfiguration(this IServiceCollection services)
    {
        if (services is null) throw new ArgumentNullException(nameof(services));

        services.AddResponseCompression(options => options.EnableForHttps = true);

        services.Configure<BrotliCompressionProviderOptions>(options =>
        {
            options.Level = CompressionLevel.Optimal;
        });
    }
}