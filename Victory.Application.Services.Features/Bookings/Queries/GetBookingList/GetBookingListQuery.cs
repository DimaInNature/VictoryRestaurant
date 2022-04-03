namespace Victory.Application.Services.Features.Bookings;

public sealed record class GetBookingListQuery : IRequest<List<BookingEntity>?> { }