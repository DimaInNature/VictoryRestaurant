namespace Victory.Application.API.Data.FoodTypes;

public class FoodTypeFacadeService : IFoodTypeFacadeService
{
    private const string NameForCaching = "FoodType";

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
        FoodTypeEntity? entityFromCache = await _cache.GetAsync(key: $"{NameForCaching}_{id}");

        if (entityFromCache is not null) return entityFromCache;

        FoodTypeEntity? entityFromDb = await _repository.GetFoodTypeAsync(id);

        if (entityFromDb is null) return null;

        await _cache.SetAsync(key: $"{NameForCaching}_{id}", value: entityFromDb);

        return entityFromDb;
    }

    public async Task CreateAsync(FoodTypeEntity entity)
    {
        if (entity is null) return;

        await _repository.CreateAsync(entity);
    }

    public async Task UpdateAsync(FoodTypeEntity entity)
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