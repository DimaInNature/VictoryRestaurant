﻿namespace Victory.Domain.Features.API.Foods;

public sealed record class DeleteFoodCommandHandler
    : IRequestHandler<DeleteFoodCommand>
{
    private readonly ApplicationContext _context;

    public DeleteFoodCommandHandler(ApplicationContext context) => _context = context;

    public async Task<Unit> Handle(DeleteFoodCommand request, CancellationToken token)
    {
        var entity = await _context.Foods
            .AsNoTracking()
            .Include(navigationPropertyPath: f => f.FoodType)
            .FirstOrDefaultAsync(predicate: food => food.Id == request.Id,
            cancellationToken: token);

        if (entity is null) return Unit.Value;

        _context.Foods.Remove(entity);

        await _context.SaveChangesAsync(cancellationToken: token);

        return Unit.Value;
    }
}