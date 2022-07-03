namespace Victory.Domain.Interfaces.Clients.Data.FoodTypes;

public interface IFoodTypeFacadeService
{
    Task<List<FoodType>> GetFoodTypeListAsync();
    Task<FoodType?> GetFoodTypeAsync(int id);
}