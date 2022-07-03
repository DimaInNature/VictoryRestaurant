namespace Victory.Application.CQRS.API.FoodTypes;

public sealed record class GetFoodTypeListQuery : IRequest<List<FoodTypeEntity>?> { }