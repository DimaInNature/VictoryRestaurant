namespace Victory.Application.CQRS.API.FoodTypes;

public sealed record class CreateFoodTypeCommand : IRequest
{
    public FoodTypeEntity? FoodType { get; }

    public CreateFoodTypeCommand(FoodTypeEntity entity) => FoodType = entity;

    public CreateFoodTypeCommand() { }
}