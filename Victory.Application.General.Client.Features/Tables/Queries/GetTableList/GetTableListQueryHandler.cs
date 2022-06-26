namespace Victory.Application.General.Client.Features.Tables;

public sealed record class GetTableListQueryHandler
    : IRequestHandler<GetTableListQuery, List<Table>?>
{
    private readonly APIFeaturesConfigurationService _apiConfig;

    public GetTableListQueryHandler(APIFeaturesConfigurationService apiConfig) =>
        _apiConfig = apiConfig;

    public async Task<List<Table>?> Handle(GetTableListQuery request, CancellationToken token)
    {
        using var httpClient = new HttpClient();

        using var response = await httpClient.GetAsync(
            requestUri: $"{_apiConfig.ServerUrl}/Tables",
            cancellationToken: token);

        string apiResponse = await response.Content.ReadAsStringAsync(cancellationToken: token);

        return JsonConvert.DeserializeObject<List<Table>>(value: apiResponse);
    }
}