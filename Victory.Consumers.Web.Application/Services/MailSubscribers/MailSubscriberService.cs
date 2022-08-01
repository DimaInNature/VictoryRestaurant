namespace Victory.Consumers.Web.Application.Services.MailSubscribers;

public class MailSubscriberService : IMailSubscriberService
{
    private readonly IMediator _mediator;

    public MailSubscriberService(IMediator mediator) =>
        _mediator = mediator;

    public async Task CreateAsync(MailSubscriber entity) =>
        await _mediator.Send(request: new CreateMailSubscriberCommand(entity));
}