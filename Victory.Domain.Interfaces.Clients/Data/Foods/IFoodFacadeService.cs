namespace Victory.Domain.Interfaces.Clients.Data.Foods;

public interface IFoodFacadeService
{
    Task<List<Food>> GetFoodListAsync();
    Task<List<Food>> GetFoodListAsync(FoodType type);
    Task CreateAsync(Food entity, string token);
    Task UpdateAsync(Food entity, string token);
    Task DeleteAsync(int id, string token);
}