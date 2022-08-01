namespace Victory.Consumers.Web.Presentation.Configurations;

public static class ServerAPIConfiguration
{
    public static string Url { get; set; } = string.Empty;

    public static void SetAPIConfiguration(this WebApplicationBuilder builder)
    {
        if (builder == null) throw new ArgumentNullException(nameof(builder));

        Url = builder.Configuration[key: "ServerAPI:Url"];
    }

    public static void UseAPIConfiguration(this IApplicationBuilder services) =>
        services.ApplicationServices.GetService<APIFeaturesConfigurationService>()?.ConfigureUrl(Url);
}