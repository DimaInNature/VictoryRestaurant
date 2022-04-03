namespace Victory.Application.Web.Services;

public class MailSubscriberRepositoryServiceLoggerDecorator
{
    private readonly IMailSubscriberRepositoryService _repository;
    private readonly ILogger<MailSubscriberRepositoryServiceLoggerDecorator> _logger;

    public MailSubscriberRepositoryServiceLoggerDecorator(IMailSubscriberRepositoryService repository,
        ILogger<MailSubscriberRepositoryServiceLoggerDecorator> logger) =>
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