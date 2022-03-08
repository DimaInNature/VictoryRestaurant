namespace Web.Services.Subscribers;

public class MailSubscriberRepositoryServiceLoggerDecorator
{
    private readonly IMailSubscriberRepositoryService _repositoryService;
    private readonly ILogger<MailSubscriberRepositoryServiceLoggerDecorator> _logger;

    public MailSubscriberRepositoryServiceLoggerDecorator(IMailSubscriberRepositoryService repositoryService,
        ILogger<MailSubscriberRepositoryServiceLoggerDecorator> logger)
    {
        _repositoryService = repositoryService;
        _logger = logger;
    }

    public async Task InsertMailSubscriberAsync(MailSubscriber mailSubscriber)
    {
        try
        {
            await _repositoryService.InsertMailSubscriberAsync(mailSubscriber);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
        }
    }
}