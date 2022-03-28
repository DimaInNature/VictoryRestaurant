namespace Desktop.Services.Foods;

public sealed class FoodRepositoryService : IFoodRepositoryService
{
    private readonly IFoodRepository _repository;

    public FoodRepositoryService(IFoodRepository repository) =>
        _repository = repository;

    public async Task<List<Food>> GetFoodListAsync() =>
        await _repository.GetFoodListAsync() ?? new();

    public async Task<List<Food>> GetFoodListAsync(FoodType type) =>
        Enum.IsDefined(typeof(FoodType), type)
        ? await _repository.GetFoodListAsync(type) ?? new()
        : new();

    public async Task<Food?> GetFoodAsync(FoodType type) =>
        Enum.IsDefined(enumType: typeof(FoodType), value: type)
        ? await _repository.GetFoodAsync(type)
        : null;

    public async Task CreateAsync(Food food)
    {
        if (food is null) return;

        await _repository.CreateAsync(food);
    }

    public async Task UpdateAsync(Food food)
    {
        if (food is null) return;

        await _repository.UpdateAsync(food);
    }

    public async Task DeleteAsync(int id)
    {
        if (id < 0) return;

        await _repository.DeleteAsync(id);
    }
}