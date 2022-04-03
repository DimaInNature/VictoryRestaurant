namespace Victory.Application.Features.Subscribers;

public sealed record class CreateMailSubscriberCommandHandler
    : IRequestHandler<CreateMailSubscriberCommand>
{
    public async Task<Unit> Handle(CreateMailSubscriberCommand request, CancellationToken token)
    {
        using var client = new HttpClient();

        string json = JsonConvert.SerializeObject(value: request.MailSubscriber);

        await client.PostAsync(
            requestUri: "https://localhost:7059/MailSubscribers",
            content: new StringContent(
                content: json,
                encoding: Encoding.UTF8,
                mediaType: "application/json"),
            cancellationToken: token);

        return Unit.Value;
    }
}