namespace Victory.Domain.Interfaces.Consumers.Data.FoodTypes;

public interface IFoodTypeRepositoryService
{
    Task<List<FoodType>?> GetFoodTypeListAsync();
    Task<FoodType?> GetFoodTypeAsync(int id, string token);
}