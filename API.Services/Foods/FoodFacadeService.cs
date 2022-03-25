namespace API.Services.Foods;

public class FoodFacadeService : IFoodFacadeService
{
    private readonly IFoodRepositoryService _repository;
    private readonly ICacheService<FoodEntity> _cache;

    public FoodFacadeService(IFoodRepositoryService repository,
        ICacheService<FoodEntity> cache)
    {
        _repository = repository;
        _cache = cache;
    }

    public async Task<List<FoodEntity>> GetFoodListAsync() =>
        await _repository.GetFoodListAsync();

    public async Task<List<FoodEntity>> GetFoodListAsync(string name) =>
        await _repository.GetFoodListAsync(name: name);

    public async Task<List<FoodEntity>> GetFoodListAsync(FoodType type) =>
        await _repository.GetFoodListAsync(type: type);

    public async Task<FoodEntity> GetFoodAsync(int foodId)
    {
        if (_cache.TryGet(foodId, out var food))
            return food;
        else
        {
            food = await _repository.GetFoodAsync(foodId);

            return _cache.Set(key: foodId, value: food);
        }
    }

    public async Task<FoodEntity?> GetFoodAsync(FoodType type)
    {
        FoodEntity food = await _repository.GetFoodAsync(type: type);

        if (food is null) return null;

        return _cache.Set(key: food.Id, value: food);
    }

    public async Task CreateAsync(FoodEntity food)
    {
        await _repository.CreateAsync(food);

        _cache.Set(key: food.Id, value: food);
    }

    public async Task UpdateAsync(FoodEntity food)
    {
        await _repository.UpdateAsync(food);

        _cache.Set(key: food.Id, value: food);
    }

    public async Task DeleteAsync(int foodId)
    {
        await _repository.DeleteAsync(foodId);

        if (_cache.TryGet(key: foodId, out _))
            _cache.Remove(key: foodId);
    }
}