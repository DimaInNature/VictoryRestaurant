namespace API.Features.Foods.Commands;

public sealed record class CreateFoodCommand : IRequest
{
    public FoodEntity? Food { get; }

    public CreateFoodCommand(FoodEntity food!!) => Food = food;

    public CreateFoodCommand() { }
}