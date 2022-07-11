namespace Victory.Domain.Features.Consumers.FoodTypes;

public sealed record class GetFoodTypeListQueryHandler
    : IRequestHandler<GetFoodTypeListQuery, List<FoodType>?>
{
    private readonly APIFeaturesConfigurationService _apiConfig;

    public GetFoodTypeListQueryHandler(APIFeaturesConfigurationService apiConfig) =>
        _apiConfig = apiConfig;

    public async Task<List<FoodType>?> Handle(GetFoodTypeListQuery request, CancellationToken token)
    {
        using var httpClient = new HttpClient();

        using var response = await httpClient.GetAsync(
            requestUri: $"{_apiConfig.ServerUrl}/FoodTypes",
            cancellationToken: token);

        string apiResponse = await response.Content.ReadAsStringAsync(cancellationToken: token);

        return JsonConvert.DeserializeObject<List<FoodType>>(value: apiResponse);
    }
}