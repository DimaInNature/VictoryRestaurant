namespace Victory.Domain.Configurations.Models;

[Serializable]
public sealed record class WebConfiguration
{
    public string Url { get; init; }

    public WebConfiguration(string url) =>
        Url = url;

    public WebConfiguration() => Url = string.Empty;
}