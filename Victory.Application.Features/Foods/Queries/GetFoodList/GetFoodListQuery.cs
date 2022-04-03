namespace Victory.Application.Features.Foods;

public sealed record class GetFoodListQuery : IRequest<List<Food>?> { }