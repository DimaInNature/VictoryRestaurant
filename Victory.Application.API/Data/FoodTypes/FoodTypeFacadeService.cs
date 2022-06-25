namespace Victory.Application.API.Data.FoodTypes;

public class FoodTypeFacadeService : IFoodTypeFacadeService
{
    private readonly IFoodTypeRepositoryService _repository;
    private readonly ICacheService<FoodTypeEntity> _cache;

    public FoodTypeFacadeService(IFoodTypeRepositoryService repository,
        ICacheService<FoodTypeEntity> cache) =>
        (_repository, _cache) = (repository, cache);

    public async Task<List<FoodTypeEntity>?> GetFoodTypeListAsync() =>
        await _repository.GetFoodTypeListAsync() ?? new();

    public async Task<List<FoodTypeEntity>?> GetFoodTypeListAsync(string name) =>
        await _repository.GetFoodTypeListAsync(name) ?? new();

    public async Task<FoodTypeEntity?> GetFoodTypeAsync(int id)
    {
        if (_cache.TryGet(id, out var FoodType))
            return FoodType;

        FoodType = await _repository.GetFoodTypeAsync(id);

        return FoodType is null ? null : _cache.Set(key: id, value: FoodType);
    }

    public async Task CreateAsync(FoodTypeEntity entity)
    {
        if (entity is null) return;

        await _repository.CreateAsync(entity);

        _cache.Set(key: entity.Id, value: entity);
    }

    public async Task UpdateAsync(FoodTypeEntity entity)
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