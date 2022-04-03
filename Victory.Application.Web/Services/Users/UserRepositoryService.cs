namespace Victory.Application.Web.Services;

public class UserRepositoryService : IUserRepositoryService
{
    private readonly IMediator _mediator;

    public UserRepositoryService(IMediator mediator) => _mediator = mediator;

    public async Task<User?> GetUserAsync(string login) =>
        await _mediator.Send(request: new GetUserByLoginQuery(login: login));

    public async Task<User?> GetUserAsync(string login, string password) =>
       await _mediator.Send(request: new GetUserByLoginAndPasswordQuery(login, password));

    public async Task CreateAsync(User entity) =>
        await _mediator.Send(request: new CreateUserCommand(entity));
}