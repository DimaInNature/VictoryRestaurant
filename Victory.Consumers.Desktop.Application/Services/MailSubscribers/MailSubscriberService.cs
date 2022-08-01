namespace Victory.Consumers.Desktop.Application.Services.MailSubscribers;

public sealed class MailSubscriberService : IMailSubscriberService
{
    private readonly IMediator _mediator;

    public MailSubscriberService(IMediator mediator) => _mediator = mediator;

    public async Task<List<MailSubscriber>> GetMailSubscriberListAsync() =>
        await _mediator.Send(request: new GetMailSubscriberListQuery()) ?? new();

    public async Task<MailSubscriber?> GetMailSubscriberAsync(int id, string token) =>
        await _mediator.Send(request: new GetMailSubscriberByIdQuery(id, token));

    public async Task CreateAsync(MailSubscriber entity) =>
        await _mediator.Send(request: new CreateMailSubscriberCommand(entity));

    public async Task DeleteAsync(int id, string token) =>
        await _mediator.Send(request: new DeleteMailSubscriberCommand(id, token));
}