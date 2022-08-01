namespace Victory.Consumers.Desktop.Domain.Commands.Foods;

public sealed record class UpdateFoodCommand
    : BaseAuthorizedFeature, IRequest
{
    public Food? Food { get; }

    public UpdateFoodCommand(Food entity, string token) =>
        (Food, Token) = (entity, token);

    public UpdateFoodCommand() { }
}