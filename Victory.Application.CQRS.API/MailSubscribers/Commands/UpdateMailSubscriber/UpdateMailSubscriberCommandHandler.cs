namespace Victory.Application.CQRS.API.MailSubscribers;

public sealed record class UpdateMailSubscriberCommandHandler
    : IRequestHandler<UpdateMailSubscriberCommand>
{
    private readonly ApplicationContext _context;

    public UpdateMailSubscriberCommandHandler(ApplicationContext context) => _context = context;

    public async Task<Unit> Handle(UpdateMailSubscriberCommand request, CancellationToken token)
    {
        if (request.MailSubscriber is null) return Unit.Value;

        _context.MailSubscribers.Attach(entity: request.MailSubscriber);

        _context.Entry(entity: request.MailSubscriber).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync(cancellationToken: token);
        }
        catch { }

        return Unit.Value;
    }
}