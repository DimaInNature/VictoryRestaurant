namespace API.Services.Users;

public class UserRepositoryService : IUserRepositoryService
{
    private readonly IMediator _mediator;

    public UserRepositoryService(IMediator mediator) => _mediator = mediator;

    public async Task<List<UserEntity>?> GetUserListAsync() =>
        await _mediator.Send(request: new GetUserListQuery());

    public async Task<UserEntity?> GetUserAsync(int userId) =>
         await _mediator.Send(request: new GetUserByIdQuery(id: userId));

    public async Task<UserEntity?> GetUserAsync(string login) =>
         await _mediator.Send(request: new GetUserByLoginQuery(login: login));

    public async Task<UserEntity?> GetUserAsync(string login, string password) =>
        await _mediator.Send(request: new GetUserByLoginAndPasswordQuery(login: login, password: password));

    public async Task CreateAsync(UserEntity user) =>
         await _mediator.Send(request: new CreateUserCommand(user: user));

    public async Task UpdateAsync(UserEntity user) =>
        await _mediator.Send(request: new UpdateUserCommand(user: user));

    public async Task DeleteAsync(int userId) =>
        await _mediator.Send(request: new DeleteUserCommand(id: userId));
}