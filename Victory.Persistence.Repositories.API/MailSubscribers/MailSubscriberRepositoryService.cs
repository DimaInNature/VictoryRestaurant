namespace Victory.Persistence.Repositories.API.MailSubscribers;

public class MailSubscriberRepositoryService : IMailSubscriberRepositoryService
{
    private readonly IMediator _mediator;

    public MailSubscriberRepositoryService(IMediator mediator) => _mediator = mediator;

    public async Task<List<MailSubscriberEntity>?> GetMailSubscriberListAsync() =>
        await _mediator.Send(request: new GetMailSubscriberListQuery());

    public async Task<MailSubscriberEntity?> GetMailSubscriberAsync(int id) =>
         await _mediator.Send(request: new GetMailSubscriberByIdQuery(id));

    public async Task CreateAsync(MailSubscriberEntity entity) =>
        await _mediator.Send(request: new CreateMailSubscriberCommand(entity));

    public async Task UpdateAsync(MailSubscriberEntity entity) =>
        await _mediator.Send(request: new UpdateMailSubscriberCommand(entity));

    public async Task DeleteAsync(int id) =>
        await _mediator.Send(request: new DeleteMailSubscriberCommand(id));
}