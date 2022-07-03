namespace Victory.Application.CQRS.Clients.Users;

public sealed record class CreateUserCommandHandler
    : IRequestHandler<CreateUserCommand>
{
    private readonly APIFeaturesConfigurationService _apiConfig;

    public CreateUserCommandHandler(APIFeaturesConfigurationService apiConfig) =>
        _apiConfig = apiConfig;

    public async Task<Unit> Handle(CreateUserCommand request, CancellationToken token)
    {
        using var client = new HttpClient();

        string json = JsonConvert.SerializeObject(value: request.User);

        await client.PostAsync(
            requestUri: $"{_apiConfig.ServerUrl}/Users",
            content: new StringContent(
                content: json,
                encoding: Encoding.UTF8,
                mediaType: "application/json"),
            cancellationToken: token);

        return Unit.Value;
    }
}