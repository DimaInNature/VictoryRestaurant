namespace Victory.Application.Desktop.Sessions;

public class UserSessionService
{
    private readonly IUserFacadeService _userService;

    public UserSessionService(IUserFacadeService userService) => _userService = userService;

    public User? ActiveUser
    {
        get => _activeUser;
        private set
        {
            ArgumentNullException.ThrowIfNull(value, nameof(ActiveUser));

            _activeUser = value;
        }
    }

    private User? _activeUser;

    public bool IsActive { get; private set; } = false;

    public async Task StartSession(User activeUser)
    {
        if (IsActive) return;

        var user = await _userService.GetUserAsync(
            login: activeUser.Login,
            password: activeUser.Password);

        ArgumentNullException.ThrowIfNull(user, nameof(user));

        ActiveUser = user;

        IsActive = true;
    }

    public void EndSession()
    {
        if (IsActive is false) return;

        _activeUser = null;

        IsActive = false;
    }
}