namespace Victory.Domain.Configurations.Models;

[Serializable]
public sealed record class MailSMTPHostConfiguration
{
    public string Uri { get; init; }

    public MailSMTPHostConfiguration(string uri) => Uri = uri;

    public MailSMTPHostConfiguration() => Uri = string.Empty;
}