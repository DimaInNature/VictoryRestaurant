namespace Victory.Application.Web.Data.MailSubscribers;

public class MailSubscriberRepositoryServiceLoggerDecorator
{
    private readonly IMailSubscriberRepositoryService _repository;
    private readonly ILogger<MailSubscriberRepositoryServiceLoggerDecorator> _logger;

    public MailSubscriberRepositoryServiceLoggerDecorator(
        IMailSubscriberRepositoryService repository,
        ILogger<MailSubscriberRepositoryServiceLoggerDecorator> logger) =>
        (_repository, _logger) = (repository, logger);

    public async Task<List<MailSubscriber>> GetMailSubscriberListAsync()
    {
        List<MailSubscriber> result = new();

        try
        {
            result = await _repository.GetMailSubscriberListAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
        }

        return result;
    }

    public async Task<MailSubscriber?> GetMailSubscriberAsync(int id, string token)
    {
        MailSubscriber? result = null;

        try
        {
            result = await _repository.GetMailSubscriberAsync(id, token);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
        }

        return result;
    }

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

    public async Task DeleteAsync(int id, string token)
    {
        try
        {
            await _repository.DeleteAsync(id, token);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
        }
    }
}