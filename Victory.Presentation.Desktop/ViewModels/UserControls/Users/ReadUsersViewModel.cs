namespace Victory.Presentation.Desktop.ViewModels.UserControls;

internal sealed class ReadUsersViewModel : BaseReadViewModel<User>
{
    private readonly IUserRepositoryService _userService;

    private readonly UserSessionService _sessionService;

    public ReadUsersViewModel(
        IUserRepositoryService userService,
        UserSessionService sessionService)
    {
        (_userService, _sessionService) = (userService, sessionService);

        Task.Run(function: () => InitializeData());
    }

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

    private async Task InitializeData()
    {
        string? token = _sessionService.JwtToken;

        if (string.IsNullOrWhiteSpace(value: token)) return;

        GeneralDataList = await _userService.GetUserListAsync(token);
    }

    protected override void SelectGeneralValue() { }

    #endregion
}