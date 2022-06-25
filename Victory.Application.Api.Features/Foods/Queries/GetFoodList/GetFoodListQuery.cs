namespace Victory.Application.API.Features.Foods;

public record class GetFoodListQuery : IRequest<List<FoodEntity>?> { }