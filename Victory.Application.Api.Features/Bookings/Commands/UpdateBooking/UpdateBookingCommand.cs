namespace Victory.Application.API.Features.Bookings;

public sealed record class UpdateBookingCommand : IRequest
{
    public BookingEntity? Booking { get; }

    public UpdateBookingCommand(BookingEntity entity) => Booking = entity;

    public UpdateBookingCommand() { }
}