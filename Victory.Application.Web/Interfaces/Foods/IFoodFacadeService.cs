namespace Victory.Application.Web.Interfaces;

public interface IFoodFacadeService
{
    Task<List<Food>> GetFoodListAsync(FoodType type);
    Task<Food?> GetFoodAsync(FoodType type);
}