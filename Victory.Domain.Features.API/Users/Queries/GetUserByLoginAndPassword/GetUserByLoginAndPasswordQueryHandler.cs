namespace Victory.Domain.Features.API.Users;

public sealed record class GetUserByLoginAndPasswordQueryHandler
    : IRequestHandler<GetUserByLoginAndPasswordQuery, UserEntity?>
{
    private readonly ApplicationContext _context;

    public GetUserByLoginAndPasswordQueryHandler(ApplicationContext context) => _context = context;

    public async Task<UserEntity?> Handle(GetUserByLoginAndPasswordQuery request, CancellationToken token)
    {
        UserLogin? userLogin = request.UserLogin;

        if (userLogin is null || string.IsNullOrWhiteSpace(value: userLogin.Login) ||
            string.IsNullOrWhiteSpace(value: userLogin.Password))
            return null;

        UserEntity? result = await _context.Users
            .AsNoTracking()
            .Include(navigationPropertyPath: u => u.UserRole)
            .FirstOrDefaultAsync(
            predicate: user => user.Login == userLogin.Login &&
            user.Password == userLogin.Password,
            cancellationToken: token);

        return result;
    }
}