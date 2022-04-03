namespace Victory.Application.Features.Subscribers;

public sealed record class GetMailSubscriberByIdQueryHandler
    : IRequestHandler<GetMailSubscriberByIdQuery, MailSubscriber?>
{
    public async Task<MailSubscriber?> Handle(GetMailSubscriberByIdQuery request, CancellationToken token)
    {
        using var httpClient = new HttpClient();

        using var response = await httpClient.GetAsync(
            requestUri: $"https://localhost:7059/MailSubscribers/{request.Id}",
            cancellationToken: token);

        string apiResponse = await response.Content.ReadAsStringAsync(cancellationToken: token);

        return JsonConvert.DeserializeObject<MailSubscriber>(value: apiResponse);
    }
}