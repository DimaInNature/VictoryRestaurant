namespace Victory.Application.Features.Users;

public sealed record class GetUserByLoginAndPasswordQuery : IRequest<User?>
{
    public string? Login { get; }

    public string? Password { get; }

    public GetUserByLoginAndPasswordQuery(string login, string password) => (Login, Password) = (login, password);

    public GetUserByLoginAndPasswordQuery() { }
}