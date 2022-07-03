namespace Victory.Application.CQRS.API.UserRoles;

public sealed record class GetUserRoleListQueryHandler
    : IRequestHandler<GetUserRoleListQuery, List<UserRoleEntity>?>
{
    private readonly ApplicationContext _context;

    public GetUserRoleListQueryHandler(ApplicationContext context) => _context = context;

    public async Task<List<UserRoleEntity>?> Handle(GetUserRoleListQuery request, CancellationToken token) =>
        await _context.UserRoles.ToListAsync(cancellationToken: token);
}