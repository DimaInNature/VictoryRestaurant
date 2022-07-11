namespace Victory.Domain.Features.Consumers.UserRoles;

public sealed record class GetUserRoleByIdQueryHandler
    : IRequestHandler<GetUserRoleByIdQuery, UserRole?>
{
    private readonly APIFeaturesConfigurationService _apiConfig;

    public GetUserRoleByIdQueryHandler(APIFeaturesConfigurationService apiConfig) =>
        _apiConfig = apiConfig;

    public async Task<UserRole?> Handle(GetUserRoleByIdQuery request, CancellationToken token)
    {
        if (string.IsNullOrWhiteSpace(value: request.Token)) return null;

        using var httpClient = new HttpClient();

        httpClient.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue(
                scheme: "Bearer",
                parameter: request.Token);

        using var response = await httpClient.GetAsync(
            requestUri: $"{_apiConfig.ServerUrl}/UserRoles/Id={request.Id}",
            cancellationToken: token);

        string apiResponse = await response.Content.ReadAsStringAsync(cancellationToken: token);

        return JsonConvert.DeserializeObject<UserRole>(value: apiResponse);
    }
}