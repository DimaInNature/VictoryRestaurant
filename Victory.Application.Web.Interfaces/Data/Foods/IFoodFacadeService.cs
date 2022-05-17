namespace Victory.Application.Web.Interfaces.Data.Foods;

public interface IFoodFacadeService
{
    Task<List<Food>> GetFoodListAsync(FoodType type);
    Task<Food?> GetFoodAsync(FoodType type);
}