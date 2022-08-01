namespace Victory.Consumers.Desktop.Domain.Queries.Foods;

public sealed record class GetFoodListQuery
    : BaseAnonymousFeature, IRequest<List<Food>?>
{ }