namespace Victory.Application.Features.Bookings;

public sealed record class CreateBookingCommand : IRequest
{
    public Booking? Booking { get; }

    public CreateBookingCommand(Booking entity) => Booking = entity;

    public CreateBookingCommand() { }
}