namespace Victory.Application.Api.Features.Subscribers;

public sealed record class DeleteMailSubscriberCommandHandler
    : IRequestHandler<DeleteMailSubscriberCommand>
{
    private readonly ApplicationContext _context;

    public DeleteMailSubscriberCommandHandler(ApplicationContext context) => _context = context;

    public async Task<Unit> Handle(DeleteMailSubscriberCommand request, CancellationToken token)
    {
        var mailSubscriberFromDb = await _context.MailSubscribers.FindAsync(
            keyValues: new object[] { request.Id },
            cancellationToken: token);

        if (mailSubscriberFromDb is null) return Unit.Value;

        _context.MailSubscribers.Remove(mailSubscriberFromDb);

        await _context.SaveChangesAsync(cancellationToken: token);

        return Unit.Value;
    }
}