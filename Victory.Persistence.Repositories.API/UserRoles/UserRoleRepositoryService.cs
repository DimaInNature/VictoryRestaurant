namespace Victory.Persistence.Repositories.API.UserRoles;

public class UserRoleRepositoryService : IUserRoleRepositoryService
{
    private readonly IMediator _mediator;

    public UserRoleRepositoryService(IMediator mediator) => _mediator = mediator;

    public async Task<List<UserRoleEntity>?> GetUserRoleListAsync() =>
        await _mediator.Send(request: new GetUserRoleListQuery());

    public async Task<List<UserRoleEntity>?> GetUserRoleListAsync(string name) =>
        await _mediator.Send(request: new GetUserRoleListByNameQuery(name));

    public async Task<UserRoleEntity?> GetUserRoleAsync(int id) =>
        await _mediator.Send(request: new GetUserRoleByIdQuery(id));

    public async Task CreateAsync(UserRoleEntity entity) =>
        await _mediator.Send(request: new CreateUserRoleCommand(entity));

    public async Task UpdateAsync(UserRoleEntity entity) =>
        await _mediator.Send(request: new UpdateUserRoleCommand(entity));

    public async Task DeleteAsync(int id) =>
        await _mediator.Send(request: new DeleteUserRoleCommand(id));
}