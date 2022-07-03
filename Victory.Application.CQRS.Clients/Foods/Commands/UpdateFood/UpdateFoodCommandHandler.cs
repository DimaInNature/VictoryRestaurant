﻿namespace Victory.Application.CQRS.Clients.Foods;

public sealed record class UpdateFoodCommandHandler
    : IRequestHandler<UpdateFoodCommand>
{
    private readonly APIFeaturesConfigurationService _apiConfig;

    public UpdateFoodCommandHandler(APIFeaturesConfigurationService apiConfig) =>
        _apiConfig = apiConfig;

    public async Task<Unit> Handle(UpdateFoodCommand request, CancellationToken token)
    {
        if (request.Food is null) return Unit.Value;

        using var client = new HttpClient();

        string json = JsonConvert.SerializeObject(value: request.Food);

        await client.PutAsync(
            requestUri: $"{_apiConfig.ServerUrl}/Foods",
            content: new StringContent(
                content: json,
                encoding: Encoding.UTF8,
                mediaType: "application/json"),
            cancellationToken: token);

        return Unit.Value;
    }
}