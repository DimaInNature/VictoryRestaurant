namespace Victory.Application.Services;

public class FoodFacadeService : IFoodFacadeService
{
    private readonly IFoodRepositoryService _repository;
    private readonly ICacheService<FoodEntity> _cache;

    public FoodFacadeService(IFoodRepositoryService repository,
        ICacheService<FoodEntity> cache) =>
        (_repository, _cache) = (repository, cache);

    public async Task<List<FoodEntity>> GetFoodListAsync() =>
        await _repository.GetFoodListAsync() ?? new();

    public async Task<List<FoodEntity>> GetFoodListAsync(string name) =>
        await _repository.GetFoodListAsync(name: name) ?? new();

    public async Task<List<FoodEntity>> GetFoodListAsync(FoodType type) =>
        await _repository.GetFoodListAsync(type: type) ?? new();

    public async Task<FoodEntity?> GetFoodAsync(int id)
    {
        if (_cache.TryGet(id, out var food))
            return food;

        food = await _repository.GetFoodAsync(id);

        return food is null ? null : _cache.Set(key: id, value: food);
    }

    public async Task<FoodEntity?> GetFoodAsync(FoodType type)
    {
        FoodEntity? food = await _repository.GetFoodAsync(type);

        return food is null ? null : _cache.Set(key: food.Id, value: food);
    }

    public async Task CreateAsync(FoodEntity entity)
    {
        if (entity is null) return;

        await _repository.CreateAsync(entity);

        _cache.Set(key: entity.Id, value: entity);
    }

    public async Task UpdateAsync(FoodEntity entity)
    {
        if (entity is null) return;

        await _repository.UpdateAsync(entity);

        _cache.Set(key: entity.Id, value: entity);
    }

    public async Task DeleteAsync(int id)
    {
        await _repository.DeleteAsync(id);

        if (_cache.TryGet(key: id, out _))
            _cache.Remove(key: id);
    }
}