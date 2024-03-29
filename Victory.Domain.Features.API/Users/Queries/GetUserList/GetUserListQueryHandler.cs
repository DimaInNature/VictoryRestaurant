﻿namespace Victory.Domain.Features.API.Users;

public sealed record class GetUserListQueryHandler
    : IRequestHandler<GetUserListQuery, List<UserEntity>?>
{
    private readonly ApplicationContext _context;

    public GetUserListQueryHandler(ApplicationContext context) => _context = context;

    public async Task<List<UserEntity>?> Handle(GetUserListQuery request, CancellationToken token) =>
        await _context.Users
        .AsNoTracking()
        .Include(navigationPropertyPath: user => user.UserRole)
        .ToListAsync(cancellationToken: token);
}