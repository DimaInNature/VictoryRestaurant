namespace Victory.Application.API.Features.MailSubscribers;

public sealed record class GetMailSubscriberListQueryHandler
    : IRequestHandler<GetMailSubscriberListQuery, List<MailSubscriberEntity>?>
{
    private readonly ApplicationContext _context;

    public GetMailSubscriberListQueryHandler(ApplicationContext context) => _context = context;

    public async Task<List<MailSubscriberEntity>?> Handle(GetMailSubscriberListQuery request, CancellationToken token) =>
        await _context.MailSubscribers.ToListAsync(cancellationToken: token);
}