using VictoryRestaurant.Web.Enums;

namespace VictoryRestaurant.Web.Services.Abstract.Foods;

public interface IFoodFacadeService
{
    Task<IEnumerable<Food>> GetAllByFoodType(FoodType type);
    Task<Food> GetFoodByFootType(FoodType type);
}
