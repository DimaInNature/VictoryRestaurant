namespace Victory.Domain.Consumers.Decorators.Foods;

public class FoodRepositoryCacheService : IFoodRepositoryService
{
    private const string NameForCaching = "Food";

    private readonly IFoodRepositoryService _repository;

    private readonly ISyncCacheService<Food> _cache;

    public FoodRepositoryCacheService(ISyncCacheService<Food> cache,
        IFoodRepositoryService repository) =>
        (_repository, _cache) = (repository, cache);

    public async Task<List<Food>> GetFoodListAsync() =>
        await _repository.GetFoodListAsync();

    public async Task<List<Food>> GetFoodListAsync(FoodType type) =>
        await _repository.GetFoodListAsync(type);

    public async Task CreateAsync(Food entity, string token)
    {
        if (entity is null) return;

        await _repository.CreateAsync(entity, token);
    }

    public async Task UpdateAsync(Food entity, string token)
    {
        if (entity is null) return;

        await _repository.UpdateAsync(entity, token);

        _cache.Set(key: $"{NameForCaching}_{entity.Id}", value: entity);
    }

    public async Task DeleteAsync(int id, string token)
    {
        await _repository.DeleteAsync(id, token);

        _cache.Remove(key: $"{NameForCaching}_{id}");
    }
}