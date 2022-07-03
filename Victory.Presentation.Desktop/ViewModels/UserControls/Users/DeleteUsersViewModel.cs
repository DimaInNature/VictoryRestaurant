namespace Victory.Presentation.Desktop.ViewModels.UserControls;

internal sealed class DeleteUsersViewModel : BaseDeleteViewModel<User>
{
    private readonly IUserFacadeService _userService;

    private readonly UserSessionService _sessionService;

    public DeleteUsersViewModel(IUserFacadeService userService,
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
        if (SelectedGeneralValue is null) return;

        if (SelectedGeneralValue.Login == _sessionService?.ActiveUser?.Login)
        {
            MessageBox.Show(
                messageBoxText: "It is not possible to delete a user of this session",
                caption: "Error",
                button: MessageBoxButton.OK,
                icon: MessageBoxImage.Error);

            return;
        }

        await _userService.DeleteAsync(SelectedGeneralValue.Id);

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
        var users = await _userService.GetUserListAsync();

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

    private async Task InitializeData() =>
        GeneralDataList = await _userService.GetUserListAsync();

    #endregion
}