namespace Web.Services.Bookings;

public class BookingRepositoryService : IBookingRepositoryService
{
    private readonly IBookingRepository _repository;
    private readonly IMapper _mapper;

    public BookingRepositoryService(IMapper mapper,
        IBookingRepository repository)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task InsertBookingAsync(Booking booking) =>
        await _repository.InsertBookingAsync(
            booking: _mapper.Map<BookingEntity>(source: booking));
}
