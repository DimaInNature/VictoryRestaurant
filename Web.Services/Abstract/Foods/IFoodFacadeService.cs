namespace VictoryRestaurant.Web.Services.Abstract.Foods;

public interface IFoodFacadeService
{
    Task<IEnumerable<Food>> GetAllByFoodTypeAsync(FoodType type);
    Task<Food> GetFoodByFootTypeAsync(FoodType type);
}
