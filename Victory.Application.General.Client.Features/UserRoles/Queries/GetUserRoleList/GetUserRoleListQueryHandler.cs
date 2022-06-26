namespace Victory.Application.General.Client.Features.UserRoles;

public sealed record class GetUserRoleListQueryHandler
    : IRequestHandler<GetUserRoleListQuery, List<UserRole>?>
{
    private readonly APIFeaturesConfigurationService _apiConfig;

    public GetUserRoleListQueryHandler(APIFeaturesConfigurationService apiConfig) =>
        _apiConfig = apiConfig;

    public async Task<List<UserRole>?> Handle(GetUserRoleListQuery request, CancellationToken token)
    {
        using var httpClient = new HttpClient();

        using var response = await httpClient.GetAsync(
            requestUri: $"{_apiConfig.ServerUrl}/UserRoles",
            cancellationToken: token);

        string apiResponse = await response.Content.ReadAsStringAsync(cancellationToken: token);

        return JsonConvert.DeserializeObject<List<UserRole>>(value: apiResponse);
    }
}