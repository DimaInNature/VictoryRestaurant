namespace Victory.Domain.Features.Consumers.FoodTypes;

public sealed record class GetFoodTypeListQuery
    : BaseAnonymousFeature, IRequest<List<FoodType>?>
{ }