namespace Victory.Application.CQRS.API.Users;

public sealed record class GetUserByLoginQuery : IRequest<UserEntity?>
{
    public string? Login { get; }

    public GetUserByLoginQuery(string login) => Login = login;

    public GetUserByLoginQuery() { }
}