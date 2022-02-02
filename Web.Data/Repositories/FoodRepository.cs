namespace VictoryRestaurant.Web.Data.Repositories;

public class FoodRepository : IFoodRepository
{
    private readonly ApplicationContext _context;

    public FoodRepository(ApplicationContext context)
    {
        _context = context;
    }

    public async Task AddFoodAsync(FoodEntity foodItem)
    {
        await _context.Foods.AddAsync(foodItem);
        await _context.SaveChangesAsync();
    }

    public IEnumerable<FoodEntity> GetAll() => _context.Foods;

    public async Task DeleteFood(FoodEntity foodItem)
    {
        _context.Foods.Attach(foodItem);
        _context.Foods.Remove(foodItem);
        await _context.SaveChangesAsync();
    }

    public async Task<FoodEntity> GetFoodById(int id) =>
       await _context.Foods.FirstOrDefaultAsync(food => food.Id == id);

    public async Task UpdateFood(FoodEntity foodItem) =>
        await Task.Run(() =>
        {
            _context.Foods.Update(
                new()
                {
                    Id = foodItem.Id,
                    CostInUSD = foodItem.CostInUSD,
                    CreatedDate = foodItem.CreatedDate,
                    Description = foodItem.Description,
                    ImagePath = foodItem.ImagePath,
                    Name = foodItem.Name,
                    Type = foodItem.Type
                });
            return _context.SaveChanges();
        });
}