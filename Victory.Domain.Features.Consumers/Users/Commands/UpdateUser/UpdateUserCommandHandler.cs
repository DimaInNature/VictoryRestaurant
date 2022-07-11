namespace Victory.Domain.Features.Consumers.Users;

public sealed record class UpdateUserCommandHandler
    : IRequestHandler<UpdateUserCommand>
{
    private readonly APIFeaturesConfigurationService _apiConfig;

    public UpdateUserCommandHandler(APIFeaturesConfigurationService apiConfig) =>
        _apiConfig = apiConfig;

    public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken token)
    {
        if (request.User is null || string.IsNullOrWhiteSpace(value: request.Token))
            return Unit.Value;

        using var httpClient = new HttpClient();

        httpClient.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue(
                scheme: "Bearer",
                parameter: request.Token);

        string json = JsonConvert.SerializeObject(value: request.User);

        await httpClient.PutAsync(
            requestUri: $"{_apiConfig.ServerUrl}/Users",
            content: new StringContent(
                content: json,
                encoding: Encoding.UTF8,
                mediaType: "application/json"),
            cancellationToken: token);

        return Unit.Value;
    }
}