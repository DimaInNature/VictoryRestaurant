namespace Victory.Application.Web.Data.Subscribers;

public class MailSubscriberRepositoryService : IMailSubscriberRepositoryService
{
    private readonly IMediator _mediator;

    public MailSubscriberRepositoryService(IMediator mediator) => _mediator = mediator;

    public async Task CreateAsync(MailSubscriber entity) =>
        await _mediator.Send(request: new CreateMailSubscriberCommand(entity));
}
