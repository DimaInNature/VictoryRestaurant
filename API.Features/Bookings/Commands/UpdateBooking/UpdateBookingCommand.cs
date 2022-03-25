namespace API.Features.Bookings.Commands;

public sealed record class UpdateBookingCommand : IRequest
{
    public BookingEntity? Booking { get; }

    public UpdateBookingCommand(BookingEntity booking!!) => Booking = booking;

    public UpdateBookingCommand() { }
}