namespace Victory.Domain.Features.API.FoodTypes;

public sealed record class DeleteFoodTypeCommand : IRequest
{
    public int Id { get; }

    public DeleteFoodTypeCommand(int id) => Id = id;

    public DeleteFoodTypeCommand() { }
}