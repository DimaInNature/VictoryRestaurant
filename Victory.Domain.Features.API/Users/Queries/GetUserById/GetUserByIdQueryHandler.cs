namespace Victory.Domain.Features.API.Users;

public sealed record class GetUserByIdQueryHandler
    : IRequestHandler<GetUserByIdQuery, UserEntity?>
{
    private readonly ApplicationContext _context;

    public GetUserByIdQueryHandler(ApplicationContext context) => _context = context;

    public async Task<UserEntity?> Handle(GetUserByIdQuery request, CancellationToken token) =>
        await _context.Users.AsNoTracking()
        .Include(u => u.UserRole)
        .FirstOrDefaultAsync(predicate: user => user.Id == request.Id,
            cancellationToken: token);
}