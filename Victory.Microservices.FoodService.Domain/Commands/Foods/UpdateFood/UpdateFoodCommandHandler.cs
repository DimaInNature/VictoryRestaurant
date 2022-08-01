namespace Victory.Microservices.FoodService.Domain.Commands.Foods;

public sealed record class UpdateFoodCommandHandler
    : IRequestHandler<UpdateFoodCommand>
{
    private readonly IGenericRepository<FoodEntity> _repository;

    public UpdateFoodCommandHandler(
        IGenericRepository<FoodEntity> repository) =>
        _repository = repository;

    public async Task<Unit> Handle(
        UpdateFoodCommand request,
        CancellationToken token)
    {
        if (request.Food is null) return Unit.Value;

        await _repository.UpdateAsync(entity: request.Food, token);

        return Unit.Value;
    }
}