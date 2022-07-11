namespace Victory.Domain.Features.API.Bookings;

public sealed record class GetBookingListQuery : IRequest<List<BookingEntity>?> { }