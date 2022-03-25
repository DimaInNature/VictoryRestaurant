namespace API.Features.Bookings.Commands;

public sealed record class CreateBookingCommand : IRequest
{
    public BookingEntity? Booking { get; }

    public CreateBookingCommand(BookingEntity booking!!) => Booking = booking;

    public CreateBookingCommand() { }
}