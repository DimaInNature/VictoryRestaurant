namespace Victory.Application.Web.Services;

public class FoodFacadeService : IFoodFacadeService
{
    private readonly FoodRepositoryServiceLoggerDecorator _repository;
    private readonly ICacheService<Food> _cache;

    public FoodFacadeService(ICacheService<Food> cache,
        FoodRepositoryServiceLoggerDecorator repository) =>
        (_repository, _cache) = (repository, cache);

    public async Task<List<Food>> GetFoodListAsync(FoodType type) =>
        await _repository.GetFoodListAsync(type);

    public async Task<Food?> GetFoodAsync(FoodType type)
    {
        var entity = await _repository.GetFoodAsync(type);

        if (entity is null) return null;

        _cache.Set(key: entity.Id, value: entity);

        return entity;
    }
}