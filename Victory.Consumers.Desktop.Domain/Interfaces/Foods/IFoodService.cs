namespace Victory.Consumers.Desktop.Domain.Interfaces.Foods;

public interface IFoodService
{
    Task<List<Food>> GetFoodListAsync();

    Task<List<Food>> GetFoodListAsync(FoodType type);

    Task CreateAsync(Food entity, string token);

    Task UpdateAsync(Food entity, string token);

    Task DeleteAsync(int id, string token);
}