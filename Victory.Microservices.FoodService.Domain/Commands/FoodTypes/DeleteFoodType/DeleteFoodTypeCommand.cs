namespace Victory.Microservices.FoodService.Domain.Commands.FoodTypes;

public sealed record class DeleteFoodTypeCommand : IRequest
{
    public int Id { get; }

    public DeleteFoodTypeCommand(int id) => Id = id;

    public DeleteFoodTypeCommand() { }
}