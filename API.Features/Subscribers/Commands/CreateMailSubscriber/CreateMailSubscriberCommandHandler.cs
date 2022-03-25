namespace API.Features.Subscribers.Commands;

public sealed record class CreateMailSubscriberCommandHandler
    : IRequestHandler<CreateMailSubscriberCommand>
{
    private readonly ApplicationContext _context;

    public CreateMailSubscriberCommandHandler(ApplicationContext context) => _context = context;

    public async Task<Unit> Handle(CreateMailSubscriberCommand request, CancellationToken token)
    {
        if (request.MailSubscriber is null) return Unit.Value;

        await _context.MailSubscribers.AddAsync(
            entity: request.MailSubscriber,
            cancellationToken: token);

        await _context.SaveChangesAsync(cancellationToken: token);

        return Unit.Value;
    }
}