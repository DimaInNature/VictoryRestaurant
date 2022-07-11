namespace Victory.Domain.Features.API.UserRoles;

public sealed record class UpdateUserRoleCommandHandler
    : IRequestHandler<UpdateUserRoleCommand>
{
    private readonly ApplicationContext _context;

    public UpdateUserRoleCommandHandler(ApplicationContext context) => _context = context;

    public async Task<Unit> Handle(UpdateUserRoleCommand request, CancellationToken token)
    {
        if (request.UserRole is null) return Unit.Value;

        _context.UserRoles.Attach(entity: request.UserRole);

        _context.Entry(entity: request.UserRole).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync(cancellationToken: token);
        }
        catch { }

        return Unit.Value;
    }
}