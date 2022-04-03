namespace Victory.Presentation.Desktop.ViewModels.UserControls;

internal sealed class CreateUsersViewModel
    : BaseCreateViewModel, ICreateUsersViewModel
{
    #region Members

    #region Properties

    public string Login
    {
        get => _login ?? string.Empty;
        set
        {
            _login = value;
            OnPropertyChanged(nameof(Login));
        }
    }

    public string Password
    {
        get => _password ?? string.Empty;
        set
        {
            _password = value;
            OnPropertyChanged(nameof(Password));
        }
    }

    public UserRole Role
    {
        get => _role;
        set
        {
            _role = value;
            OnPropertyChanged(nameof(Role));
        }
    }

    #endregion

    #region Private

    private string? _login;

    private string? _password;

    private UserRole _role;

    #endregion

    #region Dependencies

    private readonly IUserFacadeService _userService;

    #endregion

    #endregion

    public CreateUsersViewModel(IUserFacadeService userService)
    {
        _userService = userService;

        InitializeCommands();
    }

    #region Command Logic

    protected override bool CanExecuteCreate(object obj) =>
        StringHelper.StrIsNotNullOrWhiteSpace(Login, Password) &&
        Enum.IsDefined(typeof(UserRole), Role) && Role is not UserRole.None;

    protected override async void ExecuteCreate(object obj)
    {
        User user = new()
        {
            Login = Login,
            Password = Password,
            Role = Role
        };

        await _userService.CreateAsync(user);

        MessageBox.Show(
            messageBoxText: "Добавление произошло успешно",
            caption: "Успех",
            button: MessageBoxButton.OK,
            icon: MessageBoxImage.Information);

        Clear();
    }

    #endregion

    #region Other Logic

    private void InitializeCommands()
    {
        CreateCommand = new RelayCommand(executeAction: ExecuteCreate,
            canExecuteFunc: CanExecuteCreate);
    }

    private void Clear()
    {
        Login = string.Empty;
        Password = string.Empty;
        Role = default;
    }

    #endregion
}