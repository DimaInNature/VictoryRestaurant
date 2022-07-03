namespace Victory.Application.CQRS.API.Users;

public sealed record class GetUserByIdQueryHandler
    : IRequestHandler<GetUserByIdQuery, UserEntity?>
{
    private readonly ApplicationContext _context;

    public GetUserByIdQueryHandler(ApplicationContext context) => _context = context;

    public async Task<UserEntity?> Handle(GetUserByIdQuery request, CancellationToken token) =>
        await _context.Users.FindAsync(
            keyValues: new object[] { request.Id },
            cancellationToken: token);
}