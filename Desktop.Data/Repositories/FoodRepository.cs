namespace Desktop.Data.Repositories;

public class FoodRepository : IFoodRepository
{
    public async Task<List<Food>> GetFoodsAsync()
    {
        using var httpClient = new HttpClient();
        using var response = await httpClient.GetAsync(requestUri: "https://localhost:7059/Foods");
        string apiResponse = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<List<Food>>(value: apiResponse) ?? new();
    }

    public async Task<IEnumerable<Food>> GetAllByFoodType(FoodType type)
    {
        using var httpClient = new HttpClient();
        using var response = await httpClient.GetAsync(requestUri: $"https://localhost:7059/Foods/Search/Type/{type}");
        string apiResponse = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<List<Food>>(value: apiResponse) ?? new();
    }

    public async Task<Food> GetFoodByFootType(FoodType type)
    {
        using var httpClient = new HttpClient();
        using var response = await httpClient.GetAsync(requestUri: $"https://localhost:7059/Foods/Type/{type}");
        string apiResponse = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<Food>(value: apiResponse);
    }

    private bool _disposed = false;

    protected virtual void Dispose(bool disposing)
    {
        if (_disposed is false)
        {
            if (disposing)
                Dispose();
        }
        _disposed = true;
    }

    public void Dispose()
    {
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }
}
