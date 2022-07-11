namespace Victory.Domain.Features.API.FoodTypes;

public sealed record class GetFoodTypeListQuery : IRequest<List<FoodTypeEntity>?> { }