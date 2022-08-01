namespace Victory.Consumers.Web.Application.Services.MailSubscribers;

public class MailSubscriberLoggingService : IMailSubscriberService
{
    private readonly IMailSubscriberService _repository;

    private readonly ILogger<MailSubscriberLoggingService> _logger;

    public MailSubscriberLoggingService(
        IMailSubscriberService repository,
        ILogger<MailSubscriberLoggingService> logger) =>
        (_repository, _logger) = (repository, logger);

    public async Task CreateAsync(MailSubscriber mailSubscriber)
    {
        try
        {
            await _repository.CreateAsync(mailSubscriber);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
        }
    }
}