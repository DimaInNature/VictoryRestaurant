namespace Victory.Application.Desktop.Data.Bookings;

public class BookingFacadeService : IBookingFacadeService
{
    private readonly IBookingRepositoryService _repository;

    public BookingFacadeService(IBookingRepositoryService repository) => _repository = repository;

    public async Task<List<Booking>> GetBookingListAsync(string token) =>
        await _repository.GetBookingListAsync(token) ?? new();

    public async Task<Booking?> GetBookingAsync(int id, string token) =>
        await _repository.GetBookingAsync(id, token);

    public async Task<Table?> GetBookingTableAsync(int id, string token) =>
        await _repository.GetBookingTableAsync(id, token);

    public async Task<Booking?> CreateAsync(Booking entity) =>
         await _repository.CreateAsync(entity);

    public async Task DeleteAsync(int id, string token) =>
         await _repository.DeleteAsync(id, token);
}