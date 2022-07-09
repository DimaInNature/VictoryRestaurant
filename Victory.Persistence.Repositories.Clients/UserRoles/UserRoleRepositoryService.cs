namespace Victory.Persistence.Repositories.Clients.UserRoles;

public class UserRoleRepositoryService : IUserRoleRepositoryService
{
    private readonly IMediator _mediator;

    public UserRoleRepositoryService(IMediator mediator) => _mediator = mediator;

    public async Task<UserRole?> GetUserRoleAsync(int id, string token) =>
        await _mediator.Send(request: new GetUserRoleByIdQuery(id, token));

    public async Task<List<UserRole>?> GetUserRoleListAsync(string token) =>
        await _mediator.Send(request: new GetUserRoleListQuery(token));
}