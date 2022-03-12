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

    public async Task<List<FoodEntity>> GetFoodsAsync() =>
        await _repository.GetFoodsAsync();

    public async Task<List<FoodEntity>> GetFoodsAsync(string name) =>
        await _repository.GetFoodsAsync(name: name);

    public async Task<List<FoodEntity>> GetFoodsAsync(FoodType type) =>
        await _repository.GetFoodsAsync(type: type);

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

    public async Task<FoodEntity> GetFoodByFootTypeAsync(FoodType type)
    {
        FoodEntity food = await _repository.GetFoodByFootTypeAsync(type: type);

        return _cache.Set(key: food.Id, value: food);
    }

    public async Task InsertFoodAsync(FoodEntity food)
    {
        await _repository.InsertFoodAsync(food);

        _cache.Set(key: food.Id, value: food);
    }

    public async Task UpdateFoodAsync(FoodEntity food)
    {
        await _repository.UpdateFoodAsync(food);

        _cache.Set(key: food.Id, value: food);
    }

    public async Task DeleteFoodAsync(int foodId)
    {
        await _repository.DeleteFoodAsync(foodId);

        if (_cache.TryGet(key: foodId, out _))
            _cache.Remove(key: foodId);
    }

    public Task<int> SaveAsync() => _repository.SaveAsync();
}