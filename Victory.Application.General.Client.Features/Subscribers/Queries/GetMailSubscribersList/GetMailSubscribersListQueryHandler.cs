namespace Victory.Application.General.Client.Features.Subscribers;

public sealed record class GetMailSubscribersListQueryHandler
    : IRequestHandler<GetMailSubscribersListQuery, List<MailSubscriber>?>
{
    public async Task<List<MailSubscriber>?> Handle(GetMailSubscribersListQuery request, CancellationToken token)
    {
        using var httpClient = new HttpClient();

        using var response = await httpClient.GetAsync(
            requestUri: "http://localhost:7059/MailSubscribers",
            cancellationToken: token);

        string apiResponse = await response.Content.ReadAsStringAsync(cancellationToken: token);

        return JsonConvert.DeserializeObject<List<MailSubscriber>>(value: apiResponse);
    }
}