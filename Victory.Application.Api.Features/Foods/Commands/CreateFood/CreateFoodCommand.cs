namespace Victory.Application.API.Features.Foods;

public sealed record class CreateFoodCommand : IRequest
{
    public FoodEntity? Food { get; }

    public CreateFoodCommand(FoodEntity entity) => Food = entity;

    public CreateFoodCommand() { }
}