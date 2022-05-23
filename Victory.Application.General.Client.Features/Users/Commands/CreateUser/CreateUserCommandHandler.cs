namespace Victory.Application.General.Client.Features.Users;

public sealed record class CreateUserCommandHandler
    : IRequestHandler<CreateUserCommand>
{
    public async Task<Unit> Handle(CreateUserCommand request, CancellationToken token)
    {
        using var client = new HttpClient();

        string json = JsonConvert.SerializeObject(value: request.User);

        await client.PostAsync(
            requestUri: "http://localhost:7059/Users",
            content: new StringContent(
                content: json,
                encoding: Encoding.UTF8,
                mediaType: "application/json"),
            cancellationToken: token);

        return Unit.Value;
    }
}