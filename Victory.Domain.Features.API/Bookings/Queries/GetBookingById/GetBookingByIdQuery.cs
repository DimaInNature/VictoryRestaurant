namespace Victory.Domain.Features.API.Bookings;

public sealed record class GetBookingByIdQuery : IRequest<BookingEntity?>
{
    public int Id { get; }

    public GetBookingByIdQuery(int id) => Id = id;

    public GetBookingByIdQuery() { }
}