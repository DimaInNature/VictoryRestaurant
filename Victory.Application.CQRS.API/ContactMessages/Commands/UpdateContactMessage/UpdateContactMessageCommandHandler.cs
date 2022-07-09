namespace Victory.Application.CQRS.API.ContactMessages;

public sealed record class UpdateContactMessageCommandHandler
    : IRequestHandler<UpdateContactMessageCommand>
{
    private readonly ApplicationContext _context;

    public UpdateContactMessageCommandHandler(ApplicationContext context) => _context = context;

    public async Task<Unit> Handle(UpdateContactMessageCommand request, CancellationToken token)
    {
        if (request.ContactMessage is null) return Unit.Value;

        _context.ContactMessages.Attach(entity: request.ContactMessage);

        _context.Entry(entity: request.ContactMessage).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync(cancellationToken: token);
        }
        catch { }

        return Unit.Value;
    }
}