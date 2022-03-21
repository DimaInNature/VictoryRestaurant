namespace Desktop.Services.Foods;

public sealed class FoodFacadeService : IFoodFacadeService
{
    private readonly IFoodRepositoryService _repository;

    public FoodFacadeService(IFoodRepositoryService repository)
    {
        _repository = repository;
    }

    public async Task<List<Food>> GetFoodsAsync() =>
        await _repository.GetFoodsAsync();

    public async Task<List<Food>> GetAllByFoodType(FoodType type) =>
        await _repository.GetAllByFoodType(type);

    public async Task<Food?> GetFoodByFootType(FoodType type) =>
        await _repository.GetFoodByFootType(type);
}