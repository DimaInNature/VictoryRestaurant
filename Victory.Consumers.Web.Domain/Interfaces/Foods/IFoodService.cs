namespace Victory.Consumers.Web.Domain.Interfaces.Foods;

public interface IFoodService
{
    Task<List<Food>> GetFoodListAsync();

    Task<List<Food>> GetFoodListAsync(FoodType type);
}