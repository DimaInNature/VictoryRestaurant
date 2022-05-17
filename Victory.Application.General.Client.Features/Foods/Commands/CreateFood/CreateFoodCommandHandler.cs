namespace Victory.Application.General.Client.Features.Foods;

public sealed record class CreateFoodCommandHandler
    : IRequestHandler<CreateFoodCommand>
{
    public async Task<Unit> Handle(CreateFoodCommand request, CancellationToken token)
    {
        if (request.Food is null) return Unit.Value;

        using var client = new HttpClient();

        string json = JsonConvert.SerializeObject(value: request.Food);

        await client.PostAsync(
            requestUri: "https://localhost:7059/Foods",
            content: new StringContent(
                content: json,
                encoding: Encoding.UTF8,
                mediaType: "application/json"),
            cancellationToken: token);

        return Unit.Value;
    }
}