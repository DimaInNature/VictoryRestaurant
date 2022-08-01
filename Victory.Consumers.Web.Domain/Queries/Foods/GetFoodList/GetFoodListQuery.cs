namespace Victory.Consumers.Web.Domain.Queries.Foods;

public sealed record class GetFoodListQuery
    : BaseAnonymousFeature, IRequest<List<Food>?>
{ }