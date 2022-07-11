namespace Victory.Domain.Features.Consumers.Foods;

public sealed record class GetFoodListQuery
    : BaseAnonymousFeature, IRequest<List<Food>?>
{ }