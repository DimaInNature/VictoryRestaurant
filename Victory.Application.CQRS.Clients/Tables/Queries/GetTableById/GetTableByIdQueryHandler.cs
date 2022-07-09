namespace Victory.Application.CQRS.Clients.Tables;

public sealed record class GetTableByIdQueryHandler
    : IRequestHandler<GetTableByIdQuery, Table?>
{
    private readonly APIFeaturesConfigurationService _apiConfig;

    public GetTableByIdQueryHandler(APIFeaturesConfigurationService apiConfig) =>
        _apiConfig = apiConfig;

    public async Task<Table?> Handle(GetTableByIdQuery request, CancellationToken token)
    {
        if (string.IsNullOrWhiteSpace(value: request.Token)) return new();

        using var httpClient = new HttpClient();

        httpClient.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue(
                scheme: "Bearer",
                parameter: request.Token);

        using var response = await httpClient.GetAsync(
            requestUri: $"{_apiConfig.ServerUrl}/Tables/Id={request.Id}",
            cancellationToken: token);

        string apiResponse = await response.Content.ReadAsStringAsync(cancellationToken: token);

        return JsonConvert.DeserializeObject<Table>(value: apiResponse);
    }
}