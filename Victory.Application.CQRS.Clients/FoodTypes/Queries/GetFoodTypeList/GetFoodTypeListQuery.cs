namespace Victory.Application.CQRS.Clients.FoodTypes;

public sealed record class GetFoodTypeListQuery : IRequest<List<FoodType>?> { }