namespace Victory.Application.Web.Data.ContactMessages;

public class ContactMessageRepositoryServiceLoggerDecorator
{
    private readonly IContactMessageRepositoryService _repository;

    private readonly ILogger<ContactMessageRepositoryServiceLoggerDecorator> _logger;

    public ContactMessageRepositoryServiceLoggerDecorator(IContactMessageRepositoryService repository,
        ILogger<ContactMessageRepositoryServiceLoggerDecorator> logger) =>
        (_repository, _logger) = (repository, logger);

    public async Task<List<ContactMessage>> GetContactMessageListAsync()
    {
        List<ContactMessage> result = new();

        try
        {
            result = await _repository.GetContactMessageListAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
        }

        return result;
    }

    public async Task<ContactMessage?> GetContactMessageAsync(int id)
    {
        ContactMessage? result = null;

        try
        {
            result = await _repository.GetContactMessageAsync(id);
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

    public async Task DeleteAsync(int id)
    {
        try
        {
            await _repository.DeleteAsync(id);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
        }
    }
}