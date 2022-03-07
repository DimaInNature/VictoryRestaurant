namespace Web.Services.Messages;

public class ContactMessageRepositoryServiceLoggerDecorator
{
    private readonly IContactMessageRepositoryService _repositoryService;
    private readonly ILogger<ContactMessageRepositoryServiceLoggerDecorator> _logger;

    public ContactMessageRepositoryServiceLoggerDecorator(IContactMessageRepositoryService repositoryService,
        ILogger<ContactMessageRepositoryServiceLoggerDecorator> logger)
    {
        _repositoryService = repositoryService;
        _logger = logger;
    }

    public async Task InsertContactMessageAsync(ContactMessage contactMessage)
    {
        try
        {
            await _repositoryService.InsertContactMessageAsync(contactMessage);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
        }
    }
}