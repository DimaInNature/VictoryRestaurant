namespace Victory.Consumers.Desktop.Application.Services.Users;

public sealed class UserService : IUserService
{
    private readonly IMediator _mediator;

    public UserService(IMediator mediator) => _mediator = mediator;

    public async Task<List<User>> GetUserListAsync(string token) =>
        await _mediator.Send(request: new GetUserListQuery(token)) ?? new();

    public async Task<User?> GetUserAsync(string login, string token) =>
        await _mediator.Send(request: new GetUserByLoginQuery(login, token));

    public async Task<User?> GetUserAsync(UserLogin userLogin) =>
        await _mediator.Send(request: new GetUserByLoginAndPasswordQuery(userLogin));

    public async Task<User?> CreateAsync(User entity) =>
        await _mediator.Send(request: new CreateUserCommand(entity));

    public async Task UpdateAsync(User entity, string token) =>
        await _mediator.Send(request: new UpdateUserCommand(entity, token));

    public async Task DeleteAsync(int id, string token) =>
        await _mediator.Send(request: new DeleteUserCommand(id, token));
}