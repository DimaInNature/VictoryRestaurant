namespace VictoryRestaurant.Web.Data.Repositories;

public class FoodRepository : IFoodRepository
{
    public async Task<IEnumerable<FoodEntity>> GetAllByFoodType(FoodType type)
    {
        using var httpClient = new HttpClient();
        using var response = await httpClient.GetAsync(requestUri: $"https://localhost:7059/Foods/Search/Type/{type}");
        string apiResponse = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<List<FoodEntity>>(value: apiResponse) ?? new();
    }

    public async Task<FoodEntity> GetFoodByFootTypeAsync(FoodType type)
    {
        using var httpClient = new HttpClient();
        using var response = await httpClient.GetAsync(requestUri: $"https://localhost:7059/Foods/Type/{type}");
        string apiResponse = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<FoodEntity>(value: apiResponse);
    }
}