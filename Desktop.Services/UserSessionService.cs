using System.Threading;
using System.Windows;

namespace Desktop.Services;

public class UserSessionService
{
    private readonly IUserFacadeService _userService;

    public UserSessionService(IUserFacadeService userService)
    {
        _userService = userService;
    }

    public User? ActiveUser
    {
        get => _activeUser;
        private set => _activeUser = value is null
            ? throw new ArgumentNullException("ActiveUser is null")
            : value;
    }

    private User? _activeUser;

    public bool IsActive { get; private set; } = false;

    public async Task StartSession(User activeUser)
    {
        if (IsActive) return;

        var user = await _userService.GetUserAsync(
            login: activeUser.Login,
            password: activeUser.Password);

        if (user is null)
            throw new ArgumentNullException("ActiveUser is null");

        ActiveUser = user;

        IsActive = true;

        await Task.Run(() => AutoCheckSessionState(secondsTimeout: 15));
    }

    private async void AutoCheckSessionState(int secondsTimeout)
    {
        int millisecondsTimeout = secondsTimeout *= 1000;

        while (IsActive)
        {
            var user = await _userService.GetUserAsync(
                login: ActiveUser.Login,
                password: ActiveUser.Password);

            if (ActiveUser.Equals(user) is false)
                CloseApplication();

            Thread.Sleep(millisecondsTimeout: millisecondsTimeout);
        }
    }

    private void CloseApplication()
    {
        MessageBox.Show(
            messageBoxText: "Данные сессии были изменены. Завершение работы.",
            caption: "Информация",
            button: MessageBoxButton.OK,
            icon: MessageBoxImage.Information);

        Environment.Exit(exitCode: 0);
    }

    public void EndSession()
    {
        if (IsActive is false) return;

        _activeUser = null;

        IsActive = false;
    }
}