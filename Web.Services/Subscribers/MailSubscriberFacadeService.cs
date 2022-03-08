namespace Web.Services.Subscribers;

public class MailSubscriberFacadeService : IMailSubscriberFacadeService
{
    private readonly MailSubscriberRepositoryServiceLoggerDecorator _repositoryService;

    public MailSubscriberFacadeService(MailSubscriberRepositoryServiceLoggerDecorator repositoryService)
    {
        _repositoryService = repositoryService;
    }

    public async Task InsertMailSubscriberAsync(MailSubscriber mailSubscriber) =>
        await _repositoryService.InsertMailSubscriberAsync(mailSubscriber);
}