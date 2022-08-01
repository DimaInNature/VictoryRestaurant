namespace Victory.Microservices.FoodService.Domain.Commands.FoodTypes;

public sealed record class CreateFoodTypeCommand : IRequest
{
    public FoodTypeEntity? FoodType { get; }

    public CreateFoodTypeCommand(FoodTypeEntity entity) => FoodType = entity;

    public CreateFoodTypeCommand() { }
}