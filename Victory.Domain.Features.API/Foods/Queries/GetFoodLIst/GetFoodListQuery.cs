namespace Victory.Domain.Features.API.Foods;

public record class GetFoodListQuery : IRequest<List<FoodEntity>?> { }