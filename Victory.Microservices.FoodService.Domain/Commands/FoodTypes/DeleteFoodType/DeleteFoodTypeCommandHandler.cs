namespace Victory.Microservices.FoodService.Domain.Commands.FoodTypes;

public sealed record class DeleteFoodTypeCommandHandler
    : IRequestHandler<DeleteFoodTypeCommand>
{
    private readonly IGenericRepository<FoodTypeEntity> _repository;

    public DeleteFoodTypeCommandHandler(
        IGenericRepository<FoodTypeEntity> repository) =>
        _repository = repository;

    public async Task<Unit> Handle(
        DeleteFoodTypeCommand request,
        CancellationToken token)
    {
        if (request.Id < 1) return Unit.Value;

        await _repository.DeleteAsync(id: request.Id, token);

        return Unit.Value;
    }
}