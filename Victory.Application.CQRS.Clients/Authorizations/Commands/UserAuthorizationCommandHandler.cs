namespace Victory.Application.CQRS.Clients.Authorizations;

public sealed record class UserAuthorizationCommandHandler
    : IRequestHandler<UserAuthorizationCommand, string?>
{
    private readonly APIFeaturesConfigurationService _apiConfig;

    public UserAuthorizationCommandHandler(
        APIFeaturesConfigurationService apiConfig) =>
        _apiConfig = apiConfig;

    public async Task<string?> Handle(UserAuthorizationCommand request, CancellationToken token)
    {
        using var client = new HttpClient();

        string json = JsonConvert.SerializeObject(value: request.UserLogin);

        using var response = await client.PostAsync(
            requestUri: $"{_apiConfig.ServerUrl}/Login",
            content: new StringContent(
                content: json,
                encoding: Encoding.UTF8,
                mediaType: "application/json"),
            cancellationToken: token);

        string apiResponse = await response.Content.ReadAsStringAsync(cancellationToken: token);

        return apiResponse;
    }
}