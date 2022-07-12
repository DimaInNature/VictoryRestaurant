namespace Victory.Domain.Consumers.Decorators.ContactMessages;

public class ContactMessageRepositoryLoggingService : IContactMessageRepositoryService
{
    private readonly IContactMessageRepositoryService _repository;

    private readonly ILogger<ContactMessageRepositoryLoggingService> _logger;

    public ContactMessageRepositoryLoggingService(
        IContactMessageRepositoryService repository,
        ILogger<ContactMessageRepositoryLoggingService> logger) =>
        (_repository, _logger) = (repository, logger);

    public async Task<List<ContactMessage>> GetContactMessageListAsync(string token)
    {
        List<ContactMessage> result = new();

        try
        {
            result = await _repository.GetContactMessageListAsync(token);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
        }

        return result;
    }

    public async Task<ContactMessage?> GetContactMessageAsync(int id, string token)
    {
        ContactMessage? result = null;

        try
        {
            result = await _repository.GetContactMessageAsync(id, token);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
        }

        return result;
    }

    public async Task CreateAsync(ContactMessage entity)
    {
        try
        {
            await _repository.CreateAsync(entity);
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