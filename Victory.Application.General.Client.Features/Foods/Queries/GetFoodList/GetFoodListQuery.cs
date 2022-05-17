namespace Victory.Application.General.Client.Features.Foods;

public sealed record class GetFoodListQuery : IRequest<List<Food>?> { }