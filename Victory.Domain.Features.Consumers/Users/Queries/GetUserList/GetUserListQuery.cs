namespace Victory.Domain.Features.Consumers.Users;

public sealed record class GetUserListQuery
    : BaseAuthorizedFeature, IRequest<List<User>?>
{
    public GetUserListQuery(string token) => Token = token;

    public GetUserListQuery() { }
}