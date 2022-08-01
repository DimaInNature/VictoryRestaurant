namespace Victory.Microservices.FoodService.Domain.Commands.Foods;

public sealed record class UpdateFoodCommand : IRequest
{
    public FoodEntity? Food { get; }

    public UpdateFoodCommand(FoodEntity entity) => Food = entity;

    public UpdateFoodCommand() { }
}