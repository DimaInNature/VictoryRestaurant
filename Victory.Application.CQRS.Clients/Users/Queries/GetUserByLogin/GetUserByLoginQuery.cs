namespace Victory.Application.CQRS.Clients.Users;

public sealed record class GetUserByLoginQuery : IRequest<User?>
{
    public string? Login { get; }

    public GetUserByLoginQuery(string login) => Login = login;

    public GetUserByLoginQuery() { }
}