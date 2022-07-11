namespace Victory.Domain.Features.Consumers.Foods;

public sealed record class GetFoodListQueryHandler
    : IRequestHandler<GetFoodListQuery, List<Food>?>
{
    private readonly APIFeaturesConfigurationService _apiConfig;

    public GetFoodListQueryHandler(APIFeaturesConfigurationService apiConfig) =>
        _apiConfig = apiConfig;

    public async Task<List<Food>?> Handle(GetFoodListQuery request, CancellationToken token)
    {
        using var httpClient = new HttpClient();

        using var response = await httpClient
            .GetAsync(requestUri: $"{_apiConfig.ServerUrl}/Foods",
            cancellationToken: token);

        string apiResponse = await response.Content.ReadAsStringAsync(cancellationToken: token);

        return JsonConvert.DeserializeObject<List<Food>>(value: apiResponse);
    }
}