namespace Victory.Application.General.Client.Features.FoodTypes;

public sealed record class GetFoodTypeListQuery : IRequest<List<FoodType>?> { }