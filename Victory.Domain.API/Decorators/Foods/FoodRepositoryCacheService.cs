namespace Victory.Domain.API.Decorators.Foods;

public class FoodRepositoryCacheService : IFoodRepositoryService
{
    private const string NameForCaching = "Food";

    private readonly IFoodRepositoryService _repository;

    private readonly IAsyncCacheService<FoodEntity> _cache;

    public FoodRepositoryCacheService(IFoodRepositoryService repository,
        IAsyncCacheService<FoodEntity> cache) =>
        (_repository, _cache) = (repository, cache);

    public async Task<List<FoodEntity>> GetFoodListAsync() =>
        await _repository.GetFoodListAsync() ?? new();

    public async Task<List<FoodEntity>> GetFoodListAsync(string name) =>
        await _repository.GetFoodListAsync(name: name) ?? new();

    public async Task<List<FoodEntity>> GetFoodListByTypeAsync(string type) =>
        await _repository.GetFoodListByTypeAsync(type: type) ?? new();

    public async Task<FoodEntity?> GetFoodAsync(int id)
    {
        FoodEntity? entityFromCache = await _cache.GetAsync(key: $"{NameForCaching}_{id}");

        if (entityFromCache is not null) return entityFromCache;

        FoodEntity? entityFromDb = await _repository.GetFoodAsync(id);

        if (entityFromDb is null) return null;

        await _cache.SetAsync(key: $"{NameForCaching}_{id}", value: entityFromDb);

        return entityFromDb;
    }

    public async Task<FoodEntity?> GetFoodAsync(string type)
    {
        FoodEntity? entity = await _repository.GetFoodAsync(type);

        if (entity is null) return null;

        await _cache.SetAsync(key: $"{NameForCaching}_{entity.Id}", value: entity);

        return entity;
    }

    public async Task CreateAsync(FoodEntity entity)
    {
        if (entity is null) return;

        await _repository.CreateAsync(entity);
    }

    public async Task UpdateAsync(FoodEntity entity)
    {
        if (entity is null) return;

        await _cache.SetAsync(key: $"{NameForCaching}_{entity.Id}", value: entity);

        await _repository.UpdateAsync(entity);
    }

    public async Task DeleteAsync(int id)
    {
        await _repository.DeleteAsync(id);

        await _cache.RemoveAsync(key: $"{NameForCaching}_{id}");
    }
}