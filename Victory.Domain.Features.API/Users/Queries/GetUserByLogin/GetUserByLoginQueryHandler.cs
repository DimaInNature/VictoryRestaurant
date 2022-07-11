namespace Victory.Domain.Features.API.Users;

public sealed record class GetUserByLoginQueryHandler
    : IRequestHandler<GetUserByLoginQuery, UserEntity?>
{
    private readonly ApplicationContext _context;

    public GetUserByLoginQueryHandler(ApplicationContext context) => _context = context;

    public async Task<UserEntity?> Handle(GetUserByLoginQuery request, CancellationToken token) =>
        await _context.Users.FirstOrDefaultAsync(
            predicate: user => user.Login == request.Login,
            cancellationToken: token);
}