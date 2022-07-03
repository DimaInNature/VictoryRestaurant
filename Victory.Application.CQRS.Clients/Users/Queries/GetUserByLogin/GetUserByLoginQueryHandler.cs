namespace Victory.Application.CQRS.Clients.Users;

public sealed record class GetUserByLoginQueryHandler
    : IRequestHandler<GetUserByLoginQuery, User?>
{
    private readonly APIFeaturesConfigurationService _apiConfig;

    public GetUserByLoginQueryHandler(APIFeaturesConfigurationService apiConfig) =>
        _apiConfig = apiConfig;

    public async Task<User?> Handle(GetUserByLoginQuery request, CancellationToken token)
    {
        using var httpClient = new HttpClient();

        using var response = await httpClient.GetAsync(
            requestUri: $"{_apiConfig.ServerUrl}/Users/Login={request.Login}",
            cancellationToken: token);

        string apiResponse = await response.Content.ReadAsStringAsync(cancellationToken: token);

        return JsonConvert.DeserializeObject<User>(value: apiResponse);
    }
}