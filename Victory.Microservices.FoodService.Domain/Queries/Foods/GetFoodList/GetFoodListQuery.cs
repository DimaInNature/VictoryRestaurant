namespace Victory.Microservices.FoodService.Domain.Queries.Foods;

public sealed record class GetFoodListQuery : IRequest<IEnumerable<FoodEntity>> { }