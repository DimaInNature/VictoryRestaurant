namespace Victory.Application.Api.Features.Bookings;

public sealed record class GetBookingListQuery : IRequest<List<BookingEntity>?> { }