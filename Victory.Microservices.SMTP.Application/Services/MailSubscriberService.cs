namespace Victory.Microservices.SMTP.Application.Services;

public class MailSubscriberService : IMailSubscriberService
{
    private readonly IMediator _mediator;

	public MailSubscriberService(IMediator mediator) =>
        _mediator = mediator;

    public async Task<IEnumerable<MailSubscriberEntity>> GetAllAsync() =>
        await _mediator.Send(request: new GetMailSubscriberListQuery()) ?? new List<MailSubscriberEntity>();

    public async Task<IEnumerable<MailSubscriberEntity>> GetAllAsync(
        Func<MailSubscriberEntity, bool> predicate) =>
        await _mediator.Send(request: new GetMailSubscriberListByPredicateQuery(predicate)) ?? new List<MailSubscriberEntity>();

    public async Task<MailSubscriberEntity?> GetAsync(int id) =>
        await _mediator.Send(request: new GetMailSubscriberByPredicateQuery(predicate: x => x.Id == id));

    public async Task<MailSubscriberEntity?> GetAsync(Func<MailSubscriberEntity, bool> predicate) =>
        await _mediator.Send(request: new GetMailSubscriberByPredicateQuery(predicate));

    public async Task CreateAsync(MailSubscriberEntity entity) =>
        await _mediator.Send(request: new CreateMailSubscriberCommand(entity));

    public async Task UpdateAsync(MailSubscriberEntity entity) =>
        await _mediator.Send(request: new UpdateMailSubscriberCommand(entity));

    public async Task DeleteAsync(int id) =>
        await _mediator.Send(request: new DeleteMailSubscriberCommand(id));
}