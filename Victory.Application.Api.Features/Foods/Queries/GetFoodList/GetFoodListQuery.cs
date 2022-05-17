namespace Victory.Application.Api.Features.Foods;

public record class GetFoodListQuery : IRequest<List<FoodEntity>?> { }