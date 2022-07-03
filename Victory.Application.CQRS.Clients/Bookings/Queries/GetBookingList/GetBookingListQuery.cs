namespace Victory.Application.CQRS.Clients.Bookings;

public sealed record class GetBookingListQuery : IRequest<List<Booking>?> { }