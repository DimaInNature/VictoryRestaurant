namespace Victory.Application.Services.Features.Bookings;

public sealed record class CreateBookingCommand : IRequest
{
    public BookingEntity? Booking { get; }

    public CreateBookingCommand(BookingEntity entity) => Booking = entity;

    public CreateBookingCommand() { }
}