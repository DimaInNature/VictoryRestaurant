namespace Victory.Application.General.Client.Features.Foods;

public sealed record class UpdateFoodCommandHandler
    : IRequestHandler<UpdateFoodCommand>
{
    public async Task<Unit> Handle(UpdateFoodCommand request, CancellationToken token)
    {
        if (request.Food is null) return Unit.Value;

        using var client = new HttpClient();

        string json = JsonConvert.SerializeObject(value: request.Food);

        await client.PutAsync(
            requestUri: "http://localhost:7059/Foods",
            content: new StringContent(
                content: json,
                encoding: Encoding.UTF8,
                mediaType: "application/json"),
            cancellationToken: token);

        return Unit.Value;
    }
}