namespace Victory.Consumers.Desktop.Presentation.ViewModels;

internal sealed class DeleteUsersViewModel : BaseDeleteViewModel<User>
{
    private readonly IUserService _userService;

    private readonly UserSessionService _sessionService;

    public DeleteUsersViewModel(
        IUserService userService,
        UserSessionService sessionService)
    {
        (_userService, _sessionService) = (userService, sessionService);

        InitializeCommands();

        Task.Run(function: () => InitializeData());
    }

    #region Command Logic

    protected override bool CanExecuteDeleteCommand(object obj) =>
        SelectedGeneralValue is not null;

    protected override async void ExecuteDeleteCommand(object obj)
    {
        string? token = _sessionService.JwtToken;

        if (SelectedGeneralValue is null || string.IsNullOrWhiteSpace(value: token)) return;

        if (SelectedGeneralValue.Login == _sessionService?.ActiveUser?.Login)
        {
            MessageBox.Show(
                messageBoxText: "It is not possible to delete a user of this session",
                caption: "Error",
                button: MessageBoxButton.OK,
                icon: MessageBoxImage.Error);

            return;
        }

        await _userService.DeleteAsync(id: SelectedGeneralValue.Id, token);

        MessageBox.Show(
           messageBoxText: "The deletion was successfu",
           caption: "Success",
           button: MessageBoxButton.OK,
           icon: MessageBoxImage.Information);

        await InitializeData();

        Clear();
    }

    #endregion

    #region Other Logic

    protected override async void Find(string filter)
    {
        string? token = _sessionService.JwtToken;

        if (string.IsNullOrWhiteSpace(value: token)) return;

        var users = await _userService.GetUserListAsync(token);

        filter = filter.ToLower();

        GeneralDataList = users.Where(predicate:
            user =>
            user.Login.ToLower().Contains(value: filter))
            .ToList();
    }

    protected async override Task UpdateData() => await InitializeData();

    protected override void SelectGeneralValue() { }

    private void InitializeCommands()
    {
        DeleteCommand = new RelayCommand(executeAction: ExecuteDeleteCommand,
            canExecuteFunc: CanExecuteDeleteCommand);
    }

    private async Task InitializeData()
    {
        string? token = _sessionService.JwtToken;

        if (string.IsNullOrWhiteSpace(value: token)) return;

        GeneralDataList = await _userService.GetUserListAsync(token);
    }

    #endregion
}