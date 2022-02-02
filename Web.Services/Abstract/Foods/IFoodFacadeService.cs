namespace VictoryRestaurant.Web.Services.Abstract.Foods;

public interface IFoodFacadeService
{
    void AddFood(Food food);
    void ChangeFood(Food food);
    void DeleteFood(Food food);
    IEnumerable<Food> GetAllFoods();
    IEnumerable<Food> GetAllFoods(Func<Food, bool> predicate);
    Food GetFirstFood();
    Food GetFirstFood(Func<Food, bool> predicate);
}
