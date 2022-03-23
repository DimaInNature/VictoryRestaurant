namespace VictoryRestaurant.Desktop.Presentation.ViewModels;

internal sealed class LoginViewModel
    : BaseViewModel, ILoginViewModel
{
    #region Members

    #region Commands

    public ICommand? LoginCommand { get; private set; }

    public ICommand? RegistrationCommand { get; private set; }

    #endregion

    #region Areas

    #region Authorization

    public string EnterUserLogin
    {
        get => _enterUserLogin ?? string.Empty;
        set
        {
            _enterUserLogin = string.IsNullOrWhiteSpace(value)
                ? string.Empty
                : value;
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

    #region Registration

    public string CreateUserLogin
    {
        get => _createUserLogin ?? string.Empty;
        set
        {
            _createUserLogin = string.IsNullOrWhiteSpace(value)
                ? string.Empty
                : value;
            OnPropertyChanged(nameof(CreateUserLogin));
        }
    }

    public SecureString SecureRegisterPassword
    {
        get => _secureRegisterPassword ?? new();
        set
        {
            _secureRegisterPassword = value;
            OnPropertyChanged(nameof(SecureRegisterPassword));
        }
    }

    public string RegisterPassword
    {
        get => _registerPassword ?? string.Empty;
        set
        {
            _registerPassword = value;
            IsRegisterPasswordWatermarkVisible = string.IsNullOrEmpty(_registerPassword);
        }
    }

    #endregion

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

    public bool IsRegisterPasswordWatermarkVisible
    {
        get => _isRegisterPasswordWatermarkVisible;
        set
        {
            if (value.Equals(_isRegisterPasswordWatermarkVisible)) return;

            _isRegisterPasswordWatermarkVisible = value;

            OnPropertyChanged(nameof(IsRegisterPasswordWatermarkVisible));
        }
    }

    #endregion

    #region Private

    private string? _enterUserLogin;

    private SecureString? _securePassword;

    private string? _password;

    private string? _createUserLogin;

    private SecureString? _secureRegisterPassword;

    private string? _registerPassword;

    private bool _isPasswordWatermarkVisible = true;

    private bool _isRegisterPasswordWatermarkVisible = true;

    #endregion

    #region Dependencies

    private readonly IUserFacadeService _userService;

    #endregion

    #endregion

    public LoginViewModel(IUserFacadeService userService)
    {
        _userService = userService;

        InitializeCommands();
    }

    #region Command Logic

    #region Execute

    private async void ExecuteLogin(object obj)
    {
        var user = await _userService.GetUserAsync(
            login: EnterUserLogin,
            password: Password);

        if (user is null)
        {
            MessageBox.Show(messageBoxText: "Такого пользователя не существует.",
                caption: "Ошибка авторизации", button: MessageBoxButton.OK, icon: MessageBoxImage.Error);

            return;
        }

        if (user.Role is not UserRole.Admin)
        {
            MessageBox.Show(
                messageBoxText: "У вас нет права доступа.",
                caption: "Система безопасности",
                button: MessageBoxButton.OK,
                icon: MessageBoxImage.Error);

            return;
        }

        new MainView().Show();

        (obj as LoginView)?.Close();
    }

    private async void ExecuteRegistration(object obj)
    {
        if (await _userService.GetUserAsync(login: CreateUserLogin) is not null)
        {
            MessageBox.Show(
                messageBoxText: "Пользователь уже существует.",
                caption: "Ошибка регистрации",
                button: MessageBoxButton.OK,
                icon: MessageBoxImage.Error);

            return;
        }

        User user = new()
        {
            Login = CreateUserLogin,
            Password = RegisterPassword,
            Role = UserRole.User
        };

        await _userService.InsertUserAsync(user);

        new MainView(activeUser: user).Show();

        (obj as LoginView)?.Close();
    }

    #endregion

    #region Can Execute

    private bool CanExecuteLogin(object obj) =>
        StringHelper.StrIsNotNullOrWhiteSpace(EnterUserLogin, Password);

    private bool CanExecuteRegistration(object obj) =>
        StringHelper.StrIsNotNullOrWhiteSpace(CreateUserLogin, RegisterPassword);

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