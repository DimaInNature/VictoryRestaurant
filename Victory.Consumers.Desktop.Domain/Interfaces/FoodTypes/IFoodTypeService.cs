namespace Victory.Consumers.Desktop.Domain.Interfaces.FoodTypes;

public interface IFoodTypeService
{
    Task<List<FoodType>?> GetFoodTypeListAsync();

    Task<FoodType?> GetFoodTypeAsync(int id, string token);
}