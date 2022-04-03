namespace Victory.Application.Features.Bookings;

public sealed record class CreateBookingCommandHandler
    : IRequestHandler<CreateBookingCommand>
{
    public async Task<Unit> Handle(CreateBookingCommand request, CancellationToken token)
    {
        using var client = new HttpClient();

        string json = JsonConvert.SerializeObject(value: request.Booking);

        await client.PostAsync(
            requestUri: "https://localhost:7059/Bookings",
            content: new StringContent(
                content: json,
                encoding: Encoding.UTF8,
                mediaType: "application/json"),
            cancellationToken: token);

        return Unit.Value;
    }
}