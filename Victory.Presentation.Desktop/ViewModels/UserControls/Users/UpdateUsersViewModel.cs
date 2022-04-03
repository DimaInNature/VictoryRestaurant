namespace Victory.Presentation.Desktop.ViewModels.UserControls;

internal sealed class UpdateUsersViewModel
    : BaseUpdateViewModel<User>, IUpdateUsersViewModel
{
    public string[] RoleList => Enum.GetNames(typeof(UserRole));

    private readonly IUserFacadeService _userService;

    private readonly UserSessionService _sessionService;

    public UpdateUsersViewModel(IUserFacadeService userService,
        UserSessionService sessionService)
    {
        _userService = userService;

        _sessionService = sessionService;

        InitializeCommands();

        Task.Run(function: () => AutoUpdateData(
            secondsTimeout: ApplicationConfiguration.AutoUpdateSecondsTimeout,
            isEnable: ApplicationConfiguration.AutoUpdateIsEnable));
    }

    #region Command Logic

    protected override bool CanExecuteUpdateCommand(object obj) =>
        SelectedItem is not null &&
        StringHelper.StrIsNotNullOrWhiteSpace(SelectedItem.Login, SelectedItem.Password);

    protected override async void ExecuteUpdateCommand(object obj)
    {
        if (SelectedItem is null || SelectedIndex is null) return;

        if (SelectedItem.Login == _sessionService?.ActiveUser?.Login)
        {
            MessageBox.Show(
                messageBoxText: "Невозможно редактировать пользователя этой сессии",
                caption: "Ошибка редактирования",
                button: MessageBoxButton.OK,
                icon: MessageBoxImage.Error);

            return;
        }

        SelectedItem.Role = (UserRole)SelectedIndex;

        await _userService.UpdateAsync(SelectedItem);

        MessageBox.Show(
           messageBoxText: "Изменение произошло успешно",
           caption: "Успех",
           button: MessageBoxButton.OK,
           icon: MessageBoxImage.Information);

        await InitializeData();

        Clear();
    }

    #endregion

    #region Other Logic

    private void InitializeCommands()
    {
        UpdateCommand = new RelayCommand(executeAction: ExecuteUpdateCommand,
            canExecuteFunc: CanExecuteUpdateCommand);
    }

    private void Clear()
    {
        _selectedItem = null;
        OnPropertyChanged(nameof(SelectedItem));

        _selectedIndex = null;
        OnPropertyChanged(nameof(SelectedIndex));

        _lastItemId = null;
    }

    private async Task InitializeData()
    {
        Items = await _userService.GetUserListAsync();
    }

    private async Task AutoUpdateData(int secondsTimeout, bool isEnable)
    {
        // First loading data

        await InitializeData();

        int millisecondsTimeout = secondsTimeout *= 1000;

        while (isEnable)
        {
            Thread.Sleep(millisecondsTimeout: millisecondsTimeout);

            await InitializeData();
        }
    }

    #endregion
}