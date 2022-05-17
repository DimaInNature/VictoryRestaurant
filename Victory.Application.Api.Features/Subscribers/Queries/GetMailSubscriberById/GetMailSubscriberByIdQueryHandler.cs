namespace Victory.Application.Api.Features.Subscribers;

public sealed record class GetMailSubscriberByIdQueryHandler
    : IRequestHandler<GetMailSubscriberByIdQuery, MailSubscriberEntity?>
{
    private readonly ApplicationContext _context;

    public GetMailSubscriberByIdQueryHandler(ApplicationContext context) => _context = context;

    public async Task<MailSubscriberEntity?> Handle(GetMailSubscriberByIdQuery request, CancellationToken token) =>
        await _context.MailSubscribers.FindAsync(
            keyValues: new object[] { request.Id },
            cancellationToken: token);
}