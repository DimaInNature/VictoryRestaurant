namespace Victory.Consumers.Desktop.Application.Services.UserRoles;

public class UserRoleService : IUserRoleService
{
    private readonly IMediator _mediator;

    public UserRoleService(IMediator mediator) => _mediator = mediator;

    public async Task<UserRole?> GetUserRoleAsync(int id, string token) =>
        await _mediator.Send(request: new GetUserRoleByIdQuery(id, token));

    public async Task<List<UserRole>?> GetUserRoleListAsync(string token) =>
        await _mediator.Send(request: new GetUserRoleListQuery(token));
}