namespace Victory.Application.API.Features.Bookings;

public sealed record class GetBookingListQuery : IRequest<List<BookingEntity>?> { }