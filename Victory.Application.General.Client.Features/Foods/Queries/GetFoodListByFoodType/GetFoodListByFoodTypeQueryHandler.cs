namespace Victory.Application.General.Client.Features.Foods;

public sealed record class GetFoodListByFoodTypeQueryHandler
    : IRequestHandler<GetFoodListByFoodTypeQuery, List<Food>?>
{
    public async Task<List<Food>?> Handle(GetFoodListByFoodTypeQuery request, CancellationToken token)
    {
        using var httpClient = new HttpClient();

        using var response = await httpClient.GetAsync(
            requestUri: $"http://localhost:7059/Foods/Search/Type/{request.FoodType}",
            cancellationToken: token);

        string apiResponse = await response.Content.ReadAsStringAsync(cancellationToken: token);

        return JsonConvert.DeserializeObject<List<Food>>(value: apiResponse);
    }
}