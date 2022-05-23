namespace Victory.Application.General.Client.Features.Users;

public sealed record class DeleteUserCommandHandler
    : IRequestHandler<DeleteUserCommand>
{
    public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken token)
    {
        using var client = new HttpClient();

        string json = JsonConvert.SerializeObject(value: request.Id);

        await client.DeleteAsync(
            requestUri: $"http://localhost:7059/Users/{request.Id}",
            cancellationToken: token);

        return Unit.Value;
    }
}