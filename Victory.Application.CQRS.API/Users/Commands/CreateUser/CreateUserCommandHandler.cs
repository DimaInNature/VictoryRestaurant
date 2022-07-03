namespace Victory.Application.CQRS.API.Users;

public sealed record class CreateUserCommandHandler
    : IRequestHandler<CreateUserCommand>
{
    private readonly ApplicationContext _context;

    public CreateUserCommandHandler(ApplicationContext context) => _context = context;

    public async Task<Unit> Handle(CreateUserCommand request, CancellationToken token)
    {
        if (request.User is null) return Unit.Value;

        await _context.Users.AddAsync(entity: request.User, cancellationToken: token);

        await _context.SaveChangesAsync(cancellationToken: token);

        return Unit.Value;
    }
}