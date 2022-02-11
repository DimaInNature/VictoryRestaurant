namespace VictoryRestaurant.Web.Services.Foods;

public class FoodRepositoryService : IFoodRepositoryService
{
    private readonly IFoodRepository _repository;

    public FoodRepositoryService(IFoodRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Food>> GetAllByFoodTypeAsync(FoodType type)
    {
        try
        {
            return new List<Food>()
                .Concat(_repository.GetAllByFoodType(type)
                .Result.Select(x => x.ToDomain()));
        }
        catch (Exception ex)
        {
            return new List<Food>()
            {
                new Food()
                {
                    Name = "Ошибка",
                    Description = "Ошибка",
                    CostInUSD = 0,
                    ImagePath = "https://localhost:7129/img/error_food.jpg"
                }
            };
        }
    }

    public async Task<Food> GetFoodByFootTypeAsync(FoodType type)
    {
        try
        {
            return await _repository
                .GetFoodByFootTypeAsync(type)
                .ToDomain();
        }
        catch (Exception ex)
        {
            return new()
            {
                Name = "Ошибка",
                Description = "Ошибка",
                CostInUSD = 0,
                ImagePath = "https://localhost:7129/img/error_food.jpg"
            };
        }
    }

}