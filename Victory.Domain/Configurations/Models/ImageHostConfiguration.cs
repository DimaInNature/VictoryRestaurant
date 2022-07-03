namespace Victory.Domain.Configurations.Models;

[Serializable]
public sealed record class ImageHostConfiguration
{
    public string Cloud { get; init; }

    public string ApiKey { get; init; }

    public string ApiSecret { get; init; }

    public ImageHostConfiguration(string cloud, string apiKey, string apiSecret) =>
        (Cloud, ApiKey, ApiSecret) = (cloud, apiKey, apiSecret);

    public ImageHostConfiguration() => Cloud = ApiKey = ApiSecret = string.Empty;
}