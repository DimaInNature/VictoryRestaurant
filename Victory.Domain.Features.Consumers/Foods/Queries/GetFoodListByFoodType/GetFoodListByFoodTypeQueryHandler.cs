namespace Victory.Domain.Features.Consumers.Foods;

public sealed record class GetFoodListByFoodTypeQueryHandler
    : IRequestHandler<GetFoodListByFoodTypeQuery, List<Food>?>
{
    private readonly APIFeaturesConfigurationService _apiConfig;

    public GetFoodListByFoodTypeQueryHandler(APIFeaturesConfigurationService apiConfig) =>
        _apiConfig = apiConfig;

    public async Task<List<Food>?> Handle(GetFoodListByFoodTypeQuery request, CancellationToken token)
    {
        using var httpClient = new HttpClient();

        using var response = await httpClient.GetAsync(
            requestUri: $"{_apiConfig.ServerUrl}/Foods/Search/Type={request.FoodType}",
            cancellationToken: token);

        string apiResponse = await response.Content.ReadAsStringAsync(cancellationToken: token);

        return JsonConvert.DeserializeObject<List<Food>>(value: apiResponse);
    }
}