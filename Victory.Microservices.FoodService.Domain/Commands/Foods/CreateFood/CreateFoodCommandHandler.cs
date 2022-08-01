namespace Victory.Microservices.FoodService.Domain.Commands.Foods;

public sealed record class CreateFoodCommandHandler
    : IRequestHandler<CreateFoodCommand>
{
    private readonly IGenericRepository<FoodEntity> _repository;

    public CreateFoodCommandHandler(
        IGenericRepository<FoodEntity> repository) =>
        _repository = repository;

    public async Task<Unit> Handle(
        CreateFoodCommand request,
        CancellationToken token)
    {
        if (request.Food is null) return Unit.Value;

        await _repository.CreateAsync(entity: request.Food, token);

        return Unit.Value;
    }
}