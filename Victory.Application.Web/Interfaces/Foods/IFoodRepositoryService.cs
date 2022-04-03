namespace Victory.Application.Web.Interfaces;

public interface IFoodRepositoryService
{
    Task<List<Food>?> GetFoodListAsync(FoodType type);
    Task<Food> GetFoodAsync(FoodType type);
}