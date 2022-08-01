namespace Victory.Microservices.FoodService.Domain.Commands.FoodTypes;

public sealed record class UpdateFoodTypeCommandHandler
    : IRequestHandler<UpdateFoodTypeCommand>
{
    private readonly IGenericRepository<FoodTypeEntity> _repository;

    public UpdateFoodTypeCommandHandler(
        IGenericRepository<FoodTypeEntity> repository) =>
        _repository = repository;

    public async Task<Unit> Handle(
        UpdateFoodTypeCommand request,
        CancellationToken token)
    {
        if (request.FoodType is null) return Unit.Value;

        await _repository.UpdateAsync(entity: request.FoodType, token);

        return Unit.Value;
    }
}