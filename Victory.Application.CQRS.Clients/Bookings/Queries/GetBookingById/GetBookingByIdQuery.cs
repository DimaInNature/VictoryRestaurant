namespace Victory.Application.CQRS.Clients.Bookings;

public sealed record class GetBookingByIdQuery
    : BaseAuthorizedFeature, IRequest<Booking>
{
    public int Id { get; }

    public GetBookingByIdQuery(int id, string token) =>
        (Id, Token) = (id, token);

    public GetBookingByIdQuery() { }
}