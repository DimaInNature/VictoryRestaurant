namespace VictoryRestaurant.Web.Services.Foods;

public class FoodFacadeService : IFoodFacadeService
{
    private readonly FoodRepositoryServiceLoggerDecorator _repository;
    private readonly ICacheService<Food> _cache;

    public FoodFacadeService(ICacheService<Food> cache,
        FoodRepositoryServiceLoggerDecorator repository)
    {
        _repository = repository;
        _cache = cache;
    }

    public async Task<IEnumerable<Food>> GetAllByFoodTypeAsync(FoodType type) =>
        await _repository.GetAllByFoodTypeAsync(type);

    public async Task<Food> GetFoodByFootTypeAsync(FoodType type)
    {
        var food = await _repository.GetFoodByFootTypeAsync(type);

        _cache.Set(key: food.Id, value: food);

        return food;
    }
}