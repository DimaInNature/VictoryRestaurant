namespace Victory.Application.API.Features.UserRoles;

public sealed record class CreateUserRoleCommandHandler
    : IRequestHandler<CreateUserRoleCommand>
{
    private readonly ApplicationContext _context;

    public CreateUserRoleCommandHandler(ApplicationContext context) => _context = context;

    public async Task<Unit> Handle(CreateUserRoleCommand request, CancellationToken token)
    {
        if (request.UserRole is null) return Unit.Value;

        await _context.UserRoles.AddAsync(
            entity: request.UserRole,
            cancellationToken: token);

        await _context.SaveChangesAsync(cancellationToken: token);

        return Unit.Value;
    }
}