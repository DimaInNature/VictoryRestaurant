namespace Victory.Application.General.Client.Features.Bookings;

public sealed record class GetBookingByIdQuery : IRequest<Booking>
{
    public int Id { get; }

    public GetBookingByIdQuery(int id) => Id = id;

    public GetBookingByIdQuery() { }
}