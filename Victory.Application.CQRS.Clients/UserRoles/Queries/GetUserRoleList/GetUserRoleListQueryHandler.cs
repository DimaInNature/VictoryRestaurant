namespace Victory.Application.CQRS.Clients.UserRoles;

public sealed record class GetUserRoleListQueryHandler
    : IRequestHandler<GetUserRoleListQuery, List<UserRole>?>
{
    private readonly APIFeaturesConfigurationService _apiConfig;

    public GetUserRoleListQueryHandler(APIFeaturesConfigurationService apiConfig) =>
        _apiConfig = apiConfig;

    public async Task<List<UserRole>?> Handle(GetUserRoleListQuery request, CancellationToken token)
    {
        if (string.IsNullOrWhiteSpace(value: request.Token)) return new();

        using var httpClient = new HttpClient();

        httpClient.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue(
                scheme: "Bearer",
                parameter: request.Token);

        using var response = await httpClient.GetAsync(
            requestUri: $"{_apiConfig.ServerUrl}/UserRoles",
            cancellationToken: token);

        string apiResponse = await response.Content.ReadAsStringAsync(cancellationToken: token);

        return JsonConvert.DeserializeObject<List<UserRole>>(value: apiResponse);
    }
}