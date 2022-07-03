namespace Victory.Application.Desktop.Data.Foods;

public sealed class FoodFacadeService : IFoodFacadeService
{
    private readonly IFoodRepositoryService _repository;

    public FoodFacadeService(IFoodRepositoryService repository) => _repository = repository;

    public async Task<List<Food>> GetFoodListAsync() =>
        await _repository.GetFoodListAsync();

    public async Task<List<Food>> GetFoodListAsync(FoodType type) =>
        await _repository.GetFoodListAsync(type);

    public async Task CreateAsync(Food entity) =>
        await _repository.CreateAsync(entity);

    public async Task UpdateAsync(Food entity) =>
       await _repository.UpdateAsync(entity);

    public async Task DeleteAsync(int id) =>
       await _repository.DeleteAsync(id);
}