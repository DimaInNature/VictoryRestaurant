namespace Victory.Application.CQRS.API.ContactMessages;

public sealed record class GetContactMessageByIdQueryHandler
    : IRequestHandler<GetContactMessageByIdQuery, ContactMessageEntity?>
{
    private readonly ApplicationContext _context;

    public GetContactMessageByIdQueryHandler(ApplicationContext context) => _context = context;

    public async Task<ContactMessageEntity?> Handle(GetContactMessageByIdQuery request, CancellationToken token) =>
        await _context.ContactMessages.AsNoTracking()
        .FirstOrDefaultAsync(predicate: contactMessage => contactMessage.Id == request.Id,
            cancellationToken: token);
}