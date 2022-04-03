namespace Victory.Application.Services;

public class BookingFacadeService : IBookingFacadeService
{
    private readonly IBookingRepositoryService _repository;
    private readonly ICacheService<BookingEntity> _cache;

    public BookingFacadeService(IBookingRepositoryService repository,
        ICacheService<BookingEntity> cache) =>
        (_repository, _cache) = (repository, cache);

    public async Task<IEnumerable<BookingEntity>> GetBookingListAsync() =>
        await _repository.GetBookingListAsync() ?? new();

    public async Task<BookingEntity?> GetBookingAsync(int id)
    {
        if (_cache.TryGet(id, out var entity)) return entity;

        entity = await _repository.GetBookingAsync(id);

        return entity is null ? null : _cache.Set(key: id, value: entity);
    }

    public async Task CreateAsync(BookingEntity entity)
    {
        if (entity is null) return;

        await _repository.CreateAsync(entity);

        _cache.Set(key: entity.Id, value: entity);
    }

    public async Task UpdateAsync(BookingEntity entity)
    {
        if (entity is null) return;

        await _repository.UpdateAsync(entity);

        _cache.Set(key: entity.Id, value: entity);
    }

    public async Task DeleteAsync(int id)
    {
        await _repository.DeleteAsync(id);

        if (_cache.TryGet(key: id, out _))
            _cache.Remove(key: id);
    }
}