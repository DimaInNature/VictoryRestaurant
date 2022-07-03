namespace Victory.Application.CQRS.API.UserRoles;

public sealed record class GetUserRoleByIdQuery : IRequest<UserRoleEntity?>
{
    public int Id { get; }

    public GetUserRoleByIdQuery(int id) => Id = id;

    public GetUserRoleByIdQuery() { }
}