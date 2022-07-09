namespace Victory.Application.CQRS.Clients.Users;

public sealed record class GetUserByLoginQuery
    : BaseAuthorizedFeature, IRequest<User?>
{
    public string? Login { get; }

    public GetUserByLoginQuery(string login, string token) =>
        (Login, Token) = (login, token);

    public GetUserByLoginQuery() { }
}