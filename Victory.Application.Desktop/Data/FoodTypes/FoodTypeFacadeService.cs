namespace Victory.Application.Desktop.Data.FoodTypes;

public class FoodTypeFacadeService : IFoodTypeFacadeService
{
    private readonly IFoodTypeRepositoryService _repository;

    public FoodTypeFacadeService(IFoodTypeRepositoryService repository) =>
        _repository = repository;

    public async Task<FoodType?> GetFoodTypeAsync(int id) =>
        await _repository.GetFoodTypeAsync(id);

    public async Task<List<FoodType>> GetFoodTypeListAsync() =>
        await _repository.GetFoodTypeListAsync() ?? new();
}