namespace Victory.Application.Desktop.Services;

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

        await Task.Run(() => AutoCheckSessionState(secondsTimeout: 15));
    }

    public void EndSession()
    {
        if (IsActive is false) return;

        _activeUser = null;

        IsActive = false;
    }

    private static void CloseApplication() => Environment.Exit(exitCode: 0);

    private async void AutoCheckSessionState(int secondsTimeout)
    {
        int millisecondsTimeout = secondsTimeout *= 1000;

        while (IsActive)
        {
            if (ActiveUser is null) return;

            var user = await _userService.GetUserAsync(
                login: ActiveUser.Login,
                password: ActiveUser.Password);

            if (user is null || ActiveUser.Equals(user) is false)
                CloseApplication();

            Thread.Sleep(millisecondsTimeout: millisecondsTimeout);
        }
    }
}