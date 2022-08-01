namespace Victory.Microservices.FoodService.Domain.Commands.Foods;

public sealed record class DeleteFoodCommandHandler
    : IRequestHandler<DeleteFoodCommand>
{
    private readonly IGenericRepository<FoodEntity> _repository;

    public DeleteFoodCommandHandler(
        IGenericRepository<FoodEntity> repository) =>
        _repository = repository;

    public async Task<Unit> Handle(
        DeleteFoodCommand request,
        CancellationToken token)
    {
        if (request.Id < 1) return Unit.Value;

        await _repository.DeleteAsync(id: request.Id, token);

        return Unit.Value;
    }
}