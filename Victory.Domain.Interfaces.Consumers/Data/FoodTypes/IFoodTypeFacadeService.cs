namespace Victory.Domain.Interfaces.Consumers.Data.FoodTypes;

public interface IFoodTypeFacadeService
{
    Task<List<FoodType>> GetFoodTypeListAsync();
    Task<FoodType?> GetFoodTypeAsync(int id, string token);
}