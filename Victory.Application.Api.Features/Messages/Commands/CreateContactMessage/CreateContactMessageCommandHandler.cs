namespace Victory.Application.Api.Features.Messages;

public sealed record class CreateContactMessageCommandHandler
    : IRequestHandler<CreateContactMessageCommand>
{
    private readonly ApplicationContext _context;

    public CreateContactMessageCommandHandler(ApplicationContext context) => _context = context;

    public async Task<Unit> Handle(CreateContactMessageCommand request, CancellationToken token)
    {
        if (request.ContactMessage is null) return Unit.Value;

        await _context.ContactMessages.AddAsync(
            entity: request.ContactMessage,
            cancellationToken: token);

        await _context.SaveChangesAsync(cancellationToken: token);

        return Unit.Value;
    }
}