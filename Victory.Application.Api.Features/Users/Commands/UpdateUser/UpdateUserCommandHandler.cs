namespace Victory.Application.API.Features.Users;

public sealed record class UpdateUserCommandHandler
    : IRequestHandler<UpdateUserCommand>
{
    private readonly ApplicationContext _context;

    public UpdateUserCommandHandler(ApplicationContext context) => _context = context;

    public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken token)
    {
        if (request.User is null) return Unit.Value;

        var entityFromDb = await _context.Users.FindAsync(
            keyValues: new object[] { request.User.Id },
            cancellationToken: token);

        if (entityFromDb is null) return Unit.Value;

        entityFromDb.Id = request.User.Id;
        entityFromDb.Login = request.User.Login;
        entityFromDb.Password = request.User.Password;
        entityFromDb.UserRoleId = request.User.UserRoleId;

        await _context.SaveChangesAsync(cancellationToken: token);

        return Unit.Value;
    }
}