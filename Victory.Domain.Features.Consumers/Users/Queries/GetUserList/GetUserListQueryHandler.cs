namespace Victory.Domain.Features.Consumers.Users;

public sealed record class GetUserListQueryHandler
    : IRequestHandler<GetUserListQuery, List<User>?>
{
    private readonly APIFeaturesConfigurationService _apiConfig;

    public GetUserListQueryHandler(APIFeaturesConfigurationService apiConfig) =>
        _apiConfig = apiConfig;

    public async Task<List<User>?> Handle(GetUserListQuery request, CancellationToken token)
    {
        if (string.IsNullOrWhiteSpace(value: request.Token)) return new();

        using var httpClient = new HttpClient();

        httpClient.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue(
                scheme: "Bearer",
                parameter: request.Token);

        using var response = await httpClient.GetAsync(
            requestUri: $"{_apiConfig.ServerUrl}/Users",
            cancellationToken: token);

        string apiResponse = await response.Content.ReadAsStringAsync(cancellationToken: token);

        return JsonConvert.DeserializeObject<List<User>>(value: apiResponse);
    }
}