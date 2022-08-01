namespace Victory.Consumers.Web.Domain.Queries.Tables;

public sealed record class GetTableListByNumberQueryHandler
    : IRequestHandler<GetTableListByNumberQuery, List<Table>?>
{
    private readonly APIFeaturesConfigurationService _apiConfig;

    public GetTableListByNumberQueryHandler(APIFeaturesConfigurationService apiConfig) =>
        _apiConfig = apiConfig;

    public async Task<List<Table>?> Handle(
        GetTableListByNumberQuery request,
        CancellationToken token)
    {
        using var httpClient = new HttpClient();

        using var response = await httpClient.GetAsync(
            requestUri: $"{_apiConfig.ServerUrl}/Tables/Number={request.Number}",
            cancellationToken: token);

        string apiResponse = await response.Content.ReadAsStringAsync(cancellationToken: token);

        return JsonConvert.DeserializeObject<List<Table>>(value: apiResponse);
    }
}