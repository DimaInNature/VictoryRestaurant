namespace Victory.Application.Desktop.Data.Bookings;

public sealed class BookingFacadeService : IBookingFacadeService
{
    private readonly IBookingRepositoryService _repository;

    public BookingFacadeService(IBookingRepositoryService repository) =>
        _repository = repository;

    public async Task<List<Booking>> GetBookingListAsync() =>
        await _repository.GetBookingListAsync();

    public async Task<Booking?> GetBookingAsync(int id) =>
        await _repository.GetBookingAsync(id);

    public async Task DeleteAsync(int id) =>
        await _repository.DeleteAsync(id);
}