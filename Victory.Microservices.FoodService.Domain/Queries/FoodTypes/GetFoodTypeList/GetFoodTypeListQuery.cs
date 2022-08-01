namespace Victory.Microservices.FoodService.Domain.Queries.FoodTypes;

public sealed record class GetFoodTypeListQuery : IRequest<IEnumerable<FoodTypeEntity>> { }