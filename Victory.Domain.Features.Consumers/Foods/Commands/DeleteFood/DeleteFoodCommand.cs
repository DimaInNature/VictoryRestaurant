namespace Victory.Domain.Features.Consumers.Foods;

public sealed record class DeleteFoodCommand
    : BaseAuthorizedFeature, IRequest
{
    public int Id { get; }

    public DeleteFoodCommand(int id, string token) =>
        (Id, Token) = (id, token);

    public DeleteFoodCommand() { }
}