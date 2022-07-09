namespace Victory.Application.Web.Data.Foods;

public class FoodFacadeService : IFoodFacadeService
{
    private readonly FoodRepositoryServiceLoggerDecorator _repository;

    private readonly ICacheService<Food> _cache;

    public FoodFacadeService(ICacheService<Food> cache,
        FoodRepositoryServiceLoggerDecorator repository) =>
        (_repository, _cache) = (repository, cache);

    public async Task<List<Food>> GetFoodListAsync() =>
        await _repository.GetFoodListAsync();

    public async Task<List<Food>> GetFoodListAsync(FoodType type) =>
        await _repository.GetFoodListAsync(type);

    public async Task CreateAsync(Food entity, string token)
    {
        if (entity is null) return;

        await _repository.CreateAsync(entity, token);

        _cache.Set(key: entity.Id, value: entity);
    }

    public async Task UpdateAsync(Food entity, string token)
    {
        await _repository.UpdateAsync(entity, token);

        _cache.Set(key: entity.Id, value: entity);
    }

    public async Task DeleteAsync(int id, string token)
    {
        await _repository.DeleteAsync(id, token);

        if (_cache.TryGet(key: id, out _))
            _cache.Remove(key: id);
    }
}