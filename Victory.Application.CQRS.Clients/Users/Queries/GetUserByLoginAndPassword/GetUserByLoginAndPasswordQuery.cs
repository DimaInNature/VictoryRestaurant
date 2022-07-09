namespace Victory.Application.CQRS.Clients.Users;

public sealed record class GetUserByLoginAndPasswordQuery
    : BaseAnonymousFeature, IRequest<User?>
{
    public UserLogin? UserLogin { get; }

    public GetUserByLoginAndPasswordQuery(UserLogin userLogin) => UserLogin = userLogin;

    public GetUserByLoginAndPasswordQuery() { }
}