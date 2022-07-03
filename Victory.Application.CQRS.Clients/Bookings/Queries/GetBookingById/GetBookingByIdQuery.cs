namespace Victory.Application.CQRS.Clients.Bookings;

public sealed record class GetBookingByIdQuery : IRequest<Booking>
{
    public int Id { get; }

    public GetBookingByIdQuery(int id) => Id = id;

    public GetBookingByIdQuery() { }
}