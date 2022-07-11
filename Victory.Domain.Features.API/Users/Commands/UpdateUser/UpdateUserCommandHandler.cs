namespace Victory.Domain.Features.API.Users;

public sealed record class UpdateUserCommandHandler
    : IRequestHandler<UpdateUserCommand>
{
    private readonly ApplicationContext _context;

    public UpdateUserCommandHandler(ApplicationContext context) => _context = context;

    public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken token)
    {
        if (request.User is null) return Unit.Value;

        _context.Users.Attach(entity: request.User);

        _context.Entry(entity: request.User).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync(cancellationToken: token);
        }
        catch { }

        return Unit.Value;
    }
}