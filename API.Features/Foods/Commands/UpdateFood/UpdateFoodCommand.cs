namespace API.Features.Foods.Commands;

public sealed record class UpdateFoodCommand : IRequest
{
    public FoodEntity? Food { get; }

    public UpdateFoodCommand(FoodEntity food!!) => Food = food;

    public UpdateFoodCommand() { }
}