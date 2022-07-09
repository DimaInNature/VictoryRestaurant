namespace Victory.Application.CQRS.API.MailSubscribers;

public sealed record class GetMailSubscriberByIdQueryHandler
    : IRequestHandler<GetMailSubscriberByIdQuery, MailSubscriberEntity?>
{
    private readonly ApplicationContext _context;

    public GetMailSubscriberByIdQueryHandler(ApplicationContext context) => _context = context;

    public async Task<MailSubscriberEntity?> Handle(GetMailSubscriberByIdQuery request, CancellationToken token) =>
        await _context.MailSubscribers.AsNoTracking()
        .FirstOrDefaultAsync(predicate: mailSubscriber => mailSubscriber.Id == request.Id,
            cancellationToken: token);
}