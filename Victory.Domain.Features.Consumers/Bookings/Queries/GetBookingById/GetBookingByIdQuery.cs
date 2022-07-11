namespace Victory.Domain.Features.Consumers.Bookings;

public sealed record class GetBookingByIdQuery
    : BaseAuthorizedFeature, IRequest<Booking>
{
    public int Id { get; }

    public GetBookingByIdQuery(int id, string token) =>
        (Id, Token) = (id, token);

    public GetBookingByIdQuery() { }
}