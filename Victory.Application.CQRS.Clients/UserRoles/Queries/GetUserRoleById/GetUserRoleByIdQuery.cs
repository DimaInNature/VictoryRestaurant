namespace Victory.Application.CQRS.Clients.UserRoles;

public sealed record class GetUserRoleByIdQuery
    : BaseAuthorizedFeature, IRequest<UserRole?>
{
    public int Id { get; }

    public GetUserRoleByIdQuery(int id, string token) => (Id, Token) = (id, token);

    public GetUserRoleByIdQuery() { }
}