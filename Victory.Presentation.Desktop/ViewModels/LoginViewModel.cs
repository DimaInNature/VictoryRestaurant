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

    private readonly IUserRepositoryService _userService;

    private readonly UserSessionService _sessionService;

    #endregion

    #endregion

    public LoginViewModel(IUserRepositoryService userService,
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
        var user = await _userService
            .GetUserAsync(userLogin: new UserLogin(EnterUserLogin, Password));

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

        IsConnectionStopped = true;
    }

    private async void ExecuteRegistration(object obj)
    {
        User user = new()
        {
            Login = EnterUserLogin,
            Password = Password,
            UserRoleId = 3
        };

        User? createdUser = await _userService.CreateAsync(user);

        if (createdUser is null)
        {
            if (string.IsNullOrWhiteSpace(createdUser?.Login) is false)
            {
                MessageBox.Show(
                  messageBoxText: "The user already exists.",
                  caption: "Registration error",
                  button: MessageBoxButton.OK,
                  icon: MessageBoxImage.Error);

                IsConnectionStopped = true;
            }

            return;
        }

        await _sessionService.StartSession(activeUser: createdUser);

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