namespace Victory.Application.Features.Users;

public sealed record class GetUserListQueryHandler
    : IRequestHandler<GetUserListQuery, List<User>?>
{
    public async Task<List<User>?> Handle(GetUserListQuery request, CancellationToken token)
    {
        using var httpClient = new HttpClient();

        using var response = await httpClient.GetAsync(
            requestUri: "https://localhost:7059/Users",
            cancellationToken: token);

        string apiResponse = await response.Content.ReadAsStringAsync(cancellationToken: token);

        return JsonConvert.DeserializeObject<List<User>>(value: apiResponse);
    }
}