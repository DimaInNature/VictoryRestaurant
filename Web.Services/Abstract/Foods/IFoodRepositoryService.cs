namespace VictoryRestaurant.Web.Services.Abstract.Foods;

public interface IFoodRepositoryService
{
    void AddFood(Food foodItem);
    void UpdateFood(Food foodItem);
    void DeleteFood(Food foodItem);
    Food GetFoodById(int id);
    IEnumerable<Food> GetAll();
}