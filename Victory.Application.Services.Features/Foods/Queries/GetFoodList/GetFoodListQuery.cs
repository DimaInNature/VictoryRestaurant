namespace Victory.Application.Services.Features.Foods;

public record class GetFoodListQuery : IRequest<List<FoodEntity>?> { }