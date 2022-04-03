namespace Victory.Application.Services.Features.Foods;

public sealed record class CreateFoodCommandHandler
    : IRequestHandler<CreateFoodCommand>
{
    private readonly ApplicationContext _context;

    public CreateFoodCommandHandler(ApplicationContext context) => _context = context;

    public async Task<Unit> Handle(CreateFoodCommand request, CancellationToken token)
    {
        if (request.Food is null) return Unit.Value;

        await _context.Foods.AddAsync(
            entity: request.Food,
            cancellationToken: token);

        await _context.SaveChangesAsync(cancellationToken: token);

        return Unit.Value;
    }
}