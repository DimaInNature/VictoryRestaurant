namespace Victory.Application.Features.Foods;

public sealed record class GetFoodListQueryHandler
    : IRequestHandler<GetFoodListQuery, List<Food>?>
{
    public async Task<List<Food>?> Handle(GetFoodListQuery request, CancellationToken token)
    {
        using var httpClient = new HttpClient();

        using var response = await httpClient
            .GetAsync(requestUri: "https://localhost:7059/Foods",
            cancellationToken: token);

        string apiResponse = await response.Content.ReadAsStringAsync(cancellationToken: token);

        return JsonConvert.DeserializeObject<List<Food>>(value: apiResponse);
    }
}