namespace Victory.Application.CQRS.API.Foods;

public record class GetFoodListQuery : IRequest<List<FoodEntity>?> { }