namespace Victory.Application.Features.Bookings;

public sealed record class DeleteBookingCommandHandler
    : IRequestHandler<DeleteBookingCommand>
{
    public async Task<Unit> Handle(DeleteBookingCommand request, CancellationToken token)
    {
        using var client = new HttpClient();

        string json = JsonConvert.SerializeObject(value: request.Id);

        await client.DeleteAsync(
            requestUri: $"https://localhost:7059/Bookings/{request.Id}",
            cancellationToken: token);

        return Unit.Value;
    }
}