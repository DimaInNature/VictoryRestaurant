namespace Victory.Domain.Features.Consumers.Bookings;

public sealed record class GetBookingListQuery
	: BaseAuthorizedFeature, IRequest<List<Booking>?>
{
	public GetBookingListQuery(string token) => Token = token;

	public GetBookingListQuery() { }
}