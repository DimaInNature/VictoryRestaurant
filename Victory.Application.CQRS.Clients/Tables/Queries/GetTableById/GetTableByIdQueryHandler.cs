namespace Victory.Application.CQRS.Clients.Tables;

public sealed record class GetTableByIdQueryHandler
    : IRequestHandler<GetTableByIdQuery, Table?>
{
    private readonly APIFeaturesConfigurationService _apiConfig;

    public GetTableByIdQueryHandler(APIFeaturesConfigurationService apiConfig) =>
        _apiConfig = apiConfig;

    public async Task<Table?> Handle(GetTableByIdQuery request, CancellationToken token)
    {
        using var httpClient = new HttpClient();

        using var response = await httpClient.GetAsync(
            requestUri: $"{_apiConfig.ServerUrl}/Tables/Id={request.Id}",
            cancellationToken: token);

        string apiResponse = await response.Content.ReadAsStringAsync(cancellationToken: token);

        return JsonConvert.DeserializeObject<Table>(value: apiResponse);
    }
}