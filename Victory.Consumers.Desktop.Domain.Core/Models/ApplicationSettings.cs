namespace Victory.Consumers.Desktop.Domain.Core.Models;

[Serializable]
public sealed record class ApplicationSettings
{
    public MailSMTPHostConfiguration? MailSMTPHost { get; init; }

    public ImageHostConfiguration? ImageHostAuth { get; init; }

    public ServerAPIConfiguration? ServerAPI { get; init; }

    public WebConfiguration? Web { get; init; }

    public ApplicationSettings(
        MailSMTPHostConfiguration mailSMTPHost,
        ImageHostConfiguration? imageHostAuth,
        ServerAPIConfiguration serverAPI,
        WebConfiguration web) =>
        (MailSMTPHost, ImageHostAuth, ServerAPI, Web) = (mailSMTPHost, imageHostAuth, serverAPI, web);
}