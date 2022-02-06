using Desktop.Enums;
using Desktop.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Desktop.Services.Abstract.Repositories;

public interface IFoodRepositoryService
{
    Task<List<Food>> GetFoodsAsync();
    Task<IEnumerable<Food>> GetAllByFoodType(FoodType type);
    Task<Food> GetFoodByFootType(FoodType type);
}
