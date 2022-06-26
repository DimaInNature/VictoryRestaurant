namespace Victory.Application.General.Client.Interfaces.Data.FoodTypes;

public interface IFoodTypeRepositoryService
{
    Task<List<FoodType>?> GetFoodTypeListAsync();
    Task<FoodType?> GetFoodTypeAsync(int id);
}