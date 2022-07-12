namespace Victory.Domain.Interfaces.Consumers.Data.Foods;

public interface IFoodRepositoryService
{
    Task<List<Food>> GetFoodListAsync();
    Task<List<Food>> GetFoodListAsync(FoodType type);
    Task CreateAsync(Food entity, string token);
    Task UpdateAsync(Food entity, string token);
    Task DeleteAsync(int id, string token);
}