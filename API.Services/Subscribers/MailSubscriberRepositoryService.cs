namespace API.Services.Subscribers;

public class MailSubscriberRepositoryService : IMailSubscriberRepositoryService
{
    private readonly IMediator _mediator;

    public MailSubscriberRepositoryService(IMediator mediator) => _mediator = mediator;

    public async Task<List<MailSubscriberEntity>?> GetMailSubscriberListAsync() =>
        await _mediator.Send(request: new GetMailSubscriberListQuery());

    public async Task<MailSubscriberEntity?> GetMailSubscriberAsync(int mailSubscriberId) => //
         await _mediator.Send(request: new GetMailSubscriberByIdQuery(id: mailSubscriberId));

    public async Task CreateAsync(MailSubscriberEntity mailSubscriber) =>
        await _mediator.Send(request: new CreateMailSubscriberCommand(mailSubscriber: mailSubscriber));

    public async Task UpdateAsync(MailSubscriberEntity mailSubscriber) =>
        await _mediator.Send(request: new UpdateMailSubscriberCommand(mailSubscriber: mailSubscriber));

    public async Task DeleteAsync(int mailSubscriberId) =>
        await _mediator.Send(request: new DeleteMailSubscriberCommand(id: mailSubscriberId));
}