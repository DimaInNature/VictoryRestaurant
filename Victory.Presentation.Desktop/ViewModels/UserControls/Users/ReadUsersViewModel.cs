namespace Victory.Presentation.Desktop.ViewModels.UserControls;

internal sealed class ReadUsersViewModel
    : BaseReadViewModel<User>, IReadUsersViewModel
{
    private readonly IUserFacadeService _userService;

    public ReadUsersViewModel(IUserFacadeService userService)
    {
        _userService = userService;

        Task.Run(function: () => AutoUpdateData(
           secondsTimeout: ApplicationConfiguration.AutoUpdateSecondsTimeout,
           isEnable: ApplicationConfiguration.AutoUpdateIsEnable));
    }

    #region Other Logic

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