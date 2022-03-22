namespace VictoryRestaurant.Desktop.Presentation.ViewModels;

public class LoginViewModel : BaseViewModel
{
    private readonly IUserFacadeService _userService;

    public LoginViewModel(IUserFacadeService userService)
    {
        _userService = userService;

        InitializeCommands();
        SetViewCondition();
    }

    #region Properties

    #region Login

    public string EnterUserLogin
    {
        get => _enterUserLogin;
        set
        {
            _enterUserLogin = string.IsNullOrWhiteSpace(value)
                ? string.Empty
                : value;
            OnPropertyChanged(nameof(EnterUserLogin));
        }
    }

    private string _enterUserLogin;

    public SecureString SecurePassword
    {
        get => _securePassword;
        set
        {
            _securePassword = value;
            OnPropertyChanged(nameof(SecurePassword));
            OnPropertyChanged(nameof(Password));
        }
    }

    private SecureString _securePassword;

    public unsafe string Password
    {
        [SecurityCritical]
        get => SecurePassword is null
            ? string.Empty
            : new string(value: (char*)(void*)Marshal.SecureStringToBSTR(s: SecurePassword));
        [SecurityCritical]
        set
        {
            if (value is null)
                value = string.Empty;

            using (SecureString secureString = new SecureString())
            {
                for (int i = 0; i < value.Length; i++)
                {
                    secureString.AppendChar(c: value[i]);
                }
            }
            _password = value;
            IsPasswordWatermarkVisible = string.IsNullOrEmpty(_password);
        }
    }

    private string _password;

    #endregion

    #region Registration

    public string CreateUserLogin
    {
        get => _createUserLogin;
        set
        {
            _createUserLogin = string.IsNullOrWhiteSpace(value)
                ? string.Empty
                : value;
            OnPropertyChanged(nameof(CreateUserLogin));
        }
    }

    private string _createUserLogin;

    public SecureString SecureRegisterPassword
    {
        get => _secureRegisterPassword;
        set
        {
            _secureRegisterPassword = value;
            OnPropertyChanged(nameof(SecureRegisterPassword));
        }
    }

    private SecureString _secureRegisterPassword;

    public string RegisterPassword
    {
        get => _registerPassword;
        set
        {
            _registerPassword = value;
            IsRegisterPasswordWatermarkVisible = string.IsNullOrEmpty(_registerPassword);
        }
    }

    private string _registerPassword;

    #endregion

    #region Commands

    public ICommand LoginCommand { get; private set; }

    public ICommand RegistrationCommand { get; private set; }

    public ICommand CloseApplicationCommand { get; private set; }

    public ICommand RecoverCommand { get; private set; }

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

    private bool _isPasswordWatermarkVisible;

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

    private bool _isRegisterPasswordWatermarkVisible;

    #endregion

    #endregion

    #region Commands

    private bool CanExecuteLogin(object obj) =>
        StringHelper.StrIsNotNullOrWhiteSpace(EnterUserLogin, Password);

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

    private bool CanExecuteRegistration(object obj) =>
        StringHelper.StrIsNotNullOrWhiteSpace(CreateUserLogin, RegisterPassword);

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

        new MainView(user).Show();

        (obj as LoginView)?.Close();
    }

    private static void CloseApplication(object obj) =>
        Application.Current.Shutdown();

    #endregion

    #region Methods

    private void SetViewCondition()
    {
        IsPasswordWatermarkVisible = IsRegisterPasswordWatermarkVisible = true;
    }

    private void InitializeCommands()
    {
        LoginCommand = new RelayCommand(executeAction: ExecuteLogin,
            canExecuteFunc: CanExecuteLogin);

        RegistrationCommand = new RelayCommand(executeAction: ExecuteRegistration,
            canExecuteFunc: CanExecuteRegistration);

        CloseApplicationCommand = new RelayCommand(executeAction: CloseApplication);
    }

    #endregion
}