namespace VictoryRestaurant.Web.Services.Foods;

public class FoodRepositoryService : IFoodRepositoryService
{
    private readonly IFoodRepository _repository;
    private readonly IMapper _mapper;

    public FoodRepositoryService(IMapper mapper,
        IFoodRepository repository)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<Food>> GetAllByFoodTypeAsync(FoodType type) =>
        new List<Food>()
        .Concat(second: _repository.GetAllByFoodType(type)
            .Result.Select(food => _mapper.Map<Food>(source: food)));

    public async Task<Food> GetFoodByFootTypeAsync(FoodType type) =>
        _mapper.Map<Food>(
            source: await _repository.GetFoodByFootTypeAsync(type));
}