using API.Data.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using VictoryRestaurant.API;
using VictoryRestaurant.API.Entities;

namespace API.Data.Repositories;

public class FoodRepository : IFoodRepository
{
    private readonly ApplicationContext _context;

    public FoodRepository(ApplicationContext context)
    {
        _context = context;
    }

    public Task<List<FoodEntity>> GetFoodsAsync() =>
        _context.Foods.ToListAsync();

    public Task<List<FoodEntity>> GetFoodsAsync(string name) =>
        _context.Foods.Where(food => food.Name.Contains(name)).ToListAsync();

    public Task<List<FoodEntity>> GetFoodsAsync(FoodType type) =>
        _context.Foods.Where(food => food.Type == type).ToListAsync();

    public async Task<FoodEntity> GetFoodAsync(int foodId) =>
        await _context.Foods.FindAsync(new object[] { foodId });

    public async Task<FoodEntity> GetFoodByFootTypeAsync(FoodType type) =>
        await _context.Foods.FirstOrDefaultAsync(food => food.Type == type);

    public async Task InsertFoodAsync(FoodEntity food) =>
        await _context.Foods.AddAsync(food);

    public async Task UpdateFoodAsync(FoodEntity food)
    {
        var foodFromDb = await _context.Foods.FindAsync(new object[] { food.Id });
        if (foodFromDb is null) return;

        foodFromDb.Id = food.Id;
        foodFromDb.Type = food.Type;
        foodFromDb.ImagePath = food.ImagePath;
        foodFromDb.Name = food.Name;
        foodFromDb.CostInUSD = food.CostInUSD;
        foodFromDb.Description = food.Description;
    }

    public async Task DeleteFoodAsync(int foodId)
    {
        var hotelFromDb = await _context.Foods.FindAsync(new object[] { foodId });
        if (hotelFromDb is null) return;
        _context.Foods.Remove(hotelFromDb);
    }

    public async Task SaveAsync() => await _context.SaveChangesAsync();

    private bool _disposed = false;

    protected virtual void Dispose(bool disposing)
    {
        if (_disposed is false)
        {
            if (disposing)
                _context.Dispose();
        }
        _disposed = true;
    }

    public void Dispose()
    {
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }
}
