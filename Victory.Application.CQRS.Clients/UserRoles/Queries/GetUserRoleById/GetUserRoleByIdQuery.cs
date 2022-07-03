namespace Victory.Application.CQRS.Clients.UserRoles;

public sealed record class GetUserRoleByIdQuery : IRequest<UserRole?>
{
    public int Id { get; }

    public GetUserRoleByIdQuery(int id) => Id = id;

    public GetUserRoleByIdQuery() { }
}