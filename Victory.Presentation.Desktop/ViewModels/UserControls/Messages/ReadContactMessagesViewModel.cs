namespace Victory.Presentation.Desktop.ViewModels.UserControls;

internal sealed class ReadContactMessagesViewModel
    : BaseReadViewModel<ContactMessage>, IReadContactMessagesViewModel
{
    private readonly IContactMessageFacadeService _messageService;

    public ReadContactMessagesViewModel(IContactMessageFacadeService messageService)
    {
        _messageService = messageService;

        Task.Run(function: () => AutoUpdateData(
           secondsTimeout: ApplicationConfiguration.AutoUpdateSecondsTimeout,
           isEnable: ApplicationConfiguration.AutoUpdateIsEnable));
    }

    #region Other Logic

    private async Task InitializeData()
    {
        Items = await _messageService.GetContactMessageListAsync();
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