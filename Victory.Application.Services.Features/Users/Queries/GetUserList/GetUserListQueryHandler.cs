namespace Victory.Application.Services.Features.Users;

public sealed record class GetUserListQueryHandler
    : IRequestHandler<GetUserListQuery, List<UserEntity>?>
{
    private readonly ApplicationContext _context;

    public GetUserListQueryHandler(ApplicationContext context) => _context = context;

    public async Task<List<UserEntity>?> Handle(GetUserListQuery request, CancellationToken token) =>
        await _context.Users.ToListAsync(cancellationToken: token);
}