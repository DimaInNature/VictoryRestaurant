namespace API.Features.Subscribers.Commands;

public sealed record class UpdateMailSubscriberCommandHandler
    : IRequestHandler<UpdateMailSubscriberCommand>
{
    private readonly ApplicationContext _context;

    public UpdateMailSubscriberCommandHandler(ApplicationContext context) => _context = context;

    public async Task<Unit> Handle(UpdateMailSubscriberCommand request, CancellationToken token)
    {
        if (request.MailSubscriber is null) return Unit.Value;

        var entity = await _context.MailSubscribers.FindAsync(
            keyValues: new object[] { request.MailSubscriber.Id },
            cancellationToken: token);

        if (entity is null) return Unit.Value;

        entity.Id = request.MailSubscriber.Id;
        entity.Mail = request.MailSubscriber.Mail;

        await _context.SaveChangesAsync(cancellationToken: token);

        return Unit.Value;
    }
}