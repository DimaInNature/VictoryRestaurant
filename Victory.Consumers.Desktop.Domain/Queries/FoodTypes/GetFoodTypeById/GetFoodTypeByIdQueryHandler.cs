namespace Victory.Consumers.Desktop.Domain.Queries.FoodTypes;

public sealed record class GetFoodTypeByIdQueryHandler
    : IRequestHandler<GetFoodTypeByIdQuery, FoodType?>
{
    private readonly APIFeaturesConfigurationService _apiConfig;

    public GetFoodTypeByIdQueryHandler(APIFeaturesConfigurationService apiConfig) =>
        _apiConfig = apiConfig;

    public async Task<FoodType?> Handle(GetFoodTypeByIdQuery request, CancellationToken token)
    {
        if (request.Token is null) return null;

        using var httpClient = new HttpClient();

        httpClient.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue(
                scheme: "Bearer",
                parameter: request.Token);

        using var response = await httpClient.GetAsync(
            requestUri: $"{_apiConfig.ServerUrl}/FoodTypes/Id={request.Id}",
            cancellationToken: token);

        string apiResponse = await response.Content.ReadAsStringAsync(cancellationToken: token);

        return JsonConvert.DeserializeObject<FoodType>(value: apiResponse);
    }
}