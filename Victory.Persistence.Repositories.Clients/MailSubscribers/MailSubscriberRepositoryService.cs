namespace Victory.Persistence.Repositories.Clients.MailSubscribers;

public sealed class MailSubscriberRepositoryService : IMailSubscriberRepositoryService
{
    private readonly IMediator _mediator;

    public MailSubscriberRepositoryService(IMediator mediator) => _mediator = mediator;

    public async Task<List<MailSubscriber>> GetMailSubscriberListAsync() =>
        await _mediator.Send(request: new GetMailSubscriberListQuery()) ?? new();

    public async Task<MailSubscriber?> GetMailSubscriberAsync(int id, string token) =>
        await _mediator.Send(request: new GetMailSubscriberByIdQuery(id, token));

    public async Task CreateAsync(MailSubscriber entity) =>
        await _mediator.Send(request: new CreateMailSubscriberCommand(entity));

    public async Task DeleteAsync(int id, string token) =>
        await _mediator.Send(request: new DeleteMailSubscriberCommand(id, token));
}