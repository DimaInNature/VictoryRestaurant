namespace Victory.Domain.Features.Consumers.Tables;

public sealed record class GetTableListByStatusQueryHandler
    : IRequestHandler<GetTableListByStatusQuery, List<Table>?>
{
    private readonly APIFeaturesConfigurationService _apiConfig;

    public GetTableListByStatusQueryHandler(APIFeaturesConfigurationService apiConfig) =>
        _apiConfig = apiConfig;

    public async Task<List<Table>?> Handle(GetTableListByStatusQuery request, CancellationToken token)
    {
        using var httpClient = new HttpClient();

        using var response = await httpClient.GetAsync(
            requestUri: $"{_apiConfig.ServerUrl}/Tables/Status={request.Status}",
            cancellationToken: token);

        string apiResponse = await response.Content.ReadAsStringAsync(cancellationToken: token);

        return JsonConvert.DeserializeObject<List<Table>>(value: apiResponse);
    }
}