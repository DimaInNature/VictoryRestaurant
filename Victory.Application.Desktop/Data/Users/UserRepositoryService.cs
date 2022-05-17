namespace Victory.Application.Desktop.Data.Users;

public sealed class UserRepositoryService : IUserRepositoryService
{
    private readonly IMediator _mediator;

    public UserRepositoryService(IMediator mediator) => _mediator = mediator;

    public async Task<List<User>> GetUserListAsync() =>
        await _mediator.Send(request: new GetUserListQuery()) ?? new();

    public async Task<User?> GetUserAsync(string login) =>
        await _mediator.Send(request: new GetUserByLoginQuery(login));

    public async Task<User?> GetUserAsync(string login, string password) =>
        await _mediator.Send(request: new GetUserByLoginAndPasswordQuery(login, password));

    public async Task CreateAsync(User entity) =>
        await _mediator.Send(request: new CreateUserCommand(entity));

    public async Task UpdateAsync(User entity) =>
        await _mediator.Send(request: new UpdateUserCommand(entity));

    public async Task DeleteAsync(int id) =>
        await _mediator.Send(request: new DeleteUserCommand(id));
}