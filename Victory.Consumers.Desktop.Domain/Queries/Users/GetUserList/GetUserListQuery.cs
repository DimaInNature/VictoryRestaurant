namespace Victory.Consumers.Desktop.Domain.Queries.Users;

public sealed record class GetUserListQuery
    : BaseAuthorizedFeature, IRequest<List<User>?>
{
    public GetUserListQuery(string token) => Token = token;

    public GetUserListQuery() { }
}