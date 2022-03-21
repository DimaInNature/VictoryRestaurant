namespace Desktop.Services.Foods;

public sealed class FoodRepositoryService : IFoodRepositoryService
{
    private readonly IFoodRepository _repository;

    public FoodRepositoryService(IFoodRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<Food>> GetFoodsAsync() =>
        await _repository.GetFoodsAsync() ?? new();

    public async Task<List<Food>> GetAllByFoodType(FoodType type)
    {
        if (Enum.IsDefined(typeof(FoodType), type) is false)
            return new();

        return await _repository.GetAllByFoodType(type);
    }

    public async Task<Food?> GetFoodByFootType(FoodType type)
    {
        if (Enum.IsDefined(typeof(FoodType), type) is false)
            return null;

        return await _repository.GetFoodByFootType(type);
    }
}