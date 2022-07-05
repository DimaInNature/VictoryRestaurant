namespace Victory.Application.SMTP.Messages;

public sealed class EmailMailingService
{
    private readonly IMailSubscriberFacadeService _mailSubscriberService;

    private readonly SMTPConfigurationService _smtpConfiguration;

    private readonly ILogger<EmailMailingService> _logger;

    public EmailMailingService(
        IMailSubscriberFacadeService mailSubscriberService,
        SMTPConfigurationService smtpConfiguration,
        ILogger<EmailMailingService> logger) =>
        (_mailSubscriberService, _smtpConfiguration, _logger) = (mailSubscriberService, smtpConfiguration, logger);

    public async Task SendAllAsync(EmailMessage emailMessage)
    {
        string userName = _smtpConfiguration.UserName;

        string password = _smtpConfiguration.Password;

        string host = _smtpConfiguration.Host;

        int port = _smtpConfiguration.Port;

        List<MailSubscriber> mailSubscribers = await _mailSubscriberService.GetMailSubscriberListAsync();

        int mailsCount = mailSubscribers.Count;

        int invalidMailsCount = 0;

        MimeMessage message = new()
        {
            Subject = emailMessage.Subject,
            Body = new TextPart(format: MimeKit.Text.TextFormat.Plain) { Text = emailMessage.Text }
        };

        using SmtpClient client = new();

        await client.ConnectAsync(host, port, useSsl: false);

        await client.AuthenticateAsync(userName: userName, password: password);

        message.From.Add(new MailboxAddress(name: "Victory restaurant", address: userName));

        foreach (var mailSubcriber in mailSubscribers)
        {
            try
            {
                if (client.IsConnected is false)
                    await client.ConnectAsync(host, port, useSsl: false);

                message.To.Add(new MailboxAddress(name: "", address: mailSubcriber.Mail));

                await client.SendAsync(message: message);
            }
            catch
            {
                _logger.LogWarning($"{mailSubcriber.Mail} is not exist.");

                await client.DisconnectAsync(quit: true);

                invalidMailsCount++;
            }
        }

        await client.DisconnectAsync(quit: true);

        _logger.LogInformation($"Number of messages sended {mailsCount - invalidMailsCount}/{mailsCount}");
    }
}