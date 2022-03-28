namespace API.Features.Users.Commands;

public sealed record class UpdateUserCommandHandler
    : IRequestHandler<UpdateUserCommand>
{
    private readonly ApplicationContext _context;

    public UpdateUserCommandHandler(ApplicationContext context) => _context = context;

    public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken token)
    {
        if (request.User is null) return Unit.Value;

        var userFromDb = await _context.Users.FindAsync(
            keyValues: new object[] { request.User.Id },
            cancellationToken: token);

        if (userFromDb is null) return Unit.Value;

        userFromDb.Id = request.User.Id;
        userFromDb.Login = request.User.Login;
        userFromDb.Password = request.User.Password;
        userFromDb.Role = request.User.Role;

        await _context.SaveChangesAsync(cancellationToken: token);

        return Unit.Value;
    }
}