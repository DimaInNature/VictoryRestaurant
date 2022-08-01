namespace Victory.Consumers.Desktop.Application.Services.Authorizations.JWT;

public class JWTAuthorizationService
{
    private readonly IMediator _mediator;

    public JWTAuthorizationService(IMediator mediator) => _mediator = mediator;

    public async Task<string?> Authorize(UserLogin userLogin)
    {
        string? token = await _mediator.Send(request: new UserAuthorizationCommand(userLogin));

        return token;
    }
}