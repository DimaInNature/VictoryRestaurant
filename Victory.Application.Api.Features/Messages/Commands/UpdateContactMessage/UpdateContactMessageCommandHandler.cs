namespace Victory.Application.Api.Features.Messages;

public sealed record class UpdateContactMessageCommandHandler
    : IRequestHandler<UpdateContactMessageCommand>
{
    private readonly ApplicationContext _context;

    public UpdateContactMessageCommandHandler(ApplicationContext context) => _context = context;

    public async Task<Unit> Handle(UpdateContactMessageCommand request, CancellationToken token)
    {
        if (request.ContactMessage is null) return Unit.Value;

        var entity = await _context.ContactMessages.FindAsync(
            keyValues: new object[] { request.ContactMessage.Id },
            cancellationToken: token);

        if (entity is null) return Unit.Value;

        entity.Id = request.ContactMessage.Id;
        entity.Phone = request.ContactMessage.Phone;
        entity.Message = request.ContactMessage.Message;
        entity.Mail = request.ContactMessage.Mail;
        entity.Name = request.ContactMessage.Name;

        await _context.SaveChangesAsync(cancellationToken: token);

        return Unit.Value;
    }
}