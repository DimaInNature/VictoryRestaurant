namespace Victory.Presentation.Desktop.ViewModels;

internal sealed class LoginViewModel : BaseViewModel
{
    #region Members

    public bool IsConnectionStopped = false;

    #region Properties

    public string EnterUserLogin
    {
        get => _enterUserLogin ?? string.Empty;
        set
        {
            int maxLenght = 25;

            if (value == string.Empty)
            {
                _enterUserLogin = null;

                OnPropertyChanged(nameof(EnterUserLogin));

                return;
            }

            if (value.Length > 0)
            {
                if (value.Length > maxLenght) return;

                value = value.Replace(oldValue: " ", newValue: string.Empty);
            }

            _enterUserLogin = value;

            OnPropertyChanged(nameof(EnterUserLogin));
        }
    }

    public SecureString SecurePassword
    {
        get => _securePassword ?? new();
        set
        {
            _securePassword = value;

            OnPropertyChanged(nameof(SecurePassword));
            OnPropertyChanged(nameof(Password));
        }
    }

    public unsafe string Password
    {
        [SecurityCritical]
        get => new(value: (char*)(void*)Marshal.SecureStringToBSTR(s: SecurePassword));
        [SecurityCritical]
        set
        {
            if (value is null)
                value = string.Empty;

            using (SecureString secureString = new())
            {
                foreach (char c in value)
                    secureString.AppendChar(c);
            }
            _password = value;
            IsPasswordWatermarkVisible = string.IsNullOrEmpty(_password);
        }
    }

    #endregion

    #region Commands

    public ICommand? LoginCommand { get; private set; }

    public ICommand? RegistrationCommand { get; private set; }

    #endregion

    #region View

    public bool IsPasswordWatermarkVisible
    {
        get => _isPasswordWatermarkVisible;
        set
        {
            if (value.Equals(_isPasswordWatermarkVisible)) return;

            _isPasswordWatermarkVisible = value;

            OnPropertyChanged(nameof(IsPasswordWatermarkVisible));
        }
    }

    #endregion

    #region Private

    private string? _enterUserLogin;

    private SecureString? _securePassword;

    private string? _password;

    private bool _isPasswordWatermarkVisible = true;

    #endregion

    #region Dependencies

    private readonly IUserFacadeService _userService;

    private readonly UserSessionService _sessionService;

    #endregion

    #endregion

    public LoginViewModel(IUserFacadeService userService,
        UserSessionService sessionService)
    {
        _userService = userService;
        _sessionService = sessionService;

        InitializeCommands();
    }

    #region Command Logic

    #region Execute

    private async void ExecuteLogin(object obj)
    {
        try
        {
            var user = await _userService.GetUserAsync(
                login: EnterUserLogin,
                password: Password);

            if (user is null | string.IsNullOrWhiteSpace(value: user?.Login))
            {
                MessageBox.Show(messageBoxText: "User is not exist.",
                    caption: "Authorization error", button: MessageBoxButton.OK, icon: MessageBoxImage.Error);

                IsConnectionStopped = true;

                return;
            }

            if (user?.UserRole?.Name is not "Admin" and not "Employee")
            {
                MessageBox.Show(
                    messageBoxText: "You don't have access rights.",
                    caption: "Security system",
                    button: MessageBoxButton.OK,
                    icon: MessageBoxImage.Error);

                IsConnectionStopped = true;

                return;
            }

            await _sessionService.StartSession(activeUser: user);

            new MainView().Show();

            (obj as Window)?.Close();
        }
        catch
        {
            MessageBox.Show(
                messageBoxText: "Unable to connect to the server.",
                caption: "Connection error",
                button: MessageBoxButton.OK,
                icon: MessageBoxImage.Error);
        }

        IsConnectionStopped = true;
    }

    private async void ExecuteRegistration(object obj)
    {
        var findedUser = await _userService.GetUserAsync(login: EnterUserLogin);

        if (findedUser is not null)
        {
            if (string.IsNullOrWhiteSpace(findedUser.Login) is false)
            {
                MessageBox.Show(
                  messageBoxText: "The user already exists.",
                  caption: "Registration error",
                  button: MessageBoxButton.OK,
                  icon: MessageBoxImage.Error);

                IsConnectionStopped = true;

                return;
            }
        }

        User user = new()
        {
            Login = EnterUserLogin,
            Password = Password,
            UserRoleId = 3
        };

        await _userService.CreateAsync(user);

        await _sessionService.StartSession(activeUser: user);

        IsConnectionStopped = true;

        new MainView().Show();

        (obj as Window)?.Close();
    }

    #endregion

    #region Can Execute

    private bool CanExecuteLogin(object obj) =>
        StringHelper.StrIsNotNullOrWhiteSpace(EnterUserLogin, Password);

    private bool CanExecuteRegistration(object obj) =>
        StringHelper.StrIsNotNullOrWhiteSpace(EnterUserLogin, Password);

    #endregion

    #endregion

    #region Other Logic

    private void InitializeCommands()
    {
        LoginCommand = new RelayCommand(executeAction: ExecuteLogin,
            canExecuteFunc: CanExecuteLogin);

        RegistrationCommand = new RelayCommand(executeAction: ExecuteRegistration,
            canExecuteFunc: CanExecuteRegistration);
    }

    #endregion
}