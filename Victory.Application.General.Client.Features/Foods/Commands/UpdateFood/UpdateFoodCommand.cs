namespace Victory.Application.General.Client.Features.Foods;

public sealed record class UpdateFoodCommand : IRequest
{
    public Food? Food { get; }

    public UpdateFoodCommand(Food entity) => Food = entity;

    public UpdateFoodCommand() { }
}