namespace Victory.Application.Desktop.Data.FoodTypes;

public class FoodTypeFacadeService : IFoodTypeFacadeService
{
    private readonly IFoodTypeRepositoryService _repository;

    public FoodTypeFacadeService(IFoodTypeRepositoryService repository) =>
        _repository = repository;

    public async Task<FoodType?> GetFoodTypeAsync(int id, string token) =>
        await _repository.GetFoodTypeAsync(id, token);

    public async Task<List<FoodType>> GetFoodTypeListAsync() =>
        await _repository.GetFoodTypeListAsync() ?? new();
}