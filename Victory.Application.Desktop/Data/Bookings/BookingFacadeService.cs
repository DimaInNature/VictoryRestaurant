namespace Victory.Application.Desktop.Data.Bookings;

public class BookingFacadeService : IBookingFacadeService
{
    private readonly IBookingRepositoryService _repository;

    public BookingFacadeService(IBookingRepositoryService repository) => _repository = repository;

    public async Task<List<Booking>> GetBookingListAsync() =>
        await _repository.GetBookingListAsync() ?? new();

    public async Task<Booking?> GetBookingAsync(int id) =>
        await _repository.GetBookingAsync(id);

    public async Task<Table?> GetBookingTableAsync(int id) =>
        await _repository.GetBookingTableAsync(id);

    public async Task<Booking?> CreateAsync(Booking entity) =>
         await _repository.CreateAsync(entity);

    public async Task DeleteAsync(int id) =>
         await _repository.DeleteAsync(id);
}