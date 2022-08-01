namespace Victory.Consumers.Desktop.Domain.Core.Models;

[Serializable]
public sealed record class ServerAPIConfiguration
{
    public string Url { get; init; }

    public ServerAPIConfiguration(string url) =>
        Url = url;

    public ServerAPIConfiguration() => Url = string.Empty;
}