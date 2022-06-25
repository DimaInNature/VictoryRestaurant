namespace Victory.Application.API.Features.FoodTypes;

public sealed record class GetFoodTypeListQuery : IRequest<List<FoodTypeEntity>?> { }