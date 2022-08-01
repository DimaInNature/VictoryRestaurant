namespace Victory.Consumers.Web.Application.Services.ContactMessages;

public class ContactMessageLoggingService : IContactMessageService
{
    private readonly IContactMessageService _repository;

    private readonly ILogger<ContactMessageLoggingService> _logger;

    public ContactMessageLoggingService(
        IContactMessageService repository,
        ILogger<ContactMessageLoggingService> logger) =>
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