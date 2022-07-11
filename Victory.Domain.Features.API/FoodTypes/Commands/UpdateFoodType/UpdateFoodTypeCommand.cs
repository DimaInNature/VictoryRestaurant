namespace Victory.Domain.Features.API.FoodTypes;

public sealed record class UpdateFoodTypeCommand : IRequest
{
    public FoodTypeEntity? FoodType { get; }

    public UpdateFoodTypeCommand(FoodTypeEntity entity) => FoodType = entity;

    public UpdateFoodTypeCommand() { }
}