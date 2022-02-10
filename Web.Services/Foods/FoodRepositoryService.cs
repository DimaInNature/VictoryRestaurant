namespace VictoryRestaurant.Web.Services.Foods;

public class FoodRepositoryService : IFoodRepositoryService
{
    private readonly IFoodRepository _repository;

    public FoodRepositoryService(IFoodRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Food>> GetAllByFoodType(FoodType type) =>
        new List<Food>()
        .Concat(_repository.GetAllByFoodType(type)
            .Result.Select(x => x.ToDomain()));

    public async Task<Food> GetFoodByFootType(FoodType type) =>
        await _repository.GetFoodByFootTypeAsync(type).ToDomain();
}