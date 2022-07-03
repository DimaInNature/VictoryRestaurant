namespace Victory.Persistence.Repositories.Clients.UserRoles;

public class UserRoleRepositoryService : IUserRoleRepositoryService
{
    private readonly IMediator _mediator;

    public UserRoleRepositoryService(IMediator mediator) => _mediator = mediator;

    public async Task<UserRole?> GetUserRoleAsync(int id) =>
        await _mediator.Send(request: new GetUserRoleByIdQuery());

    public async Task<List<UserRole>?> GetUserRoleListAsync() =>
        await _mediator.Send(request: new GetUserRoleListQuery());
}