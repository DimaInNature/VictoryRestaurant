namespace Victory.Application.Features.Users;

public sealed record class UpdateUserCommandHandler
    : IRequestHandler<UpdateUserCommand>
{
    public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken token)
    {
        if (request.User is null) return Unit.Value;

        using var client = new HttpClient();

        string json = JsonConvert.SerializeObject(value: request.User);

        await client.PutAsync(
            requestUri: "https://localhost:7059/Users",
            content: new StringContent(
                content: json,
                encoding: Encoding.UTF8,
                mediaType: "application/json"),
            cancellationToken: token);

        return Unit.Value;
    }
}