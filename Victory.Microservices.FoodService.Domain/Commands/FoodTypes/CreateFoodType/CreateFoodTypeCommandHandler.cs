namespace Victory.Microservices.FoodService.Domain.Commands.FoodTypes;

public sealed record class CreateFoodTypeCommandHandler
    : IRequestHandler<CreateFoodTypeCommand>
{
    private readonly IGenericRepository<FoodTypeEntity> _repository;

    public CreateFoodTypeCommandHandler(
        IGenericRepository<FoodTypeEntity> repository) =>
        _repository = repository;

    public async Task<Unit> Handle(
        CreateFoodTypeCommand request,
        CancellationToken token)
    {
        if (request.FoodType is null) return Unit.Value;

        await _repository.CreateAsync(entity: request.FoodType, token);

        return Unit.Value;
    }
}