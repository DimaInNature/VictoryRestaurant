namespace Victory.Application.General.Client.Features.Messages;

public sealed record class CreateContactMessageCommandHandler
    : IRequestHandler<CreateContactMessageCommand>
{
    public async Task<Unit> Handle(CreateContactMessageCommand request, CancellationToken token)
    {
        using var client = new HttpClient();

        string json = JsonConvert.SerializeObject(value: request.ContactMessage);

        await client.PostAsync(
            requestUri: "https://localhost:7059/ContactMessages",
            content: new StringContent(
                content: json,
                encoding: Encoding.UTF8,
                mediaType: "application/json"),
            cancellationToken: token);

        return Unit.Value;
    }
}