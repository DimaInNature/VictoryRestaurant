namespace Victory.Domain.Configurations.Models;

[Serializable]
public sealed record class ServerAPIConfiguration
{
    public string Url { get; init; }

    public ServerAPIConfiguration(string url) =>
        Url = url;

    public ServerAPIConfiguration() => Url = string.Empty;
}