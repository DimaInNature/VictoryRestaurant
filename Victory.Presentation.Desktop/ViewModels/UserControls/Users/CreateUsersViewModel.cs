namespace Victory.Presentation.Desktop.ViewModels.UserControls;

internal sealed class CreateUsersViewModel : BaseCreateViewModel
{
    #region Members

    #region Properties

    public string Login
    {
        get => _login ?? string.Empty;
        set
        {
            int maxLenght = 25;

            if (value == string.Empty)
            {
                _login = null;

                OnPropertyChanged(nameof(Login));

                return;
            }

            if (value.Length > 0)
            {
                if (value.Length > maxLenght) return;

                value = value.Replace(oldValue: " ", newValue: string.Empty);
            }

            _login = value;

            OnPropertyChanged(nameof(Login));
        }
    }

    public string Password
    {
        get => _password ?? string.Empty;
        set
        {
            int maxLenght = 25;

            if (value == string.Empty)
            {
                _password = null;

                OnPropertyChanged(nameof(Password));

                return;
            }

            if (value.Length > 0)
            {
                if (value.Length > maxLenght) return;

                value = value.Replace(oldValue: " ", newValue: string.Empty);
            }

            _password = value;

            OnPropertyChanged(nameof(Password));
        }
    }

    public List<UserRole> UserRoles
    {
        get => _userRoles ?? new();
        set
        {
            _userRoles = value;

            OnPropertyChanged(nameof(UserRoles));
        }
    }

    public UserRole? SelectedRole
    {
        get => _selectedRole;
        set
        {
            _selectedRole = value;

            OnPropertyChanged(nameof(SelectedRole));
        }
    }

    #endregion

    #region Private

    private string? _login;

    private string? _password;

    private UserRole? _selectedRole;

    private List<UserRole> _userRoles = new();

    #endregion

    #region Dependencies

    private readonly IUserRepositoryService _userService;

    private readonly IUserRoleRepositoryService _userRoleSerivce;

    private readonly UserSessionService _userSessionService;

    #endregion

    #endregion

    public CreateUsersViewModel(
        IUserRepositoryService userService,
        IUserRoleRepositoryService userRoleSerivce,
        UserSessionService userSessionService)
    {
        (_userService, _userRoleSerivce, _userSessionService) = (userService, userRoleSerivce, userSessionService);

        InitializeCommands();

        Task.Run(function: () => InitializeUserRoles());
    }

    #region Command Logic

    protected override bool CanExecuteCreate(object obj) =>
        StringHelper.StrIsNotNullOrWhiteSpace(Login, Password) && SelectedRole is not null;

    protected override async void ExecuteCreate(object obj)
    {
        if (SelectedRole is null)
        {
            MessageBox.Show(
                messageBoxText: "The user role was not selected",
                caption: "Warning",
                button: MessageBoxButton.OK,
                icon: MessageBoxImage.Warning);

            return;
        }

        User user = new()
        {
            Login = Login,
            Password = Password,
            UserRoleId = SelectedRole.Id
        };

        await _userService.CreateAsync(user);

        MessageBox.Show(
            messageBoxText: "The addition was successful",
            caption: "Success",
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
        SelectedRole = null;
    }

    private async Task InitializeUserRoles()
    {
        string? token = _userSessionService.JwtToken;

        if (string.IsNullOrWhiteSpace(value: token)) return;

        UserRoles = await _userRoleSerivce.GetUserRoleListAsync(token);
    }

    #endregion
}