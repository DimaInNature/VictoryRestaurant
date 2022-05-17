namespace Victory.Application.General.Client.Features.Foods;

public sealed record class DeleteFoodCommandHandler
    : IRequestHandler<DeleteFoodCommand>
{
    public async Task<Unit> Handle(DeleteFoodCommand request, CancellationToken token)
    {
        if (request.Id < 0) return Unit.Value;

        using var client = new HttpClient();

        string json = JsonConvert.SerializeObject(value: request.Id);

        await client.DeleteAsync(
           requestUri: $"https://localhost:7059/Foods/{request.Id}",
           cancellationToken: token);

        return Unit.Value;
    }
}