namespace Victory.Domain.Interfaces.Clients.Data.Foods;

public interface IFoodRepositoryService
{
    Task<List<Food>> GetFoodListAsync();
    Task<List<Food>> GetFoodListAsync(FoodType type);
    Task CreateAsync(Food food, string token);
    Task UpdateAsync(Food food, string token);
    Task DeleteAsync(int id, string token);
}