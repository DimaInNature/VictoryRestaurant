namespace Victory.Application.Desktop.Sessions;

public class UserSessionService
{
    public string? JwtToken { get; private set; } = null;

    public bool IsActive { get; private set; } = false;

    private readonly IUserFacadeService _userService;

    private readonly JWTAuthorizationService _authorizationService;

    public UserSessionService(
        IUserFacadeService userService,
        JWTAuthorizationService authorizationService) =>
        (_userService, _authorizationService) = (userService, authorizationService);

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

    public async Task StartSession(User activeUser)
    {
        if (IsActive) return;

        UserLogin userLogin = new(login: activeUser.Login, password: activeUser.Password);

        var user = await _userService.GetUserAsync(userLogin);

        ArgumentNullException.ThrowIfNull(user, nameof(user));

        ActiveUser = user;

        JwtToken = await _authorizationService.Authorize(userLogin);

        ArgumentNullException.ThrowIfNull(argument: JwtToken, paramName: nameof(JwtToken));

        IsActive = true;
    }

    public void EndSession()
    {
        if (IsActive is false) return;

        _activeUser = null;

        JwtToken = null;

        IsActive = false;
    }
}