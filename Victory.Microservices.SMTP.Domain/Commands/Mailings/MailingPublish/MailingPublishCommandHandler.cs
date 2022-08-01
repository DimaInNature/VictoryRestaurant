namespace Victory.Microservices.SMTP.Domain.Commands.Mailings;

public sealed record class MailingPublishCommandHandler
    : IRequestHandler<MailingPublishCommand>
{
    private readonly IMailSubscriberService _mailSubscriberService;

    private readonly IConfiguration _configuration;

    private readonly ILogger<MailingPublishCommandHandler> _logger;

    public MailingPublishCommandHandler(
        IMailSubscriberService mailSubscriberService,
        IConfiguration configuration,
        ILogger<MailingPublishCommandHandler> logger) =>
        (_mailSubscriberService, _configuration, _logger) = (mailSubscriberService, configuration, logger);

    public async Task<Unit> Handle(
        MailingPublishCommand request,
        CancellationToken token)
    {
        ArgumentNullException.ThrowIfNull(argument: request.Message);

        var emailMessage = request.Message;

        string userName = _configuration[key: ""];

        string password = _configuration[key: ""];

        string host = _configuration[key: ""];

        int port = Convert.ToInt32(value: _configuration[key: ""]);

        List<MailSubscriberEntity> mailSubscribers = (await _mailSubscriberService.GetAllAsync()).ToList();

        int mailsCount = mailSubscribers.Count;

        int invalidMailsCount = 0;

        MimeMessage message = new()
        {
            Subject = emailMessage.Subject,
            Body = new TextPart(format: TextFormat.Plain) { Text = emailMessage.Text }
        };

        using SmtpClient client = new();

        await client.ConnectAsync(host, port, useSsl: false, cancellationToken: token);

        await client.AuthenticateAsync(userName: userName, password: password, cancellationToken: token);

        message.From.Add(new MailboxAddress(name: "Victory restaurant", address: userName));

        foreach (var mailSubcriber in mailSubscribers)
        {
            try
            {
                if (client.IsConnected is false)
                    await client.ConnectAsync(host, port, useSsl: false, cancellationToken: token);

                message.To.Add(new MailboxAddress(name: "", address: mailSubcriber.Mail));

                await client.SendAsync(message: message);
            }
            catch
            {
                _logger.LogWarning($"{mailSubcriber.Mail} is not exist.");

                await client.DisconnectAsync(quit: true, cancellationToken: token);

                invalidMailsCount++;
            }
        }

        await client.DisconnectAsync(quit: true, cancellationToken: token);

        _logger.LogInformation($"Number of messages sended {mailsCount - invalidMailsCount}/{mailsCount}");

        return Unit.Value;
    }
}