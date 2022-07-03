namespace Victory.Application.CQRS.Clients.UserRoles;

public sealed record class GetUserRoleByIdQueryHandler
    : IRequestHandler<GetUserRoleByIdQuery, UserRole?>
{
    private readonly APIFeaturesConfigurationService _apiConfig;

    public GetUserRoleByIdQueryHandler(APIFeaturesConfigurationService apiConfig) =>
        _apiConfig = apiConfig;

    public async Task<UserRole?> Handle(GetUserRoleByIdQuery request, CancellationToken token)
    {
        using var httpClient = new HttpClient();

        using var response = await httpClient.GetAsync(
            requestUri: $"{_apiConfig.ServerUrl}/UserRoles/Id={request.Id}",
            cancellationToken: token);

        string apiResponse = await response.Content.ReadAsStringAsync(cancellationToken: token);

        return JsonConvert.DeserializeObject<UserRole>(value: apiResponse);
    }
}