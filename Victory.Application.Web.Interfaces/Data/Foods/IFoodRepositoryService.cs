namespace Victory.Application.Web.Interfaces.Data.Foods;

public interface IFoodRepositoryService
{
    Task<List<Food>?> GetFoodListAsync(FoodType type);
    Task<Food> GetFoodAsync(FoodType type);
}