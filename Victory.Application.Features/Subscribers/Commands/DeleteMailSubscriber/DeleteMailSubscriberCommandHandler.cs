namespace Victory.Application.Features.Subscribers;

public sealed record class DeleteMailSubscriberCommandHandler
    : IRequestHandler<DeleteMailSubscriberCommand>
{
    public async Task<Unit> Handle(DeleteMailSubscriberCommand request, CancellationToken token)
    {
        using var client = new HttpClient();

        string json = JsonConvert.SerializeObject(value: request.Id);

        await client.DeleteAsync(
            requestUri: $"https://localhost:7059/MailSubscribers/{request.Id}",
            cancellationToken: token);

        return Unit.Value;
    }
}