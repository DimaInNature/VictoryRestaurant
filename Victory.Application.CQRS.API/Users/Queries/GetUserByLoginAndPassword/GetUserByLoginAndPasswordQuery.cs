namespace Victory.Application.CQRS.API.Users;

public sealed record class GetUserByLoginAndPasswordQuery : IRequest<UserEntity>
{
    public UserLogin? UserLogin { get; }

    public GetUserByLoginAndPasswordQuery(UserLogin userLogin) => UserLogin = userLogin;

    public GetUserByLoginAndPasswordQuery() { }
}