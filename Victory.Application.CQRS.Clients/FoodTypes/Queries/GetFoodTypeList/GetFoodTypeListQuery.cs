namespace Victory.Application.CQRS.Clients.FoodTypes;

public sealed record class GetFoodTypeListQuery
    : BaseAnonymousFeature, IRequest<List<FoodType>?>
{ }