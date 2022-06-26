namespace Victory.Application.General.Client.Features.Users;

public sealed record class GetUserByLoginAndPasswordQueryHandler
    : IRequestHandler<GetUserByLoginAndPasswordQuery, User?>
{
    private readonly APIFeaturesConfigurationService _apiConfig;

    public GetUserByLoginAndPasswordQueryHandler(APIFeaturesConfigurationService apiConfig) =>
        _apiConfig = apiConfig;

    public async Task<User?> Handle(GetUserByLoginAndPasswordQuery request, CancellationToken token)
    {
        var handler = new HttpClientHandler();
        handler.DefaultProxyCredentials = CredentialCache.DefaultCredentials;

        using var httpClient = new HttpClient(handler);

        using var response = await httpClient.GetAsync(
            requestUri: $"{_apiConfig.ServerUrl}/Users/{request.Login}&{request.Password}",
            cancellationToken: token);

        string apiResponse = await response.Content.ReadAsStringAsync(cancellationToken: token);

        httpClient.DefaultRequestHeaders.ConnectionClose = true;

        return JsonConvert.DeserializeObject<User>(value: apiResponse);
    }
}