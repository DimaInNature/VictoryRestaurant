namespace Victory.Application.CQRS.API.UserRoles;

public sealed record class GetUserRoleListByNameQuery : IRequest<List<UserRoleEntity>?>
{
    public string? Name { get; }

    public GetUserRoleListByNameQuery(string name) => Name = name;

    public GetUserRoleListByNameQuery() { }
}