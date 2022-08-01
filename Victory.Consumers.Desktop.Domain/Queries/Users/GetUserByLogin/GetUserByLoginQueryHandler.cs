namespace Victory.Consumers.Desktop.Domain.Queries.Users;

public sealed record class GetUserByLoginQueryHandler
    : IRequestHandler<GetUserByLoginQuery, User?>
{
    private readonly APIFeaturesConfigurationService _apiConfig;

    public GetUserByLoginQueryHandler(APIFeaturesConfigurationService apiConfig) =>
        _apiConfig = apiConfig;

    public async Task<User?> Handle(
        GetUserByLoginQuery request,
        CancellationToken token)
    {
        if (string.IsNullOrWhiteSpace(request.Login) ||
            string.IsNullOrWhiteSpace(request.Token))
            return null;

        using var httpClient = new HttpClient();

        httpClient.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue(
                scheme: "Bearer",
                parameter: request.Token);

        using var response = await httpClient.GetAsync(
            requestUri: $"{_apiConfig.ServerUrl}/Users/Login={request.Login}",
            cancellationToken: token);

        string apiResponse = await response.Content.ReadAsStringAsync(cancellationToken: token);

        return JsonConvert.DeserializeObject<User>(value: apiResponse);
    }
}