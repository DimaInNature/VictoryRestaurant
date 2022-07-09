namespace Victory.Application.CQRS.Clients.Foods;

public sealed record class GetFoodListQuery
    : BaseAnonymousFeature, IRequest<List<Food>?>
{ }