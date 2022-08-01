namespace Victory.Consumers.Desktop.Domain.Queries.Users;

public sealed record class GetUserByLoginQuery
    : BaseAuthorizedFeature, IRequest<User?>
{
    public string? Login { get; }

    public GetUserByLoginQuery(string login, string token) =>
        (Login, Token) = (login, token);

    public GetUserByLoginQuery() { }
}