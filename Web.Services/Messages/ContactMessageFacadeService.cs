namespace Web.Services.Messages;

public class ContactMessageFacadeService : IContactMessageFacadeService
{
    private readonly ContactMessageRepositoryServiceLoggerDecorator _repositoryService;

    public ContactMessageFacadeService(ContactMessageRepositoryServiceLoggerDecorator repositoryService)
    {
        _repositoryService = repositoryService;
    }

    public async Task InsertContactMessageAsync(ContactMessage contactMessage) =>
        await _repositoryService.InsertContactMessageAsync(contactMessage);
}