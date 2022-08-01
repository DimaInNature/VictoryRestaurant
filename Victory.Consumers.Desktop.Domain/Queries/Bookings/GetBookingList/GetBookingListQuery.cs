namespace Victory.Consumers.Desktop.Domain.Queries.Bookings;

public sealed record class GetBookingListQuery
    : BaseAuthorizedFeature, IRequest<List<Booking>?>
{
    public GetBookingListQuery(string token) => Token = token;

    public GetBookingListQuery() { }
}