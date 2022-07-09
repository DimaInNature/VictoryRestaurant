namespace Victory.Presentation.Desktop.ViewModels.UserControls;

internal sealed class UpdateUsersViewModel : BaseUpdateViewModel<User, UserRole>
{
    #region Dependencies

    private readonly IUserFacadeService _userService;

    private readonly IUserRoleFacadeService _userRoleService;

    private readonly UserSessionService _sessionService;

    #endregion

    public UpdateUsersViewModel(IUserFacadeService userService,
        UserSessionService sessionService, IUserRoleFacadeService userRoleService)
    {
        (_userService, _userRoleService, _sessionService) = (userService, userRoleService, sessionService);

        InitializeCommands();

        Task.Run(function: () => InitializeData());
    }

    #region Command Logic

    protected override bool CanExecuteUpdateCommand(object obj) =>
        SelectedGeneralValue is not null && SelectedAggregatedValue is not null &&
        StringHelper.StrIsNotNullOrWhiteSpace(SelectedGeneralValue.Login, SelectedGeneralValue.Password);

    protected async override void ExecuteUpdateCommand(object obj)
    {
        string? token = _sessionService.JwtToken;

        if (SelectedGeneralValue is null || SelectedAggregatedValue is null ||
            string.IsNullOrWhiteSpace(value: token)) return;

        if (SelectedGeneralValue.Login == _sessionService?.ActiveUser?.Login)
        {
            MessageBox.Show(
                messageBoxText: "It is not possible to edit the user of this session",
                caption: "Error",
                button: MessageBoxButton.OK,
                icon: MessageBoxImage.Error);

            return;
        }

        SelectedGeneralValue.UserRoleId = SelectedAggregatedValue.Id;

        await _userService.UpdateAsync(entity: SelectedGeneralValue, token);

        MessageBox.Show(
           messageBoxText: "The change was successful",
           caption: "Success",
           button: MessageBoxButton.OK,
           icon: MessageBoxImage.Information);

        await InitializeData();

        Clear();
    }

    #endregion

    #region Other Logic

    protected override void SelectGeneralValue()
    {
        if (SelectedGeneralValue is not null)
        {
            SelectedAggregatedValue = SelectedGeneralValue.UserRole;

            SelectedAggredatedValueIndex = AggregatedDataList.FindIndex(match: x => x.Id == SelectedAggregatedValue?.Id);
        }
    }

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

    protected override async Task UpdateData() => await InitializeData();

    private void InitializeCommands()
    {
        UpdateCommand = new RelayCommand(executeAction: ExecuteUpdateCommand,
            canExecuteFunc: CanExecuteUpdateCommand);
    }

    private async Task InitializeData()
    {
        string? token = _sessionService.JwtToken;

        if (string.IsNullOrWhiteSpace(value: token)) return;

        GeneralDataList = await _userService.GetUserListAsync(token);

        AggregatedDataList = await _userRoleService.GetUserRoleListAsync(token);
    }

    #endregion
}