namespace Victory.Domain.Features.Consumers.Authorizations;

public sealed record class UserAuthorizationCommand
    : BaseAnonymousFeature, IRequest<string?>
{
    public UserLogin? UserLogin { get; }

    public UserAuthorizationCommand(UserLogin entity) => UserLogin = entity;

    public UserAuthorizationCommand() { }
}