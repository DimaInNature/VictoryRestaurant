namespace Victory.Application.Desktop.Messages;

public sealed class EmailService
{
    private string _userName = string.Empty;

    private string _password = string.Empty;

    private string _smtpHost = string.Empty;

    private int _smtpPort = 1;

    private readonly IMailSubscriberFacadeService _mailSubscriberService;

    private readonly MimeMessage _message = new();

    public EmailService(IMailSubscriberFacadeService mailSubscriberService) =>
        _mailSubscriberService = mailSubscriberService;

    public EmailService AddMailSender(string userName, string password)
    {
        (_userName, _password) = (userName, password);

        return this;
    }

    public EmailService ConfigureSMTP(string host, int port)
    {
        (_smtpHost, _smtpPort) = (host, port);

        return this;
    }

    public EmailService AddMessage(string subject, string message)
    {
        (_message.Subject, _message.Body) = (subject, new TextPart(format: MimeKit.Text.TextFormat.Plain) { Text = message });

        return this;
    }

    public async Task SendAsync()
    {
        _message.From.Add(new MailboxAddress(name: "Ресторан Victory", address: _userName));

        var mailSubscribers = await _mailSubscriberService.GetMailSubscriberListAsync();

        foreach (var mailSubcriber in mailSubscribers)
            _message.To.Add(new MailboxAddress(name: "", address: mailSubcriber.Mail));

        using SmtpClient client = new();

        await client.ConnectAsync(host: _smtpHost, port: _smtpPort, useSsl: false);

        await client.AuthenticateAsync(userName: _userName, password: _password);

        await client.SendAsync(message: _message);

        await client.DisconnectAsync(quit: true);
    }
}