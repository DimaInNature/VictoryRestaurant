namespace Victory.Domain.Features.Consumers.Users;

public sealed record class GetUserByLoginAndPasswordQueryHandler
    : IRequestHandler<GetUserByLoginAndPasswordQuery, User?>
{
    private readonly APIFeaturesConfigurationService _apiConfig;

    public GetUserByLoginAndPasswordQueryHandler(APIFeaturesConfigurationService apiConfig) =>
        _apiConfig = apiConfig;

    public async Task<User?> Handle(GetUserByLoginAndPasswordQuery request, CancellationToken token)
    {
        UserLogin? userLogin = request.UserLogin;

        if (userLogin is null ||
            string.IsNullOrWhiteSpace(value: userLogin.Login) ||
            string.IsNullOrWhiteSpace(value: userLogin.Password))
            return null;

        var handler = new HttpClientHandler();
        handler.DefaultProxyCredentials = CredentialCache.DefaultCredentials;

        using var httpClient = new HttpClient(handler);

        using var response = await httpClient.GetAsync(
            requestUri: $"{_apiConfig.ServerUrl}/Users/{userLogin.Login}&{userLogin.Password}",
            cancellationToken: token);

        string apiResponse = await response.Content.ReadAsStringAsync(cancellationToken: token);

        httpClient.DefaultRequestHeaders.ConnectionClose = true;

        var result = JsonConvert.DeserializeObject<User>(value: apiResponse);

        return result;
    }
}