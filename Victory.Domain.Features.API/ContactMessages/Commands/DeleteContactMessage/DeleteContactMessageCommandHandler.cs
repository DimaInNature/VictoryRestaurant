namespace Victory.Domain.Features.API.ContactMessages;

public sealed record class DeleteContactMessageCommandHandler
    : IRequestHandler<DeleteContactMessageCommand>
{
    private readonly ApplicationContext _context;

    public DeleteContactMessageCommandHandler(ApplicationContext context) => _context = context;

    public async Task<Unit> Handle(DeleteContactMessageCommand request, CancellationToken token)
    {
        var contactMessageFromDb = await _context.ContactMessages.FindAsync(
            keyValues: new object[] { request.Id },
            cancellationToken: token);

        if (contactMessageFromDb is null) return Unit.Value;

        _context.ContactMessages.Remove(contactMessageFromDb);

        await _context.SaveChangesAsync(cancellationToken: token);

        return Unit.Value;
    }
}