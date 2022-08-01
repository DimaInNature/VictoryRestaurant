namespace Victory.Consumers.Web.Application.Services.Foods;

public class FoodCacheService : IFoodService
{
    private const string NameForCaching = "Food";

    private readonly IFoodService _repository;

    private readonly ISyncCacheService<Food> _cache;

    public FoodCacheService(
        ISyncCacheService<Food> cache,
        IFoodService repository) =>
        (_repository, _cache) = (repository, cache);

    public async Task<List<Food>> GetFoodListAsync() =>
        await _repository.GetFoodListAsync();

    public async Task<List<Food>> GetFoodListAsync(FoodType type) =>
        await _repository.GetFoodListAsync(type);
}