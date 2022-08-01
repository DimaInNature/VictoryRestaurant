namespace Victory.Consumers.Web.Domain.Commands.Bookings;

public sealed record class CreateBookingCommand
    : BaseAnonymousFeature, IRequest<Booking?>
{
    public Booking? Booking { get; }

    public CreateBookingCommand(Booking entity) => Booking = entity;

    public CreateBookingCommand() { }
}