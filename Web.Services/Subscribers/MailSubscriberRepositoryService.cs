namespace Web.Services.Subscribers;

public class MailSubscriberRepositoryService : IMailSubscriberRepositoryService
{
    private readonly IMailSubscriberRepository _repository;

    public MailSubscriberRepositoryService(IMailSubscriberRepository repository)
    {
        _repository = repository;
    }

    public async Task InsertMailSubscriberAsync(MailSubscriber mailSubscriber) =>
        await _repository.InsertMailSubscriberAsync(mailSubscriber.ToEntity());
}
