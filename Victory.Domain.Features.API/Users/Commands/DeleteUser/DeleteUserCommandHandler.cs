﻿namespace Victory.Domain.Features.API.Users;

public sealed record class DeleteUserCommandHandler
    : IRequestHandler<DeleteUserCommand>
{
    private readonly ApplicationContext _context;

    public DeleteUserCommandHandler(ApplicationContext context) => _context = context;

    public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken token)
    {
        var userFromDb = await _context.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(predicate: user => user.Id == request.Id,
            cancellationToken: token);

        if (userFromDb is null) return Unit.Value;

        _context.Users.Remove(userFromDb);

        await _context.SaveChangesAsync(cancellationToken: token);

        return Unit.Value;
    }
}