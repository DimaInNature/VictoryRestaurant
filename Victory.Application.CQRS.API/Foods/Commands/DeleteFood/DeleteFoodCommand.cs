namespace Victory.Application.CQRS.API.Foods;

public sealed record class DeleteFoodCommand : IRequest
{
    public int Id { get; }

    public DeleteFoodCommand(int id) => Id = id;

    public DeleteFoodCommand() { }
}