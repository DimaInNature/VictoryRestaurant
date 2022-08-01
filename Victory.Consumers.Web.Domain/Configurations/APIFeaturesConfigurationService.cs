namespace Victory.Consumers.Web.Domain.Configurations;

public class APIFeaturesConfigurationService
{
    public string ServerUrl { get; private set; } = string.Empty;

    public void ConfigureUrl(string url) => ServerUrl = url;
}