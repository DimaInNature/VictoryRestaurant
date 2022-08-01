namespace Victory.Consumers.Desktop.Domain.Queries.FoodTypes;

public sealed record class GetFoodTypeListQuery
    : BaseAnonymousFeature, IRequest<List<FoodType>?>
{ }