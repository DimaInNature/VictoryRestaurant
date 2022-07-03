namespace Victory.Application.CQRS.Clients.Foods;

public sealed record class GetFoodListQuery : IRequest<List<Food>?> { }