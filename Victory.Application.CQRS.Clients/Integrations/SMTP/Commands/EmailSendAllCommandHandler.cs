namespace Victory.Application.CQRS.Clients.Integrations.SMTP;

public sealed class EmailSendAllCommandHandler
    : IRequestHandler<EmailSendAllCommand>
{
    private readonly SMTPConfigurationService _smtpConfig;

    public EmailSendAllCommandHandler(SMTPConfigurationService apiConfig) =>
        _smtpConfig = apiConfig;

    public async Task<Unit> Handle(EmailSendAllCommand request, CancellationToken token)
    {
        using var client = new HttpClient();

        string json = JsonConvert.SerializeObject(value: request.EmailMessage);

        await client.PostAsync(
            requestUri: $"{_smtpConfig.Uri}/Send/All",
            content: new StringContent(
                content: json,
                encoding: Encoding.UTF8,
                mediaType: "application/json"),
            cancellationToken: token);

        return Unit.Value;
    }
}