namespace Victory.Application.Features.Bookings;

public sealed record class GetBookingListQuery : IRequest<List<Booking>?> { }