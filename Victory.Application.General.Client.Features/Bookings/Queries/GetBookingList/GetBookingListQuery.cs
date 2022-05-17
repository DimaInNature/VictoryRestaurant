namespace Victory.Application.General.Client.Features.Bookings;

public sealed record class GetBookingListQuery : IRequest<List<Booking>?> { }