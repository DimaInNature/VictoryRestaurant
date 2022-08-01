namespace Victory.Consumers.Desktop.Domain.Queries.UserRoles;

public sealed record class GetUserRoleListQuery
    : BaseAuthorizedFeature, IRequest<List<UserRole>?>
{
    public GetUserRoleListQuery(string token) => Token = token;

    public GetUserRoleListQuery() { }
}