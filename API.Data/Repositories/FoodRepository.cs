﻿namespace API.Data.Repositories;

public class FoodRepository : IFoodRepository
{
    private readonly ApplicationContext _context;
    private bool _disposed = false;

    public FoodRepository(ApplicationContext context)
    {
        _context = context;
    }

    public async Task<List<FoodEntity>> GetFoodsAsync() =>
        await _context.Foods.ToListAsync();

    public async Task<List<FoodEntity>> GetFoodsAsync(string name) =>
        await _context.Foods.Where(food => food.Name.Contains(name)).ToListAsync();

    public async Task<List<FoodEntity>> GetFoodsAsync(FoodType type) =>
        await _context.Foods.Where(food => food.Type == type).ToListAsync();

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

    public async Task<int> SaveAsync() => await _context.SaveChangesAsync();

    public void Dispose()
    {
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (_disposed is false)
            if (disposing)
                _context.Dispose();

        _disposed = true;
    }
}