namespace Victory.Application.CQRS.API.Users;

public sealed record class GetUserByLoginAndPasswordQueryHandler
    : IRequestHandler<GetUserByLoginAndPasswordQuery, UserEntity?>
{
    private readonly ApplicationContext _context;

    public GetUserByLoginAndPasswordQueryHandler(ApplicationContext context) => _context = context;

    public async Task<UserEntity?> Handle(GetUserByLoginAndPasswordQuery request, CancellationToken token) =>
        await _context.Users.FirstOrDefaultAsync(
            predicate: user => user.Login == request.Login &&
            user.Password == request.Password,
            cancellationToken: token);
}