namespace Victory.Application.CQRS.API.UserRoles;

public sealed record class UpdateUserRoleCommandHandler
    : IRequestHandler<UpdateUserRoleCommand>
{
    private readonly ApplicationContext _context;

    public UpdateUserRoleCommandHandler(ApplicationContext context) => _context = context;

    public async Task<Unit> Handle(UpdateUserRoleCommand request, CancellationToken token)
    {
        if (request.UserRole is null) return Unit.Value;

        var entity = await _context.UserRoles.FindAsync(
            keyValues: new object[] { request.UserRole.Id },
            cancellationToken: token);

        if (entity is null) return Unit.Value;

        entity.Id = request.UserRole.Id;
        entity.Name = request.UserRole.Name;

        await _context.SaveChangesAsync(cancellationToken: token);

        return Unit.Value;
    }
}