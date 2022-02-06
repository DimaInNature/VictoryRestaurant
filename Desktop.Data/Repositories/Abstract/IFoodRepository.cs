using Desktop.Enums;
using Desktop.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Desktop.Data.Repositories.Abstract;

public interface IFoodRepository : IDisposable
{
    Task<List<Food>> GetFoodsAsync();
    Task<IEnumerable<Food>> GetAllByFoodType(FoodType type);
    Task<Food> GetFoodByFootType(FoodType type);
}
