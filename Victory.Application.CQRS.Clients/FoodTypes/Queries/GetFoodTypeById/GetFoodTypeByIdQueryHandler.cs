namespace Victory.Application.CQRS.Clients.FoodTypes;

public sealed record class GetFoodTypeByIdQueryHandler
    : IRequestHandler<GetFoodTypeByIdQuery, FoodType?>
{
    private readonly APIFeaturesConfigurationService _apiConfig;

    public GetFoodTypeByIdQueryHandler(APIFeaturesConfigurationService apiConfig) =>
        _apiConfig = apiConfig;

    public async Task<FoodType?> Handle(GetFoodTypeByIdQuery request, CancellationToken token)
    {
        using var httpClient = new HttpClient();

        using var response = await httpClient.GetAsync(
            requestUri: $"{_apiConfig.ServerUrl}/FoodTypes/Id={request.Id}",
            cancellationToken: token);

        string apiResponse = await response.Content.ReadAsStringAsync(cancellationToken: token);

        return JsonConvert.DeserializeObject<FoodType>(value: apiResponse);
    }
}