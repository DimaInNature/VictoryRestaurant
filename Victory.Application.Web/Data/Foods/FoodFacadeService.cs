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

    public async Task CreateAsync(Food entity)
    {
        if (entity is null) return;

        await _repository.CreateAsync(entity);

        _cache.Set(key: entity.Id, value: entity);
    }

    public async Task UpdateAsync(Food entity)
    {
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