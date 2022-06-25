namespace Victory.Application.API.Features.UserRoles;

public sealed record class GetUserRoleListByNameQuery : IRequest<List<UserRoleEntity>?>
{
    public string? Name { get; }

    public GetUserRoleListByNameQuery(string name) => Name = name;

    public GetUserRoleListByNameQuery() { }
}