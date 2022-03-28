using System.Text;

namespace Desktop.Data.Repositories;

public class FoodRepository : IFoodRepository
{
    public async Task<List<Food>?> GetFoodListAsync()
    {
        using var httpClient = new HttpClient();

        using var response = await httpClient
            .GetAsync(requestUri: "https://localhost:7059/Foods");

        string apiResponse = await response.Content.ReadAsStringAsync();

        return JsonConvert.DeserializeObject<List<Food>>(value: apiResponse) ?? new();
    }

    public async Task<List<Food>?> GetFoodListAsync(FoodType type)
    {
        using var httpClient = new HttpClient();

        using var response = await httpClient
            .GetAsync(requestUri: $"https://localhost:7059/Foods/Search/Type/{type}");

        string apiResponse = await response.Content.ReadAsStringAsync();

        return JsonConvert.DeserializeObject<List<Food>>(value: apiResponse) ?? new();
    }

    public async Task<Food?> GetFoodAsync(FoodType type)
    {
        using var httpClient = new HttpClient();

        using var response = await httpClient
            .GetAsync(requestUri: $"https://localhost:7059/Foods/Type/{type}");
        string apiResponse = await response.Content.ReadAsStringAsync();

        return JsonConvert.DeserializeObject<Food>(value: apiResponse);
    }

    public async Task CreateAsync(Food food)
    {
        if (food is null) return;

        using var client = new HttpClient();

        string json = JsonConvert.SerializeObject(value: food);

        await client.PostAsync(
            requestUri: "https://localhost:7059/Foods",
            content: new StringContent(
                content: json,
                encoding: Encoding.UTF8,
                mediaType: "application/json"));
    }

    public async Task UpdateAsync(Food food)
    {
        if (food is null) return;

        using var client = new HttpClient();

        string json = JsonConvert.SerializeObject(value: food);

        await client.PutAsync(
            requestUri: "https://localhost:7059/Foods",
            content: new StringContent(
                content: json,
                encoding: Encoding.UTF8,
                mediaType: "application/json"));
    }

    public async Task DeleteAsync(int id)
    {
        if (id < 0) return;

        using var client = new HttpClient();

        string json = JsonConvert.SerializeObject(value: id);

        await client.DeleteAsync(
           requestUri: $"https://localhost:7059/Foods/{id}");
    }
}