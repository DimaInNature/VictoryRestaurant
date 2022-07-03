namespace Victory.Application.CQRS.API.UserRoles;

public sealed record class GetUserRoleListByNameQueryHandler
    : IRequestHandler<GetUserRoleListByNameQuery, List<UserRoleEntity>?>
{
    private readonly ApplicationContext _context;

    public GetUserRoleListByNameQueryHandler(ApplicationContext context) => _context = context;

    public async Task<List<UserRoleEntity>?> Handle(GetUserRoleListByNameQuery request, CancellationToken token) =>
        await _context.UserRoles.Where(
            predicate: userRole => userRole.Name.Contains(request.Name ?? string.Empty))
        .ToListAsync(cancellationToken: token);
}