namespace Victory.Application.General.Client.Features.Messages;

public sealed record class DeleteContactMessageCommandHandler
    : IRequestHandler<DeleteContactMessageCommand>
{
    public async Task<Unit> Handle(DeleteContactMessageCommand request, CancellationToken token)
    {
        using var client = new HttpClient();

        string json = JsonConvert.SerializeObject(value: request.Id);

        await client.DeleteAsync(
            requestUri: $"http://localhost:7059/ContactMessages/{request.Id}",
            cancellationToken: token);

        return Unit.Value;
    }
}