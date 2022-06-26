namespace Victory.Application.General.Client.Features.Users;

public sealed record class GetUserListQueryHandler
    : IRequestHandler<GetUserListQuery, List<User>?>
{
    private readonly APIFeaturesConfigurationService _apiConfig;

    public GetUserListQueryHandler(APIFeaturesConfigurationService apiConfig) =>
        _apiConfig = apiConfig;

    public async Task<List<User>?> Handle(GetUserListQuery request, CancellationToken token)
    {
        using var httpClient = new HttpClient();

        using var response = await httpClient.GetAsync(
            requestUri: $"{_apiConfig.ServerUrl}/Users",
            cancellationToken: token);

        string apiResponse = await response.Content.ReadAsStringAsync(cancellationToken: token);

        return JsonConvert.DeserializeObject<List<User>>(value: apiResponse);
    }
}