namespace Victory.Presentation.Desktop.ViewModels.UserControls;

internal sealed class ReadUsersViewModel : BaseReadViewModel<User>
{
    private readonly IUserFacadeService _userService;

    public ReadUsersViewModel(IUserFacadeService userService)
    {
        _userService = userService;

        Task.Run(function: () => InitializeData());
    }

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

    private async Task InitializeData() =>
        GeneralDataList = await _userService.GetUserListAsync();

    protected override void SelectGeneralValue() { }

    #endregion
}