namespace Victory.Domain.Interfaces.Clients.Data.FoodTypes;

public interface IFoodTypeRepositoryService
{
    Task<List<FoodType>?> GetFoodTypeListAsync();
    Task<FoodType?> GetFoodTypeAsync(int id);
}