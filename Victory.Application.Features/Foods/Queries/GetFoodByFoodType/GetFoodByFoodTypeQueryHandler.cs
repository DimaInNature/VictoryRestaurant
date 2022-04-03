namespace Victory.Application.Features.Foods;

public sealed record class GetFoodByFoodTypeQueryHandler
    : IRequestHandler<GetFoodByFoodTypeQuery, Food?>
{
    public async Task<Food?> Handle(GetFoodByFoodTypeQuery request, CancellationToken token)
    {
        using var httpClient = new HttpClient();

        using var response = await httpClient.GetAsync(
            requestUri: $"https://localhost:7059/Foods/Type/{request.FoodType}",
            cancellationToken: token);

        string apiResponse = await response.Content.ReadAsStringAsync(cancellationToken: token);

        return JsonConvert.DeserializeObject<Food>(value: apiResponse);
    }
}