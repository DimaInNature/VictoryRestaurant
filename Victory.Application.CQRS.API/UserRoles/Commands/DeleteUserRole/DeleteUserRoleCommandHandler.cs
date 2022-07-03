namespace Victory.Application.CQRS.API.UserRoles;

public sealed record class DeleteUserRoleCommandHandler
    : IRequestHandler<DeleteUserRoleCommand>
{
    private readonly ApplicationContext _context;

    public DeleteUserRoleCommandHandler(ApplicationContext context) => _context = context;

    public async Task<Unit> Handle(DeleteUserRoleCommand request, CancellationToken token)
    {
        var userRoleFromDb = await _context.UserRoles.FindAsync(
            keyValues: new object[] { request.Id },
            cancellationToken: token);

        if (userRoleFromDb is null) return Unit.Value;

        _context.UserRoles.Remove(userRoleFromDb);

        await _context.SaveChangesAsync(cancellationToken: token);

        return Unit.Value;
    }
}