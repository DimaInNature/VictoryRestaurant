using Desktop.Data.Repositories.Abstract;
using Desktop.Enums;
using Desktop.Models;
using Desktop.Services.Abstract.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Desktop.Services.Repositories;

public class FoodRepositoryService : IFoodRepositoryService
{
    private readonly IFoodRepository _repository;

    public FoodRepositoryService(IFoodRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<Food>> GetFoodsAsync()
    {
        return await _repository.GetFoodsAsync();
    }

    public async Task<IEnumerable<Food>> GetAllByFoodType(FoodType type)
    {
        return await _repository.GetAllByFoodType(type);
    }

    public async Task<Food> GetFoodByFootType(FoodType type)
    {
        return await _repository.GetFoodByFootType(type);
    }
}
