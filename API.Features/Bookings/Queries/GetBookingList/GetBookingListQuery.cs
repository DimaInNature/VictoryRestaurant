namespace API.Features.Bookings.Queries;

public sealed record class GetBookingListQuery : IRequest<List<BookingEntity>?>
{

}