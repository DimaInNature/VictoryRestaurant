namespace Victory.Application.Web.Services;

public class ContactMessageRepositoryServiceLoggerDecorator
{
    private readonly IContactMessageRepositoryService _repository;
    private readonly ILogger<ContactMessageRepositoryServiceLoggerDecorator> _logger;

    public ContactMessageRepositoryServiceLoggerDecorator(IContactMessageRepositoryService repository,
        ILogger<ContactMessageRepositoryServiceLoggerDecorator> logger) =>
        (_repository, _logger) = (repository, logger);

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
}