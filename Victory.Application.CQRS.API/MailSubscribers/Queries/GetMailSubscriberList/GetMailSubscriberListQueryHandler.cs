namespace Victory.Application.CQRS.API.MailSubscribers;

public sealed record class GetMailSubscriberListQueryHandler
    : IRequestHandler<GetMailSubscriberListQuery, List<MailSubscriberEntity>?>
{
    private readonly ApplicationContext _context;

    public GetMailSubscriberListQueryHandler(ApplicationContext context) => _context = context;

    public async Task<List<MailSubscriberEntity>?> Handle(GetMailSubscriberListQuery request, CancellationToken token) =>
        await _context.MailSubscribers.AsNoTracking().ToListAsync(cancellationToken: token);
}