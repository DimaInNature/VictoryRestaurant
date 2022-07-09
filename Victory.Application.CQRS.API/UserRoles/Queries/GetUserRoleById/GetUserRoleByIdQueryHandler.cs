namespace Victory.Application.CQRS.API.UserRoles;

public sealed record class GetUserRoleByIdQueryHandler
    : IRequestHandler<GetUserRoleByIdQuery, UserRoleEntity?>
{
    private readonly ApplicationContext _context;

    public GetUserRoleByIdQueryHandler(ApplicationContext context) => _context = context;

    public async Task<UserRoleEntity?> Handle(GetUserRoleByIdQuery request, CancellationToken token) =>
        await _context.UserRoles.AsNoTracking()
        .FirstOrDefaultAsync(predicate: userRole => userRole.Id == request.Id,
            cancellationToken: token);
}