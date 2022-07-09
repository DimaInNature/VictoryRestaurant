namespace Victory.Application.CQRS.Clients.Bookings;

public sealed record class GetBookingListQuery
	: BaseAuthorizedFeature, IRequest<List<Booking>?>
{
	public GetBookingListQuery(string token) => Token = token;

	public GetBookingListQuery() { }
}