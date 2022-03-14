namespace API.Data.Repositories;

public class UserRepository : IUserRepository
{
    private readonly ApplicationContext _context;
    private bool _disposed = false;

    public UserRepository(ApplicationContext context)
    {
        _context = context;
    }

    public async Task<List<UserEntity>> GetUsersAsync() =>
        await _context.Users.ToListAsync();

    public async Task<UserEntity> GetUserAsync(int userId) =>
         await _context.Users.FindAsync(new object[] { userId });

    public async Task<UserEntity> GetUserAsync(UserEntity user) =>
        await _context.Users.FirstOrDefaultAsync(
            u => string.Equals(u.Login, user.Login) && string.Equals(u.Password, user.Password));

    public async Task InsertUserAsync(UserEntity user) =>
         await _context.Users.AddAsync(user);

    public async Task UpdateUserAsync(UserEntity user)
    {
        var userFromDb = await _context.Users.FindAsync(new object[] { user.Id });

        if (userFromDb is null) return;

        userFromDb.Id = user.Id;
        userFromDb.Login = user.Login;
        userFromDb.Password = user.Password;
    }

    public async Task DeleteUserAsync(int userId)
    {
        var userFromDb = await _context.Users.FindAsync(new object[] { userId });

        if (userFromDb is null) return;

        _context.Users.Remove(userFromDb);
    }

    public async Task<int> SaveAsync() => await _context.SaveChangesAsync();

    public void Dispose()
    {
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (_disposed is false)
            if (disposing)
                _context.Dispose();

        _disposed = true;
    }
}