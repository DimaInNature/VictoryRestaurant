namespace Desktop.Services.Foods;

public sealed class FoodFacadeService : IFoodFacadeService
{
    private readonly IFoodRepositoryService _repository;

    public FoodFacadeService(IFoodRepositoryService repository) =>
        _repository = repository;

    public async Task<List<Food>> GetFoodListAsync() =>
        await _repository.GetFoodListAsync();

    public async Task<List<Food>> GetFoodListAsync(FoodType type) =>
        await _repository.GetFoodListAsync(type);

    public async Task<Food?> GetFoodAsync(FoodType type) =>
        await _repository.GetFoodAsync(type);

    public async Task CreateAsync(Food food) =>
        await _repository.CreateAsync(food);

    public async Task UpdateAsync(Food food) =>
       await _repository.UpdateAsync(food);

    public async Task DeleteAsync(int id) =>
       await _repository.DeleteAsync(id);
}