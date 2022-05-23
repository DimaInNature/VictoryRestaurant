namespace Victory.Application.General.Client.Features.Messages;

public sealed record class GetContactMessageListQueryHandler
    : IRequestHandler<GetContactMessageListQuery, List<ContactMessage>?>
{
    public async Task<List<ContactMessage>?> Handle(GetContactMessageListQuery request, CancellationToken token)
    {
        using var httpClient = new HttpClient();

        using var response = await httpClient.GetAsync(
            requestUri: "http://localhost:7059/ContactMessages",
            cancellationToken: token);

        string apiResponse = await response.Content.ReadAsStringAsync(cancellationToken: token);

        return JsonConvert.DeserializeObject<List<ContactMessage>>(value: apiResponse);
    }
}