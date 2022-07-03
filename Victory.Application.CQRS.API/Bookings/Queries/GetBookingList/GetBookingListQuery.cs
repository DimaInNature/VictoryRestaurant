namespace Victory.Application.CQRS.API.Bookings;

public sealed record class GetBookingListQuery : IRequest<List<BookingEntity>?> { }